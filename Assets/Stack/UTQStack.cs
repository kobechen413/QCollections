using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QCollections
{
    public class UTQStack : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            QStack<string> stack = new QStack<string>(5);

            stack.Push("kobe");
			stack.Push("James");
			stack.Push("Wade");

            Debug.Log(stack.ToString());
            Debug.Log(stack.Pop());
			Debug.Log(stack.ToString());

            stack.Push("Nash");
			stack.Push("KuLi");
			stack.Push("WeiShao");
            stack.Push("Maidi");

			Debug.Log(stack.ToString());
            Debug.Log(stack.Peek());

       		Debug.Log(stack.Pop());
			Debug.Log(stack.ToString());
        }

    }
}
