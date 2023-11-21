using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadSculpture : MonoBehaviour
{
    private Text playerName;  // ��Ϸ����
    private Image headSculpture; // ͷ��ͼƬ
    
    void Start()
    {
        playerName = GameObject.Find("Name").GetComponent<Text>(); // ��ȡText���
        playerName.horizontalOverflow = HorizontalWrapMode.Overflow; // �����������ı���
        //playerName.text = Login.Instance.PlayerName.text; // �������������ָ��Ƶ���Ϸ����

        // ��ȡ���
        headSculpture = GameObject.Find("head_img").GetComponent<Image>();
        string index = Random.Range(1, 6).ToString(); // �������һ����
        
        // �첽������Դ�����������ں�̨������Դ�������������߳�ִ�С�
        // ��Resources �ļ����У�ͼƬΪSprite��ͼƬ����Ϊ1,2,3,4,5
        ResourceRequest resourceRequest = Resources.LoadAsync<Sprite>(index);
        headSculpture.sprite = resourceRequest.asset as Sprite; // ��ֵ
    }
}
