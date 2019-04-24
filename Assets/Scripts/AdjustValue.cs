using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//用左右箭头按钮调节值的大小
public class AdjustValue : MonoBehaviour
{
    enum Direction
    {
        left,  //向左调节
        right  //向右调节
    }
    [SerializeField] Direction direction;
    [SerializeField] GameObject value;
    GameObject clickAudio;
    private void Awake()
    {
        clickAudio = GameObject.Find("MasterAudio/Click");
    }
    public void Click()
    {
        clickAudio.GetComponent<AudioSource>().Play();
        if(direction == Direction.right)
        {
            value.GetComponent<TextValue>().TurnUp();
        }
        else if (direction == Direction.left)
        {
            value.GetComponent<TextValue>().TurnDown();
        }
    }
}
