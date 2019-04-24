using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject cam;  //在移动的时候，角色的旋转角度应该与摄像机的一致   
    Animator ani;
    const float totalRunInterval = 0.2f; //在这时间内连续按2次W就能触发奔跑
    float nowRunInterval = 0.0f;
    public float moveSpeed = 0.0f;
    int moveStatu = 0;  //移动状态，0为待机，1为走路，2为预备跑，3为跑步，4为跳
    private void Awake()
    {
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
        RunInterval();
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (moveStatu == 0)
                moveStatu = 1;
            else if (moveStatu == 1)
                moveStatu = 2;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            if (moveStatu == 3)
            {
                ani.SetInteger("motionID", 0);
                moveStatu = 0;
            }
            else if (moveStatu == 1)
            {
                moveStatu = 2;
            }
        }
        /* 旋转人物 */
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, -72 * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, 72 * Time.deltaTime, 0);
        /**/
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            moveStatu = 4;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            moveStatu = 0;
        }
        //走路
        if (moveStatu == 1)
        {
            ani.SetInteger("motionID", 1);
            moveSpeed = 3.0f;
        }
        else if (moveStatu == 3)
        {
            ani.SetInteger("motionID", 2);
            moveSpeed = 20.0f;
        }
        else if (moveStatu == 4)
        {
            ani.SetInteger("motionID", 3);
        }
        else
        {
            moveSpeed = 0.0f;
            ani.SetInteger("motionID", 0);
        }
        transform.Translate(0, 0, moveSpeed * Time.deltaTime);
    }
    private void LateUpdate()
    {
        if (moveStatu != 0)
        {
            transform.rotation = Quaternion.Euler(0, cam.transform.localEulerAngles.y, 0);
        }
    }
    private void RunInterval()
    {
        if (moveStatu == 2)
        {
            nowRunInterval += Time.deltaTime;
            if (nowRunInterval <= totalRunInterval)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    moveStatu = 3;
                }
            }
            else
            {
                moveStatu = 0;
                nowRunInterval = 0.0f;
            }
        }
    }
}