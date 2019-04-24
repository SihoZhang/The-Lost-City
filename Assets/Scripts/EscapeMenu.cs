using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用于弹出和关闭菜单
public class EscapeMenu : MonoBehaviour
{
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = 1.0f;
            transform.gameObject.SetActive(false);
        }
    }
}
