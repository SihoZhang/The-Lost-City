using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalPoint : MonoBehaviour
{
    [SerializeField] GameObject succeedMenu;
    [SerializeField] GameObject audioObj;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            succeedMenu.SetActive(true);
            audioObj.GetComponent<AudioSource>().Play();
            GameObject.Find("MusicAudio/BGM").GetComponent<AudioSource>().enabled = false;
            Time.timeScale = 0.0f;
        }
    }
}
