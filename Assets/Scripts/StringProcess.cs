using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringProcess : MonoBehaviour
{
    public static ArrayList ExtractNumbers(string str)
    {
        ArrayList digits = new ArrayList();
        string result = "";
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] >= '0' && str[i] <= '9')
                result += str[i];
            else
            {
                if (result != "")
                {
                    digits.Add(result);
                    result = "";
                }
            }
        }
        return digits;
    }
}
