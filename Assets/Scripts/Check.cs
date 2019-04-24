using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//选择框
public class Check : MonoBehaviour
{
    enum Type
    {
        fullScreen,
        BGM
    }
    [SerializeField] Type type;
    GameObject clickAudio;  //点击声音
    private void Awake()
    {
        clickAudio = GameObject.Find("MasterAudio/Click");
        switch(type)
        {
            case Type.fullScreen:
                GetComponent<Toggle>().isOn = GameInformation.isFullScreen;
                break;
            case Type.BGM:
                GetComponent<Toggle>().isOn = !GameInformation.isMute;
                break;
        }
    }
    public void ChangeValue()
    {
        clickAudio.GetComponent<AudioSource>().Play();
        switch (type)
        {
            case Type.fullScreen:
                Resolution nowResolution = Screen.currentResolution;
                if (GetComponent<Toggle>().isOn)
                {
                    Screen.SetResolution(nowResolution.width, nowResolution.height, true);
                    GameInformation.isFullScreen = true;
                }
                else
                {
                    Screen.SetResolution(nowResolution.width, nowResolution.height, false);
                    GameInformation.isFullScreen = false;
                }
                break;
            case Type.BGM:
                if (GetComponent<Toggle>().isOn)
                    GameInformation.isMute = false;
                else
                    GameInformation.isMute = true;
                GameObject gameController = GameObject.Find("GameController");
                gameController.GetComponent<GameController>().Notify("setMasterVolume");
                gameController.GetComponent<GameController>().Notify("setMusicVolume");
                break;
        }
    }
}
