using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QCollections;

public class UTQDic : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        QDic<int, int> dic = new QDic<int, int>(10);

        dic.Add(1, 1);
		dic.Add(2, 2);
		dic.Add(3, 3);
		dic.Add(4, 4);

    
        Debug.Log(dic.ToString());

		dic.Remove(2);

		dic.Add(5, 5);
		
		dic.Add(2, 2);

		dic.Add(10, 10);

		dic.Add(12, 12);

		dic.Add(15, 15);

		Debug.Log(dic.ToString());

        Debug.Log(dic.GetValue(5));

		Debug.Log(dic[10]);

    }

}
