using System.Collections;
using System.Collections.Generic;
using System;

namespace QCollections
{
    public class QDic<TKey, TValue>
    {
        // 数据地址
        private int[] m_BucketLst = null;
        // 数据集合
        private QEntitle[] m_EntitleLst = null;
        // 空闲元素表头指向
        private int m_FreePoint = -1;
        // 空闲元素数量
        private int m_FreeCount = 0;
        // 元素数量
        private int m_Count = 0;
        // 容量
        private int m_Capacity = 0;
        //哈希表中的比较函数
        private IEqualityComparer<TKey> comparer;


        //构造函数
        public QDic(int capacity)
        {
            m_Capacity = capacity;
            m_BucketLst = new int[capacity];
            for (int i = 0; i < capacity; i++)
            {
                m_BucketLst[i] = -1;
            }
            m_EntitleLst = new QEntitle[capacity];
            m_FreePoint = -1;
            m_FreeCount = 0;
            m_Count = 0;
            comparer = new ComparerKey();
        }

        //添加元素
        public void Add(TKey key, TValue value)
        {
            int hashcode = QHash<TKey>.GetQHashCode(key);
            int index = hashcode % m_Capacity;



            if (m_BucketLst[index] == -1)
            {
                if (m_FreePoint == -1)
                {
                    QEntitle entitle = new QEntitle();
                    entitle.hashCode = hashcode;
                    entitle.key = key;
                    entitle.value = value;
                    entitle.next = -1;

                    m_EntitleLst[m_Count] = entitle;

                    m_BucketLst[index] = m_Count;
                }
                else
                {
                    QEntitle entitle = m_EntitleLst[m_FreePoint];
                    m_FreePoint = entitle.next;

                    entitle.hashCode = hashcode;
                    entitle.key = key;
                    entitle.value = value;
                    entitle.next = -1;

                    m_BucketLst[index] = m_FreePoint;
                    --m_FreeCount;
                }

            }
            else
            {
                if (m_FreePoint == -1)
                {
                    QEntitle entitle = new QEntitle();
                    entitle.hashCode = hashcode;
                    entitle.key = key;
                    entitle.value = value;
                    entitle.next = m_BucketLst[index];

                    m_EntitleLst[m_Count] = entitle;
                    m_BucketLst[index] = m_Count;
                }
                else
                {
                    QEntitle entitle = m_EntitleLst[m_FreePoint];
                    int freeNext = entitle.next;

                    entitle.hashCode = hashcode;
                    entitle.key = key;
                    entitle.value = value;
                    entitle.next = m_BucketLst[index];

                    m_BucketLst[index] = m_FreePoint;

                    m_FreePoint = freeNext;

                    --m_FreeCount;
                }
            }

            ++m_Count;
        }

        // 删除元素
        public bool Remove(TKey key)
        {
            int hashcode = QHash<TKey>.GetQHashCode(key);
            int index = hashcode % m_Capacity;

            QEntitle entitle = m_EntitleLst[m_BucketLst[index]];
            int lastIndex = -1;

            for (int i = m_BucketLst[index]; i >= 0; i = m_EntitleLst[i].next)
            {
                if (m_EntitleLst[i].hashCode == hashcode && comparer.Equals(m_EntitleLst[i].key, key))
                {
                    if (lastIndex < 0)
                    {
                        m_BucketLst[index] = m_EntitleLst[i].next;
                    }
                    else
                    {
                        m_EntitleLst[lastIndex].next = m_EntitleLst[i].next;
                    }

                    m_EntitleLst[i].hashCode = 0;
                    m_EntitleLst[i].key = default(TKey);
                    m_EntitleLst[i].value = default(TValue);
                    m_EntitleLst[i].next = m_FreePoint;

                    --m_Count;
                    ++m_FreeCount;
                    m_FreePoint = i;

                    return true;
                }
                lastIndex = i;
            }

            return false;
        }

        //索引器实现
        public TValue this[TKey key]
        {
            get
            {
                return GetValue(key);
            }
        }

        //获取值
        public TValue GetValue(TKey key)
        {
            int hashcode = QHash<TKey>.GetQHashCode(key);
            int index = hashcode % m_Capacity;

            QEntitle entitle = m_EntitleLst[m_BucketLst[index]];

            for (int i = m_BucketLst[index]; i >= 0; i = m_EntitleLst[i].next)
            {
                if (m_EntitleLst[i].hashCode == hashcode && comparer.Equals(m_EntitleLst[i].key, key))
                {
                    return m_EntitleLst[i].value;
                }
            }

            return default(TValue);

        }

        // string 格式化
        public override string ToString()
        {
            string ret = "";
            for (int i = 0; i < m_EntitleLst.Length; i++)
            {
                if (m_EntitleLst[i] != null)
                {
                    ret += m_EntitleLst[i].ToString() + "||";
                }
            }

            ret += "BucketLst => ";

            for (int i = 0; i < m_BucketLst.Length; i++)
            {
                ret += m_BucketLst[i].ToString() + "|";
            }

            return ret;
        }


        //key函数比较
        public class ComparerKey : IEqualityComparer<TKey>
        {
            public bool Equals(TKey x, TKey y)
            {
                return object.Equals(x, y);
            }

            public int GetHashCode(TKey obj)
            {
                return obj.GetHashCode();
            }
        }

        // 元素实体
        public class QEntitle
        {
            public int hashCode;
            public TKey key;
            public TValue value;
            public int next;

            public override string ToString()
            {
                string ret = hashCode.ToString() + " " + key.ToString() + " " + value.ToString() + " " + next.ToString();
                return ret;
            }
        }

    }

}





