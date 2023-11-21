using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMap : MonoBehaviour
{
    private Transform player; // ���Player
    private Vector3 offSet; // ��������һ��ƫ����
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        // ����λ�ú���ת
        transform.position = player.position + offSet;
        transform.eulerAngles = new Vector3(0, player.eulerAngles.y, 0);
    }
}
