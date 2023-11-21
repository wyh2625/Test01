using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField PlayerName;  // 输入游戏名
    private InputField UserName; // 用户名
    private InputField PassWord; // 输入密码
    private Button LoginButton; // 登入按钮
    private Text Tips; // 提示文本
    private Toggle HidePassword; // 隐藏密码

    // 使其他脚本可以调用Login脚本中的变量
    private static Login _instance;
    public static Login Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()  // 初始化
    {
        _instance = this;
    }

    void Start()
    {
        // 初始化
        PlayerName = GameObject.Find("PlayerNameInput").GetComponent<InputField>();
        UserName = GameObject.Find("UserNameInput").GetComponent<InputField>();
        PassWord = GameObject.Find("PasswordInput").GetComponent<InputField>();
        PassWord.contentType = InputField.ContentType.Password; // 隐藏密码
        
        Tips = GameObject.Find("Tips").GetComponent<Text>();
        Tips.text = null;

        HidePassword = GameObject.Find("Show").GetComponent<Toggle>();
        HidePassword.isOn = true;
        HidePassword.onValueChanged.AddListener(ToggleOnValueChange); // 绑定监听事件

        LoginButton = GameObject.Find("LoginButton").GetComponent<Button>();
        LoginButton.onClick.AddListener(OnButtonClick); // 绑定监听事件
    }

    void OnButtonClick()
    {
        string username = UserName.text; // 获取输入的用户名
        string password = PassWord.text; // 获取输入的密码
        // 判断用户名、密码是否正确
        if (username == "123" && password == "234") 
        {
            Tips.text = "登入成功！";
            // 加载新场景
            SceneManager.LoadScene("SchoolSceneDay");
        }
        else if(username == "123" && password != "234")
        {
            Tips.text = "密码输入错误！";
        }
        else
        {
            Tips.text = "用户名输入有误！";
        }
    }  
    
    void ToggleOnValueChange(bool isOn)
    {
        if (isOn) // 隐藏密码
        {
            PassWord.contentType = InputField.ContentType.Password; // 隐藏密码
        }
        else
        {
            PassWord.contentType = InputField.ContentType.Standard; // 显示密码
        }
        
    }
}
