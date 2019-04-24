using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

//是Button类的子类，主要实现鼠标悬停效果
public class MyButton : Button
{
    public GameObject bar;
    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        base.DoStateTransition(state, instant);
        switch (state)
        {
            case SelectionState.Disabled:
                break;
            case SelectionState.Highlighted:
                bar.gameObject.SetActive(true);
                break;
            case SelectionState.Normal:
                bar.gameObject.SetActive(false);
                break;
            case SelectionState.Pressed:
                break;
            default:
                break;
        }
    }
}
