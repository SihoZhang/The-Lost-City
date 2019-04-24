using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickButtons : MonoBehaviour
{
    private string buttonName;
    private GameObject clickAudio;
    void Awake()
    {
        buttonName = gameObject.name;
        clickAudio = GameObject.Find("MasterAudio/Click");
    }
    public void ClickButton()
    {
        clickAudio.GetComponent<AudioSource>().Play();
        switch (buttonName)
        {
            case "B_StartGame":
                SceneManager.LoadScene("MainScene");
                break;
                //开始游戏
            case "B_Instruction":
                GameObject.Find("Canvas/Menu").transform.GetChild(0).gameObject.SetActive(true);
                break;
            case "B_Setting":
                GameObject.Find("Canvas/Menu").transform.GetChild(1).gameObject.SetActive(true);
                break;
                //设置
            case "B_Staff":
                GameObject.Find("Canvas/Menu").transform.GetChild(2).gameObject.SetActive(true);
                break;
                //制作人员
            case "B_ExitGame":
                Application.Quit();
                break;
                //退出游戏
            case "B_Close":
                Time.timeScale = 1.0f;
                transform.parent.gameObject.SetActive(false);
                break;
                //关闭按钮
            case "B_ReturnMainMenu":
                SceneManager.LoadScene("MenuScene");
                break;
                //返回主菜单
            case "B_Restart":
                SceneManager.LoadScene("MainScene");
                break;
                //重新开始游戏
            case "B_Continue":
                Time.timeScale = 1.0f;
                transform.parent.gameObject.SetActive(false);
                break;
                //继续游戏
            default:
                break;
        }
    }
}
