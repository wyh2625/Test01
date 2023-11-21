using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    private Player PlayerCS; // Player脚本
    private Animator OpenDoorAnim; // 右门的动画控制器组件Animator
    public string Name; // 门的名字
    public bool isLeftDoor = true; // 是左门还是右门

    void Start()
    {
        PlayerCS = GameObject.Find("Player").GetComponent<Player>(); // 获取脚本
        OpenDoorAnim = transform.GetComponent<Animator>(); // 获取Animator组件
    }

    void Update()
    {
        // 左门，右门播放不同的动画
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
