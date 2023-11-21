using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 3f; // ��ɫ�ƶ��ٶ�
    private float rotateSpeed = 60f; // ��ɫ��ת�ٶ�
    private LayerMask DoorLayer;  // �㼶��outSide
    public bool isOpenDoor; // �Ƿ���
    private float raycastDistance = 2f;  // ���߷���ľ���
    public RaycastHit hitInfo; // ����һ��RaycastHit�����������汻ײ�������Ϣ
    private Animator PlayerAnim; // ���ﶯ��������

    void Start()
    {
        DoorLayer = LayerMask.GetMask("Door"); // ���ŵĲ㼶��ΪDoor
        PlayerAnim = transform.GetComponent<Animator>(); // ��ȡAnimator���
    }

    void Update()
    {
        // ����
        float horizontal = Input.GetAxis("Horizontal"); // ����1��-1
        float vertical = Input.GetAxis("Vertical");

        // ��ɫ���ƶ�����ת
        transform.Translate(new Vector3(0, 0, vertical* moveSpeed) * Time.deltaTime);
        transform.Rotate(new Vector3(0, horizontal * rotateSpeed, 0) * Time.deltaTime);

        // ��ɫ�ܶ�����ʱ���л��ܲ�����Running
        Vector3 move = new Vector3(0, 0, vertical);
        PlayerAnim.SetFloat("Speed", move.magnitude);

        // ��������
        Vector3 offSet = new Vector3(0, 1, 0); // ƫ����
        Ray ray = new Ray();
        ray.origin = transform.position + offSet;   //�������
        ray.direction = transform.forward; //���߷���
        isOpenDoor = Physics.Raycast(ray, out hitInfo, raycastDistance, DoorLayer);
        if (isOpenDoor) // ���Ŷ���
        {
            PlayerAnim.Play("Open_Door_Outwards");
        }
        // �������������
        //Debug.DrawRay(transform.position + offSet,
        //transform.forward * raycastDistance, Color.green);  
    }
}
