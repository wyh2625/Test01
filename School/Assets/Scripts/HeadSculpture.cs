using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadSculpture : MonoBehaviour
{
    private Text playerName;  // 游戏名称
    private Image headSculpture; // 头像图片
    
    void Start()
    {
        playerName = GameObject.Find("Name").GetComponent<Text>(); // 获取Text组件
        playerName.horizontalOverflow = HorizontalWrapMode.Overflow; // 横向允许超出文本框
        //playerName.text = Login.Instance.PlayerName.text; // 将登入界面的名字复制到游戏界面

        // 获取组件
        headSculpture = GameObject.Find("head_img").GetComponent<Image>();
        string index = Random.Range(1, 6).ToString(); // 随机产生一个数
        
        // 异步加载资源。它允许您在后台加载资源而不会阻塞主线程执行。
        // 在Resources 文件夹中，图片为Sprite，图片名称为1,2,3,4,5
        ResourceRequest resourceRequest = Resources.LoadAsync<Sprite>(index);
        headSculpture.sprite = resourceRequest.asset as Sprite; // 赋值
    }
}
