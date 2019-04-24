using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWall : MonoBehaviour
{
    [System.Serializable]
    class Distance
    {
        //player的属性
        public GameObject Player
        {
            set
            {
                player = value;
            }
            get
            {
                return player;
            }
        }
        //maxDistance的属性
        public float MaxDistance
        {
            set
            {
                maxDistance = value;
            }
            get
            {
                return maxDistance;
            }
        }
        //nowDistance属性
        public float NowDistance
        {
            set
            {
                nowDistance = value;
            }
            get
            {
                return nowDistance;
            }
        }
        [SerializeField] private GameObject player;  //玩家，主要用于根据离玩家的距离来控制声音的大小
        [SerializeField] private float maxDistance;  //多大范围内能听到声音
        private float nowDistance;  //当前的距离
    }
    float startX;
    [SerializeField] float targetX;
    [SerializeField] float moveSpeed;  //移动速度
    bool isArrive = false;
    int direction = 1;  //往返移动，1表示正向，-1表示反向
    Vector3 vector3Differ;  //位置向量差
    AudioSource ads;
    [SerializeField] float delay;  //一开始移动的延时
    [SerializeField] Distance distance;
    private void Awake()
    {
        startX = transform.position.x;
        ads = GetComponent<AudioSource>();
        StartCoroutine(Delay());
    }
    private void Update()
    {
        //距离大于最大距离，不做操作
        distance.NowDistance = Vector3.Distance(transform.position, distance.Player.transform.position);
        if (distance.NowDistance > distance.MaxDistance)
            return;
        //控制音量
        GetComponent<AudioSource>().volume = GameInformation.masterVolume / 100.0f * (1 - distance.NowDistance / distance.MaxDistance);

        if (!isArrive)
        {
            //沿着Loacl坐标系的Y轴移动
            transform.Translate(0, direction * moveSpeed * Time.deltaTime, 0);
            if (transform.position.x > targetX || transform.position.x < startX)
            {
                isArrive = true;
                StartCoroutine(StayForATime(3.0f));
                if (direction == 1)
                    transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
                else
                    transform.position = new Vector3(startX, transform.position.y, transform.position.z);
            }
        }
    }
    //停留一段时间
    IEnumerator StayForATime(float times)
    {
        ads.Stop();
        yield return new WaitForSecondsRealtime(times);
        ads.Play();
        isArrive = false;
        direction = -direction;
        StopCoroutine(StayForATime(times));
    }
    IEnumerator Delay()
    {
        GetComponent<MovingWall>().enabled = false;
        yield return new WaitForSeconds(delay);
        GetComponent<MovingWall>().enabled = true;
    }
}
