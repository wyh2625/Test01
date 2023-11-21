using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    private Player PlayerCS; // Player�ű�
    private Animator OpenDoorAnim; // ���ŵĶ������������Animator
    public string Name; // �ŵ�����
    public bool isLeftDoor = true; // �����Ż�������

    void Start()
    {
        PlayerCS = GameObject.Find("Player").GetComponent<Player>(); // ��ȡ�ű�
        OpenDoorAnim = transform.GetComponent<Animator>(); // ��ȡAnimator���
    }

    void Update()
    {
        // ���ţ����Ų��Ų�ͬ�Ķ���
        if (PlayerCS.isOpenDoor && PlayerCS.hitInfo.collider.name == Name && isLeftDoor)
        {
            OpenDoorAnim.Play("OpenLeftDoor");
        }

        if (PlayerCS.isOpenDoor && PlayerCS.hitInfo.collider.name == Name  && !isLeftDoor)
        {
            OpenDoorAnim.Play("OpenRightDoor");
        }
    }
}
