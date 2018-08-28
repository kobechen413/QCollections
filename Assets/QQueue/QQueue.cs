using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QCollections
{
    public class QQueue<T>
    {
        // 元素集合
        T[] m_Array = null;
        // 元素数量
        int m_Count = 0;
        // 集合大小
        int m_Capacity = 0;


        // 构造队列
        public QQueue(int capacity)
        {
            m_Capacity = capacity;
            m_Array = new T[capacity];
            m_Count = 0;
        }

        // 入队
        public void Add(T data)
        {
            if (m_Count >= m_Capacity)
            {
                m_Capacity = 2 * m_Capacity;
                T[] temp = new T[m_Capacity];
                m_Array.CopyTo(temp, 0);
                m_Array = temp;
            }

            m_Array[m_Count++] = data;

        }

        // 出队
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new System.Exception("the queue is empty");
            }

            T data = m_Array[0];
            for (int i = 1; i < m_Count; i++)
            {
                m_Array[i - 1] = m_Array[i];
            }

            --m_Count;
            return data;
        }

        // 获取队头元素
        public T Front()
        {
            if (IsEmpty())
            {
                throw new System.Exception("the queue is empty");
            }

            return m_Array[0];
        }

        // 判断空队
        public bool IsEmpty()
        {
            return m_Count == 0;
        }

        // 元素数量
        public int Count
        {
            get { return m_Count; }
        }
        
        public override string ToString() 
        {
            string ret = "";
            for (int i = 0; i < m_Count; i++)
			{
                ret += m_Array[i] + " ";
            }

            return ret;
        }
    }

}
