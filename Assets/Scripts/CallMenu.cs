using UnityEngine;

//该脚本用于按下ESC键，弹出菜单
public class CallMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0.0f;  //暂停
            menu.gameObject.SetActive(true);
        }
    }
}
