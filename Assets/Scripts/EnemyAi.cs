using System.Collections;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [System.Serializable]
    class FollowThreshold
    {
        public float min;
        public float max;
    }
    GameObject target;
    Vector3 flyDirection;
    float flySpeed = 30.0f;  //飞行速度
    float distance;  //当前物体和target之间的距离
    [SerializeField] FollowThreshold followThreshold;  //跟随的阈值
    GameObject laser;  //用来攻击的激光
    [SerializeField] bool forceFollow = false;  //是否强制跟随
    [SerializeField] GameObject emitAudio;  //发射的声音
    private void Awake()
    {
        target = GameObject.Find("Daniel");
        laser = transform.GetChild(0).gameObject;
    }
    private void Update()
    {
        Vector3 targetPosition = target.transform.position + new Vector3(0, 15.0f, 0);
        flyDirection = targetPosition - transform.position;
        float xWeight = flyDirection.x;  //X分量
        float yWeight = flyDirection.y;  //Y分量
        float zWeight = flyDirection.z;  //Z分量
        float factor = Mathf.Sqrt(xWeight * xWeight + yWeight * yWeight + zWeight * zWeight);
        xWeight /= factor;
        yWeight /= factor;
        zWeight /= factor;
        flyDirection = new Vector3(xWeight, yWeight, zWeight);
        transform.LookAt(targetPosition);
        //transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
        distance = Vector3.Distance(transform.position, targetPosition);
        if ((distance > followThreshold.min && distance < followThreshold.max) || forceFollow)
            transform.Translate(flySpeed * flyDirection * Time.deltaTime);
        else if(distance <= followThreshold.min)
        {  //在距离内开始攻击
            StartCoroutine(Attack());
        }
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, transform.eulerAngles.z);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
    //每8秒攻击一次
    IEnumerator Attack()
    {
        laser.SetActive(true);
        emitAudio.GetComponent<AudioSource>().Play();
        StartCoroutine(CloseLaser());
        yield return new WaitForSeconds(8.0f);
        StopCoroutine(Attack());
    }
    //攻击3秒后关闭激光
    IEnumerator CloseLaser()
    {
        yield return new WaitForSeconds(3.0f);
        laser.SetActive(false);
        StopCoroutine(CloseLaser());
    }
}
