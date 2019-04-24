using UnityEngine;
using System.Collections;

//该脚本挂在人物的CameraPoint上
public class CameraFollow : MonoBehaviour
{
    public GameObject target;  //要跟踪的目标
    private float smooth = 5.0f;   //平滑程度
    Vector3 offset;
    Vector3 CamPos;
    float preMouseX;
    float newMouseX;
    float preMouseY;
    float newMouseY;
    float D_value;  //鼠标移动前和移动后x坐标的差值
    float range = 0.4f;  //系数，摄像机旋转角度 = range * D_value
    [SerializeField] float minEulerX;  //X轴最小的欧拉角
    [SerializeField] float maxEulerX;  //X轴最大的欧拉角
    void Awake()
    {
        offset = transform.position - target.transform.position;  //CameraPoint和target原始的距离差
    }
    void Update()
    {
        //视角拉近拉远
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (Camera.main.fieldOfView <= 96)
                Camera.main.fieldOfView += 2.0f;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (Camera.main.fieldOfView >= 16)
                Camera.main.fieldOfView -= 2.0f;
        }

        //通过按键使视角水平旋转
        if (Input.GetKey(KeyCode.Q))
            transform.Rotate(0, -72 * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.E))
            transform.Rotate(0, 72 * Time.deltaTime, 0);

        //通过鼠标使视角水平旋转
        if (Input.GetMouseButtonDown(1))
        {
            preMouseX = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(1))
        {
            newMouseX = Input.mousePosition.x;
            D_value = newMouseX - preMouseX;
            transform.Rotate(0, range * D_value, 0);
            preMouseX = newMouseX;
        }

        //通过鼠标使视角垂直旋转
        if (Input.GetMouseButtonDown(1))
        {
            preMouseY = Input.mousePosition.y;
        }
        if (Input.GetMouseButton(1))
        {
            newMouseY = Input.mousePosition.y;
            D_value = newMouseY - preMouseY;
            transform.Rotate(-range * D_value, 0, 0);
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
            preMouseY = newMouseY;
        }
        //限制X轴的旋转角度在[minEulerX, maxEulerX]内
        if (transform.eulerAngles.x > maxEulerX && transform.eulerAngles.x <= 100)
            transform.eulerAngles = new Vector3(maxEulerX, transform.eulerAngles.y, transform.eulerAngles.z);
        else if (transform.eulerAngles.x < minEulerX + 360 && transform.eulerAngles.x > 200)
            transform.eulerAngles = new Vector3(minEulerX, transform.eulerAngles.y, transform.eulerAngles.z);
    }
    private void LateUpdate()
    {
        CamPos = offset + target.transform.position;
        transform.position = Vector3.Lerp(transform.position, CamPos, smooth * Time.deltaTime);
    }
}
