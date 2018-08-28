using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQueue<T>
{
	// 入队
	void Add(T data);
    // 出队
	T Pop();
    // 获取队头
	T Front();
    // 是否空
	bool IsEmpty();
}