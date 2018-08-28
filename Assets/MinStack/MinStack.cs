using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace QCollections
{
    public class MinStack
    {
        Stack<int> m_DataStatck;
        Stack<int> m_MinStack;

        public MinStack()
        {
            m_DataStatck = new Stack<int>();
            m_MinStack = new Stack<int>();
        }

        public void Push(int data)
        {
            m_DataStatck.Push(data);

            if (m_DataStatck.Count == 1)
            {
                m_MinStack.Push(data);
            }
            else
            {
                int minData = m_MinStack.Peek();
                if (data < minData)
                {
                    m_MinStack.Push(data);
                }
            }
        }

        public int Pop()
        {
            int data = m_DataStatck.Pop();
            int minData = m_MinStack.Peek();

            if (data == minData)
            {
                m_MinStack.Pop();
            }

            return data;
        }

        public int Peek()
        {
            int data = m_DataStatck.Peek();

            return data;
        }

        public int GetMinData()
        {
            return m_MinStack.Peek();
        }

    }

}





