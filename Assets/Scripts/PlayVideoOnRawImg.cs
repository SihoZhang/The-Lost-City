using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

//在RawImage上播放视频
public class PlayVideoOnRawImg : MonoBehaviour
{
    [SerializeField] GameObject mainBody;  //当视频播放完，显示主体的登录界面
    VideoPlayer vdp;  //视频播放器
    RawImage rawImg;  //播放视频的载体
    private void Awake()
    {
        vdp = GetComponent<VideoPlayer>();
        rawImg = GetComponent<RawImage>();
        if(GameInformation.isAudioPlayed)
        {
            Destroy(gameObject);
            mainBody.SetActive(true);
            GameObject.Find("MusicAudio/BGM").GetComponent<AudioSource>().Play();
        }
        //GetComponent<VideoPlayer>().SetDirectAudioVolume(0, GameInformation.masterVolume);  //匹配声音大小
        GetComponent<VideoPlayer>().SetDirectAudioVolume(0, GameInformation.masterVolume / 100.0f);
    }
    void Update()
    {
        if (!vdp.isPlaying)
        {
            Destroy(gameObject);
            mainBody.SetActive(true);
            GameInformation.isAudioPlayed = true;
            GameObject.Find("MusicAudio/BGM").GetComponent<AudioSource>().Play();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(gameObject);
            mainBody.SetActive(true);
            GameObject.Find("MusicAudio/BGM").GetComponent<AudioSource>().Play();
        }
        rawImg.texture = vdp.texture;
    }
}
