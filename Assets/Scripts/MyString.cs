using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyString : MonoBehaviour
{
    //提取所有的整数
    public static ArrayList DrawInteger(string str, char endChar='\0')
    {
        ArrayList list = new ArrayList();
        string integer = "";
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] >= '0' && str[i] <= '9')
                integer += str[i];
            else if (integer != "")
            {
                list.Add(int.Parse(integer));
                integer = "";
            }
            if (str[i] == endChar)
                break;
        }
        return list;
    }
    //截取字符串
    public static string PreString(string str, char knife)
    {
        string subStr = "";
        for(int i=0; i<str.Length; i++)
        {
            if (str[i] != knife)
                subStr += str[i];
            else
                break;
        }
        return subStr;
    }
}
