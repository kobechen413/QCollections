using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UTSort : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        int[] a = new int[]
        {
            2, 1, 5, 3, 4
        };

        PrintArray(a);

        QSort.QuickSortR(a, 0, 4);

		PrintArray(a);


        int[] b = new int[]
        {
            10, 1, 7, 8, 2 
        };

        PrintArray(b);

        QSort.InsertSort(b, 0, 4);

		PrintArray(b);


        
        int[] c = new int[]
        {
            9, 2, 5, 7, 10 
        };

        PrintArray(c);

        QSort.HeapSort(c, 0, 5);

		PrintArray(c);
     
    }

    void PrintArray(int[] a)
    {
        var ret = "";
        for (int i = 0; i < a.Length; i++)
        {
            ret += a[i].ToString() + "  ";
        }

        Debug.LogFormat("Array => {0}", ret);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
