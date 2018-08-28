using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QCollections
{
    public class UTMinStack : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            MinStack stack = new MinStack();

            stack.Push(4);
			stack.Push(3);
			stack.Push(2);
			stack.Push(1);

            stack.Pop();
            stack.Pop();

            Debug.Log(stack.GetMinData());
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

