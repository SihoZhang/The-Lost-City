using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public enum Mode
    {
        loop,
        upDown
    }
    public enum Axis
    {
        x,
        y,
        z
    }
    [SerializeField] float delay;  //旋转延时
    public Mode mode;  //旋转的模式
    public Axis rotateAxis;  //绕着旋转的轴
    public float rotateSpeed;
    public float maxAngle;
    public float minAngle;
    Vector3 rotateDirection;
    int upDownDirection = 1;  //1表示向上旋转，-1表示向下
    float nowUpDownRotation = 0.0f;
    Vector3 originalEuler;
    private void Awake()
    {
        if (rotateAxis == Axis.x)
            rotateDirection = new Vector3(1, 0, 0);
        else if (rotateAxis == Axis.y)
            rotateDirection = new Vector3(0, 1, 0);
        else if (rotateAxis == Axis.z)
            rotateDirection = new Vector3(0, 0, 1);
        originalEuler = transform.eulerAngles;
        StartCoroutine(Delay(delay));
    }
    private void Update()
    {
        switch (mode)
        {
            case Mode.loop:
                transform.Rotate(rotateSpeed * rotateDirection * Time.deltaTime);
                break;
            case Mode.upDown:
                transform.Rotate(rotateSpeed * rotateDirection * Time.deltaTime * upDownDirection);
                nowUpDownRotation += rotateSpeed * Time.deltaTime * upDownDirection;
                if (nowUpDownRotation > maxAngle)
                {
                    nowUpDownRotation = maxAngle;
                    transform.eulerAngles = originalEuler + rotateDirection * maxAngle;
                    upDownDirection = -upDownDirection;
                }
                else if (nowUpDownRotation < minAngle)
                {
                    nowUpDownRotation = minAngle;
                    transform.eulerAngles = originalEuler + rotateDirection * minAngle;
                    upDownDirection = -upDownDirection;
                }
                break;
            default:
                break;
        }
    }
    IEnumerator Delay(float delay)
    {
        GetComponent<Rotate>().enabled = false;
        yield return new WaitForSeconds(delay);
        GetComponent<Rotate>().enabled = true;
    }
}
