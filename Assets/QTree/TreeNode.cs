using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QCollections
{
	// 树节点
    public class TreeNode<T>
    {
        private T m_Data;
        public TreeNode<T> LeftNode;
        public TreeNode<T> RightNode;

		
		public TreeNode(T data, TreeNode<T> leftNode = null, TreeNode<T> rightNode = null)
		{
            m_Data = data;
            LeftNode = leftNode;
            RightNode = rightNode;
        }

		public T GetNodeData()
		{
            return m_Data;
        }

        public override string ToString()
        {
            string ret = "data:" + m_Data.ToString();
            ret += (LeftNode == null) ? "" : ("||leftData:" + LeftNode.GetNodeData().ToString());
            ret += (RightNode == null) ? "" : ("||rightData:" + RightNode.GetNodeData().ToString());
        
            return ret;
        }

    }
}

