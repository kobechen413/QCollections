using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QCollections;

public class UTQQueue : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        QQueue<int> queue = new QQueue<int>(5);

        queue.Add(1);
        queue.Add(2);
        queue.Add(3);
        queue.Add(4);
        queue.Add(5);

        Debug.Log(queue.ToString());

        queue.Pop();

        Debug.Log(queue.ToString());

        Debug.Log(queue.Front());

        queue.Add(6);
        queue.Add(7);
        queue.Add(8);

        Debug.Log(queue.ToString());

        queue.Pop();
        queue.Pop();
        queue.Pop();

        Debug.Log(queue.Front());
        Debug.Log(queue.ToString());

    }

}
