using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//文本的值
public class TextValue : MonoBehaviour
{
    enum Mode
    {
        resolution,  //分辨率
        masterVolume,  //主音量
        imageQuality,  //画质
        musicVolume  //音乐音量
    }
    [SerializeField] Mode mode;
    string nowValueStr;
    int nowValueInt;
    int nowIndex;
    ArrayList values = new ArrayList();
    string[] qualityName = { "非常低", "低", "中等", "高", "非常高", "极高" };
    private void Awake()
    {
        switch (mode)
        {
            case Mode.resolution:
                for (int i = 0; i < Screen.resolutions.Length; i++)
                    values.Add(Screen.resolutions[i].ToString());
                for (int i = 0; i < values.Count; i++)
                {
                    if (values[i].ToString() == Screen.currentResolution.ToString())
                    {
                        nowIndex = i;
                        break;
                    }
                }
                GetComponent<Text>().text = MyString.PreString(values[nowIndex].ToString(), '@');
                break;
            case Mode.masterVolume:
                nowValueInt = GameInformation.masterVolume;
                nowIndex = (int)(GameInformation.masterVolume / 10);
                GameObject gameController = GameObject.Find("GameController");
                gameController.GetComponent<GameController>().Notify("setMasterVolume");
                GetComponent<Text>().text = GameInformation.masterVolume.ToString();
                break;
            case Mode.musicVolume:
                nowValueInt = GameInformation.musicVolume;
                nowIndex = (int)(GameInformation.musicVolume / 10);
                GameObject _gameController = GameObject.Find("GameController");
                _gameController.GetComponent<GameController>().Notify("setMusicVolume");
                GetComponent<Text>().text = GameInformation.musicVolume.ToString();
                break;
            case Mode.imageQuality:
                nowIndex = QualitySettings.GetQualityLevel();
                GetComponent<Text>().text = qualityName[nowIndex];
                break;
        }
    }
    public void TurnUp()
    {
        switch (mode)
        {
            case Mode.resolution:
                nowIndex = (nowIndex + 1) % values.Count;
                string nowResolution = MyString.PreString(values[nowIndex].ToString(), '@');
                GetComponent<Text>().text = nowResolution;
                Screen.SetResolution((int)MyString.DrawInteger(nowResolution)[0], (int)MyString.DrawInteger(nowResolution)[1], GameInformation.isFullScreen);
                break;
            case Mode.masterVolume:
                nowIndex = (nowIndex + 1) % 11;
                GameInformation.masterVolume = 10 * nowIndex;
                GameObject gameController = GameObject.Find("GameController");
                gameController.GetComponent<GameController>().Notify("setMasterVolume");
                GetComponent<Text>().text = GameInformation.masterVolume.ToString();
                break;
            case Mode.musicVolume:
                nowIndex = (nowIndex + 1) % 11;
                GameInformation.musicVolume = 10 * nowIndex;
                GameObject _gameController = GameObject.Find("GameController");
                _gameController.GetComponent<GameController>().Notify("setMusicVolume");
                GetComponent<Text>().text = GameInformation.musicVolume.ToString();
                break;
            case Mode.imageQuality:
                nowIndex = (nowIndex + 1) % 6;
                GetComponent<Text>().text = qualityName[nowIndex];
                QualitySettings.SetQualityLevel(nowIndex);
                break;
        }
    }
    public void TurnDown()
    {
        switch (mode)
        {
            case Mode.resolution:
                nowIndex = (nowIndex - 1 + values.Count) % values.Count;
                string nowResolution = MyString.PreString(values[nowIndex].ToString(), '@');
                GetComponent<Text>().text = nowResolution;
                Screen.SetResolution((int)MyString.DrawInteger(nowResolution)[0], (int)MyString.DrawInteger(nowResolution)[1], GameInformation.isFullScreen);
                break;
            case Mode.masterVolume:
                nowIndex = (nowIndex - 1 + 11) % 11;
                GameInformation.masterVolume = 10 * nowIndex;
                GameObject gameController = GameObject.Find("GameController");
                gameController.GetComponent<GameController>().Notify("setMasterVolume");
                GetComponent<Text>().text = GameInformation.masterVolume.ToString();
                break;
            case Mode.musicVolume:
                nowIndex = (nowIndex - 1 + 11) % 11;
                GameInformation.musicVolume = 10 * nowIndex;
                GameObject _gameController = GameObject.Find("GameController");
                _gameController.GetComponent<GameController>().Notify("setMusicVolume");
                GetComponent<Text>().text = GameInformation.musicVolume.ToString();
                break;
            case Mode.imageQuality:
                nowIndex = (nowIndex - 1 + 6) % 6;
                GetComponent<Text>().text = qualityName[nowIndex];
                QualitySettings.SetQualityLevel(nowIndex);
                break;
        }
    }
}
