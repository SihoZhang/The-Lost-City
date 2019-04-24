using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//游戏初始化
public class InitializeGame : MonoBehaviour
{
    GameObject gameController;
    private void Awake()
    {
        Time.timeScale = 1.0f;
        gameController = GameObject.Find("GameController");
        gameController.GetComponent<GameController>().Notify("setMasterVolume");
        gameController.GetComponent<GameController>().Notify("setMusicVolume");
    }
}
