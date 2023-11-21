using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField PlayerName;  // ������Ϸ��
    private InputField UserName; // �û���
    private InputField PassWord; // ��������
    private Button LoginButton; // ���밴ť
    private Text Tips; // ��ʾ�ı�
    private Toggle HidePassword; // ��������

    // ʹ�����ű����Ե���Login�ű��еı���
    private static Login _instance;
    public static Login Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()  // ��ʼ��
    {
        _instance = this;
    }

    void Start()
    {
        // ��ʼ��
        PlayerName = GameObject.Find("PlayerNameInput").GetComponent<InputField>();
        UserName = GameObject.Find("UserNameInput").GetComponent<InputField>();
        PassWord = GameObject.Find("PasswordInput").GetComponent<InputField>();
        PassWord.contentType = InputField.ContentType.Password; // ��������
        
        Tips = GameObject.Find("Tips").GetComponent<Text>();
        Tips.text = null;

        HidePassword = GameObject.Find("Show").GetComponent<Toggle>();
        HidePassword.isOn = true;
        HidePassword.onValueChanged.AddListener(ToggleOnValueChange); // �󶨼����¼�

        LoginButton = GameObject.Find("LoginButton").GetComponent<Button>();
        LoginButton.onClick.AddListener(OnButtonClick); // �󶨼����¼�
    }

    void OnButtonClick()
    {
        string username = UserName.text; // ��ȡ������û���
        string password = PassWord.text; // ��ȡ���������
        // �ж��û����������Ƿ���ȷ
        if (username == "123" && password == "234") 
        {
            Tips.text = "����ɹ���";
            // �����³���
            SceneManager.LoadScene("SchoolSceneDay");
        }
        else if(username == "123" && password != "234")
        {
            Tips.text = "�����������";
        }
        else
        {
            Tips.text = "�û�����������";
        }
    }  
    
    void ToggleOnValueChange(bool isOn)
    {
        if (isOn) // ��������
        {
            PassWord.contentType = InputField.ContentType.Password; // ��������
        }
        else
        {
            PassWord.contentType = InputField.ContentType.Standard; // ��ʾ����
        }
        
    }
}
