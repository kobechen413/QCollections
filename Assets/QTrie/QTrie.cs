using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QCollections
{
    // 字典树
    public class QTrie
    {
        private TrieNode m_Root;

        private int m_Size;

        public QTrie(int size)
        {
            m_Size  = size;
            m_Root = new TrieNode(size);
        }

        // 插入单词
        public bool Insert(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return false;
            }

            TrieNode pNode = m_Root;
            char[] wordArr = word.ToCharArray();
            for (int i = 0, length = wordArr.Length; i < length; i++)
            {
                int pos = wordArr[i] - 'a';
                if (pNode.childNodes[pos] == null)
                {
                    pNode.childNodes[pos] = new TrieNode(m_Size);
                    pNode.childNodes[pos].data = wordArr[i];
                }
                else
                {
                    ++pNode.childNodes[pos].count;
                }
                pNode = pNode.childNodes[pos];
            }

            pNode.isEnd = true;

            return true;
        }

        // 计算单词前缀的数量
        public int WordPrefixCount(string prefix)
        {
            if (string.IsNullOrEmpty(prefix))
            {
                return -1;
            }

            TrieNode pNode = m_Root;
            char[] wordArr = prefix.ToCharArray();
            for (int i = 0, length = wordArr.Length; i < length; i++)
            {
                int pos = wordArr[i] - 'a';
                if (pNode.childNodes[pos] == null)
                {
                    return 0;
                }
                pNode = pNode.childNodes[pos];
            }

            return pNode.count;
        }

        // 是否包含完整单词
        public bool Contain(string word)
        {
            TrieNode pNode = m_Root;
            char[] wordArr = word.ToCharArray();
            for (int i = 0, length = wordArr.Length; i < length; i++)
            {
                int pos = wordArr[i] - 'a';
                if (pNode.childNodes[pos] == null)
                {
                    return false;
                }
                pNode = pNode.childNodes[pos];
            }

            return pNode.isEnd;
        }

        // 遍历字典树接口
        public void PreOrder()
        {
            PreOrder(m_Root);
        }

        // 遍历字典树
        public void PreOrder(TrieNode pNode)
        {
            if (pNode != null)
            {
                Debug.LogFormat("遍历字典树节点 => {0}", pNode.data);
                foreach (TrieNode child in pNode.childNodes)
                {
                    PreOrder(child);
                }
            }
        }


        public class TrieNode
        {
            // 字典树节点数据
            public char data;
            // 子节点
            public TrieNode[] childNodes;
            // 经过该节点的数量
            public int count;
            // 是否是最后一个节点
            public bool isEnd;

            public TrieNode(int size)
            {
                count = 1;
                isEnd = false;
                childNodes = new TrieNode[size];
            }
        }


    }
}

