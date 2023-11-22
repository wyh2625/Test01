using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    private Player PlayerCS; // Player�ű�
    private Animator DoorAnim; // ���ŵĶ������������Animator
    public string Name; // �ŵ�����
    public bool isLeftDoor = true; // �����Ż�������
    private float distance; // ��������Z��ľ���

    void Start()
    {
        PlayerCS = GameObject.Find("Player").GetComponent<Player>(); // ��ȡ�ű�
        DoorAnim = transform.GetComponent<Animator>(); // ��ȡAnimator���
    }

    void Update()
    {
        // �ж��������ŵ�λ�ã����������ߣ����Ǵ���������
        distance = PlayerCS.transform.position.z - transform.position.z;

        // ���ţ����Ų��Ų�ͬ�Ķ���
        if (PlayerCS.isOpenDoor && PlayerCS.hitInfo.collider.name == Name && isLeftDoor && distance < 0)
        {
            DoorAnim.Play("OpenLeftDoor");
            StartCoroutine(CloseDoor());
        }

        if (PlayerCS.isOpenDoor && PlayerCS.hitInfo.collider.name == Name && !isLeftDoor && distance < 0)
        {
            DoorAnim.Play("OpenRightDoor");
            StartCoroutine(CloseDoor());
        }

        if (PlayerCS.isOpenDoor && PlayerCS.hitInfo.collider.name == Name && isLeftDoor && distance > 0)
        {
            DoorAnim.Play("InOpenLeftDoor");
            StartCoroutine(CloseDoor());
        }

        if (PlayerCS.isOpenDoor && PlayerCS.hitInfo.collider.name == Name && !isLeftDoor && distance > 0)
        {
            DoorAnim.Play("InOpenRightDoor");
            StartCoroutine(CloseDoor());
        }
    }

    IEnumerator CloseDoor()
    {
        // �ȴ�3s
        yield return new WaitForSeconds(3);
        if (distance < 0) // ����������
        {
            if (isLeftDoor) // ����
            {
                DoorAnim.Play("CloseLeftDoor");
            }
            else // ����
            {
                DoorAnim.Play("CloseRightDoor");
            }
        }
        else // ����������
        {
            if (isLeftDoor) // ����
            {
                DoorAnim.Play("InCloseLeftDoor");
            }
            else // ����
            {
                DoorAnim.Play("InCloseRightDoor");
            }
        }
    }
}
