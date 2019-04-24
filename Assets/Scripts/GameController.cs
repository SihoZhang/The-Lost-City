using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject failMenu;
    [SerializeField] GameObject failAudio;
    //通知死亡，游戏结束
    public void Notify(string message)
    {
        switch (message)
        {
            case "die":
                StartCoroutine(Gameover());
                break;
            case "setMasterVolume":
                GameObject masterAudio = GameObject.Find("MasterAudio");
                if (masterAudio)
                {
                    for (int i = 0; i < masterAudio.transform.childCount; i++)
                    {
                        if (!GameInformation.isMute)
                            masterAudio.transform.GetChild(i).GetComponent<AudioSource>().volume = GameInformation.masterVolume / 100.0f;
                        else
                            masterAudio.transform.GetChild(i).GetComponent<AudioSource>().volume = 0;
                    }
                }
                break;
            case "setMusicVolume":
                GameObject musicAudio = GameObject.Find("MusicAudio");
                if (musicAudio)
                {
                    for (int i = 0; i < musicAudio.transform.childCount; i++)
                    {
                        if (!GameInformation.isMute)
                            musicAudio.transform.GetChild(i).GetComponent<AudioSource>().volume = GameInformation.musicVolume / 100.0f;
                        else
                            musicAudio.transform.GetChild(i).GetComponent<AudioSource>().volume = 0;
                    }
                }
                break;
        }
    }
    IEnumerator Gameover()
    {
        yield return new WaitForSeconds(3.0f);
        Time.timeScale = 0;
        failMenu.gameObject.SetActive(true);
        failAudio.GetComponent<AudioSource>().Play();
        GameObject.Find("MusicAudio/BGM").GetComponent<AudioSource>().enabled = false;
    }
}
