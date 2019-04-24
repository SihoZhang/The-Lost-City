using UnityEngine;
using UnityEngine.UI;

public class AdaptFontSize : MonoBehaviour
{
    int nowSize;  //当前字体大小
    private void Awake()
    {
        nowSize = GetComponent<Text>().fontSize;
    }
    private void FixedUpdate()
    {
        int size1 = (int)Mathf.Ceil((float)nowSize / GameInformation.prefabResolution.Width * Screen.width);
        int size2 = GetComponent<Text>().fontSize = (int)Mathf.Ceil((float)nowSize / GameInformation.prefabResolution.Height * Screen.height);
        GetComponent<Text>().fontSize = size1 <= size2 ? size1 : size2;
    }
}
