using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QCollections
{
    public class UTQTrie : MonoBehaviour
    {
        private readonly int SIZE = 26;
        // Use this for initialization
        void Start()
        {
            QTrie trie = new QTrie(SIZE);

            IList<string> wordLst = new List<string>()
            {
				"abc", "abcd", "xyz", "dba", "cde", "wahaha", "james", "abcd", "dbc", "dba", "abcdef", "abc"
            };

            for (int i = 0; i < wordLst.Count; i++)
			{
                trie.Insert(wordLst[i]);
            }

            Debug.LogFormat("abc 子串前缀数量 => {0}", trie.WordPrefixCount("abc"));

			Debug.LogFormat("是否包含单词 wahaha => {0}", trie.Contain("wahaha"));

			trie.PreOrder();

        }

    }

}
