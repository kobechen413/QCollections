using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QCollections
{
    public class QStack<T>
    {
        T[] m_Array = null;
        int m_Count = 0;

        int m_Capacity = 0;

		// 初始话栈
        public QStack(int capacity)
		{
            m_Capacity = capacity;
            m_Array = new T[capacity];
            m_Count = 0;
        }

		// 入栈
		public void Push(T data)
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


		// 出栈
		public T Pop()
		{
			if (IsEmpty())
			{
                throw new System.Exception("the stack is empty");
            }

            T data = m_Array[m_Count - 1];
            --m_Count;
            return data;
        }

		// 栈顶元素
		public T Peek()
		{
			if (IsEmpty())
			{
                throw new System.Exception("the stack is empty");
            }

			return m_Array[m_Count - 1];
        }

		// 空栈判断
        public bool IsEmpty()
        {
            return m_Count == 0;
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