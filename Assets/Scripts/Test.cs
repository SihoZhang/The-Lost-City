using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    string str = "456";
    private void Awake()
    {
        ArrayList list =  MyString.DrawInteger("1234 * 5678 @ 123", '@');
        for (int i = 0; i < list.Count; i++)
            Debug.Log(list[i]);
    }
}

