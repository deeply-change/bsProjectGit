using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpareAttributeButton : MonoBehaviour
{
    //public GameObject room;
    public string attribute;
    public int cosMoney;
    private RoomButtonMenuCloseButton MenuBtn;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ChangeRoom);
        MenuBtn = GameObject.Find("CanvasForButton").transform.Find("RoomButtonMenu/Close").GetComponent<RoomButtonMenuCloseButton>();

    }

    //点击空房间的按钮赋予空房间属性
    private void ChangeRoom()
    {
        GameObject menu = this.transform.root.transform.Find("RoomButtonMenu").gameObject;
        SystemData.Instance.isUIOpen = false;
        GameObject room = SystemData.Instance.roomData;
        if (SystemData.Instance.CeckMoney(cosMoney))//检查是否够钱
        {
            SystemData.Instance.ReduceMoney(cosMoney);//扣钱
            if (room.GetComponent<SpareRoom>())
            {
                Destroy(room.GetComponent<SpareRoom>());//删除原先脚本
            }
            //如果是空房子增加属性
            if (!room.GetComponent<SpareAttributeButton>()&& !room.GetComponent<SpareRoomWithAttribute>())
            {
                room.AddComponent<SpareRoomWithAttribute>();//添加带属性的脚本
                room.GetComponent<SpareRoomWithAttribute>().attribute = attribute;//传递属性
                if (room.GetComponent<MeshRenderer>().material.color == Color.red) room.GetComponent<MeshRenderer>().material.color = Color.green;
                else room.GetComponent<MeshRenderer>().material.color = Color.red;
                room.name = attribute;
            }
            //如果是带属性的房子转属性
            else if (room.GetComponent<SpareRoomWithAttribute>()&& !room.GetComponent<SpareAttributeButton>())
            {
                room.GetComponent<SpareRoomWithAttribute>().attribute = attribute;//传递属性
                if (room.GetComponent<MeshRenderer>().material.color == Color.red) room.GetComponent<MeshRenderer>().material.color = Color.green;
                else room.GetComponent<MeshRenderer>().material.color = Color.red;
                room.name = attribute;
            }
            MenuBtn.Close();
            //关闭当前菜单
            //menu.SetActive(false);

        }
        else MenuBtn.Close();
        //menu.SetActive(false);
    }
}
