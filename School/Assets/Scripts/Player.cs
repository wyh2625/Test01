using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 3f; // 角色移动速度
    private float rotateSpeed = 60f; // 角色旋转速度
    private LayerMask DoorLayer;  // 层级，outSide
    public bool isOpenDoor; // 是否开门
    private float raycastDistance = 2f;  // 射线发射的距离
    public RaycastHit hitInfo; // 定义一个RaycastHit变量用来保存被撞物体的信息
    private Animator PlayerAnim; // 人物动画控制器

    void Start()
    {
        DoorLayer = LayerMask.GetMask("Door"); // 将门的层级改为Door
        PlayerAnim = transform.GetComponent<Animator>(); // 获取Animator组件
    }

    void Update()
    {
        // 输入
        float horizontal = Input.GetAxis("Horizontal"); // 返回1或-1
        float vertical = Input.GetAxis("Vertical");

        // 角色的移动和旋转
        transform.Translate(new Vector3(0, 0, vertical* moveSpeed) * Time.deltaTime);
        transform.Rotate(new Vector3(0, horizontal * rotateSpeed, 0) * Time.deltaTime);

        // 角色跑动起来时，切换跑步动画Running
        Vector3 move = new Vector3(0, 0, vertical);
        PlayerAnim.SetFloat("Speed", move.magnitude);

        // 发射射线
        Vector3 offSet = new Vector3(0, 1, 0); // 偏移量
        Ray ray = new Ray();
        ray.origin = transform.position + offSet;   //射线起点
        ray.direction = transform.forward; //射线方向
        isOpenDoor = Physics.Raycast(ray, out hitInfo, raycastDistance, DoorLayer);
        if (isOpenDoor) // 开门动画
        {
            PlayerAnim.Play("Open_Door_Outwards");
        }
        // 描绘出发射的射线
        //Debug.DrawRay(transform.position + offSet,
        //transform.forward * raycastDistance, Color.green);  
    }
}
