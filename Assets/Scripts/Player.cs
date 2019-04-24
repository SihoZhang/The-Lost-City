using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//角色的一些碰撞事件处理
public class Player : MonoBehaviour
{
    [SerializeField] GameObject dieAudio;
    Animator ani;
    private void Awake()
    {
        ani = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Die();
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "SceneLaser" || other.tag == "EnemyLaser")
        {
            Die();
        }
    }
    private void Die()
    {
        GameObject.Find("GameController").GetComponent<GameController>().Notify("die");
        GetComponent<PlayerController>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        ani.SetInteger("motionID", 4);  //播放死亡动画
        dieAudio.GetComponent<AudioSource>().Play();
    }
}
