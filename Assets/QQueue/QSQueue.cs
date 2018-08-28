using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QCollections
{
    public class QSQueue<T> : IQueue<T>
    {
        // 入队列元素
        Stack<T> m_StackIn = null;
        // 出队列元素
        Stack<T> m_StackOut = null;
        // 元素数量
        int m_Count = 0;

        // 队列构造
        public QSQueue()
        {
            m_StackIn = new Stack<T>();
            m_StackOut = new Stack<T>();
            m_Count = 0;
        }

        // 入队
        public void Add(T data)
        {
            while (m_StackOut.Count > 0)
            {
                m_StackIn.Push(m_StackOut.Pop());
            }
            m_StackIn.Push(data);
            ++m_Count;
        }

        // 出队
        public T Pop()
        {
            while (m_StackIn.Count > 0)
            {
                m_StackOut.Push(m_StackIn.Pop());
            }

            if (m_StackOut.Count <= 0)
            {
                throw new System.Exception("the queue is empty");
            }

            T data = m_StackOut.Pop();
            --m_Count;
            return data;
        }

        // 获取队头元素
        public T Front()
        {
            while (m_StackIn.Count > 0)
            {
                m_StackOut.Push(m_StackIn.Pop());
            }

            if (m_StackOut.Count <= 0)
            {
                throw new System.Exception("the queue is empty");
            }

            return m_StackOut.Peek();
        }

        // 是否空队列
        public bool IsEmpty()
        {
            return m_Count == 0;
        }

        public override string ToString()
        {
            string ret = "";

            while (m_StackIn.Count > 0)
            {
                m_StackOut.Push(m_StackIn.Pop());
            }

            if (m_StackOut.Count > 0)
            {
                T[] array = m_StackOut.ToArray();

                for (int i = 0; i < array.Length; i++)
                {
                    ret += array[i] + " ";
                }
            }

            return ret;
        }

    }

}
