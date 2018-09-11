using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QSort
{
    public static void QuickSortR(int[] array, int low, int high)
    {
        if (low >= high)
        {
            return;
        }

        int pivot = FindPivot(array, low, high);

        QuickSortR(array, low, pivot - 1);
        QuickSortR(array, pivot + 1, high);
    }

    public static int FindPivot(int[] array, int low, int high)
    {

        int i = low;
        int j = high;
        int temp = array[i];

        while (i < j)
        {
            while (i < j && array[j] > temp)
            {
                j--;
            }

            if (i < j)
            {
                array[i++] = array[j];
            }

            while (i < j && array[i] < temp)
            {
                i++;
            }

            if (i < j)
            {
                array[j--] = array[i];
            }
        }
        array[i] = temp;

        return i;

    }


    public static void InsertSort(int[] array, int low, int high)
    {
        int temp = 0;
        int p = 0;
        for (int i = 1; i < array.Length; i++)
        {
            temp = array[i];
            p = i - 1;

            while (p >= 0 && temp < array[p])
            {
                array[p + 1] = array[p];
                --p;
            }

            if (temp != array[p + 1])
            {
                array[p + 1] = temp;
            }
        }
    }

    public static void HeapSort(int[] array, int low, int high)
    {
        for (int i = high / 2; i >= 0; i--)
        {
            DownAdjust(array, i, high - 1);
        }
    }

    public static void DownAdjust(int[] array, int parentIndex, int Length)
    {
        int temp = array[parentIndex];

        int childIndex = 2 * parentIndex + 1;

        while (childIndex < Length)
        {
            if ( (childIndex + 1) < Length && array[childIndex + 1] < array[childIndex])
            {
                childIndex++;
            }

            if (temp <= array[childIndex])
            {
                break;
            }

            array[parentIndex] = array[childIndex];
            parentIndex = childIndex;
            childIndex = 2 * childIndex + 1;
        }

        array[parentIndex] = temp;
    }

    public static void UpAdjust(int[] array, int childIndex, int Length)
    {

    }


}
