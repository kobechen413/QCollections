using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QCollections;

public class UTTree : MonoBehaviour {

	// Use this for initialization
	void Start () {
        List<int> lst = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        BinaryTree<int> tree = new BinaryTree<int>(lst.ToArray(), 10);

        print("++++++先序遍历++++++");
        tree.PreOrder();

		print("++++++中序遍历++++++");
        tree.InOrder();
		
		print("++++++后序遍历++++++");
        tree.PostOrder();
		
		print("++++++层次遍历++++++");
        tree.LeverOrder();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
