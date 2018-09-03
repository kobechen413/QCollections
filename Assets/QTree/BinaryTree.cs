using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QCollections
{
    // 二叉树
    public class BinaryTree<T>
    {
        private TreeNode<T> m_Root;

        public BinaryTree(T[] dataArray, int length)
        {
            int index = 0;
            m_Root = CreateTree(dataArray, length, ref index);
        }

        ~BinaryTree()
        {
            Destory(m_Root);
        }

        //递归创建
        public TreeNode<T> CreateTree(T[] dataArray, int length, ref int index)
        {
            TreeNode<T> treeNode = null;
            if (index < length)
            {
                treeNode = new TreeNode<T>(dataArray[index]);
                ++index;
                treeNode.LeftNode = CreateTree(dataArray, length, ref index);
                ++index;
                treeNode.RightNode = CreateTree(dataArray, length, ref index);
            }

            return treeNode;
        }


        // 先序遍历接口
        public void PreOrder()
        {
            PreOrder(m_Root);
            //    PreOrderR(m_Root);
        }

        // 先序递归遍历
        private void PreOrderR(TreeNode<T> rootNode)
        {
            if (rootNode != null)
            {
                Debug.LogFormat("树元素 => {0}", rootNode.ToString());

                PreOrderR(rootNode.LeftNode);
                PreOrderR(rootNode.RightNode);
            }

        }

        // 先序非递归遍历
        private void PreOrder(TreeNode<T> rootNode)
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            stack.Push(rootNode);

            while (stack.Count > 0)
            {
                TreeNode<T> topNode = stack.Pop();
                Debug.LogFormat("树元素 => {0}", topNode.ToString());

                if (topNode.RightNode != null)
                {
                    stack.Push(topNode.RightNode);
                }

                if (topNode.LeftNode != null)
                {
                    stack.Push(topNode.LeftNode);
                }
            }

        }

        // 中序遍历接口
        public void InOrder()
        {
            InOrder(m_Root);
        }

        // 中序递归遍历
        private void InOrderR(TreeNode<T> rootNode)
        {
            if (rootNode != null)
            {
                InOrderR(rootNode.LeftNode);
                Debug.LogFormat("树元素 => {0}", rootNode.ToString());
                InOrderR(rootNode.RightNode);
            }
        }

        // 中序非递归遍历
        private void InOrder(TreeNode<T> rootNode)
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            TreeNode<T> cur = rootNode;

            while (cur != null || stack.Count > 0)
            {
                while (cur != null)
                {
                    stack.Push(cur);
                    cur = cur.LeftNode;
                }

                if (stack.Count > 0)
                {
                    TreeNode<T> topNode = stack.Pop();
                    Debug.LogFormat("树元素 => {0}", topNode.ToString());
                    cur = topNode.RightNode;
                }
            }
        }

        // 后序遍历接口
        public void PostOrder()
        {
            PostOrder(m_Root);
            // PostOrderR(m_Root);
        }

        // 后序递归遍历
        private void PostOrderR(TreeNode<T> rootNode)
        {
            if (rootNode != null)
            {
                PostOrderR(rootNode.LeftNode);
                PostOrderR(rootNode.RightNode);
                Debug.LogFormat("树元素 => {0}", rootNode.ToString());
            }
        }

        // 后序非递归遍历
        private void PostOrder(TreeNode<T> rootNode)
        {
            Stack<TreeNode<T>> stack1 = new Stack<TreeNode<T>>();
            Stack<TreeNode<T>> stack2 = new Stack<TreeNode<T>>();

            stack1.Push(rootNode);

            while (stack1.Count > 0)
            {
                TreeNode<T> topNode = stack1.Pop();
                stack2.Push(topNode);

                if (topNode.LeftNode != null)
                {
                    stack1.Push(topNode.LeftNode);
                }

                if (topNode.RightNode != null)
                {
                    stack1.Push(topNode.RightNode);
                }
            }

            while (stack2.Count > 0)
            {
                Debug.LogFormat("树元素 => {0}", stack2.Pop().ToString());
            }
        }
        
        // 层次遍历接口
        public void LeverOrder()
        {
            LeverOrder(m_Root);
        }

        // 层次遍历
        private void LeverOrder(TreeNode<T> rootNode)
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(rootNode);

            while (queue.Count > 0)
            {
                TreeNode<T> topNode = queue.Dequeue();
                Debug.LogFormat("树元素 => {0}", topNode.ToString());

                if(topNode.LeftNode != null)
                {
                    queue.Enqueue(topNode.LeftNode);
                }

                if(topNode.RightNode != null)
                {
                    queue.Enqueue(topNode.RightNode);
                }

            }
        }

        // 销毁树
        public void Destory(TreeNode<T> rootNode)
        {
            if (rootNode != null)
            {
                Destory(rootNode.LeftNode);
                Destory(rootNode.RightNode);
                rootNode = null;
            }
        }


    }
}
