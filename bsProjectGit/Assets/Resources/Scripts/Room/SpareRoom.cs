using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpareRoom : MonoBehaviour
{
 
    GameObject[] Button;
    public static int costMoney = 20;
    GameObject menu;
    GameObject grid;
    int ButNum;
    public static string[] roomName =
    {
        "电车 花费:10",
        "公厕 花费:20",
        "温泉 花费:30",
        "小屋 花费:40",
        "办公室 花费:50",
        "爱情旅馆 花费:60",
        "野外 花费:70",
        "海滩 花费:80",
        "洞穴 花费:90",
        "校园 花费:100",
        "天台 花费:110",
    };
    public static string[] roomNameEnglish =
    {
        "denche",
        "gongce",
        "wenquan",
        "xiaowu",
        "bangongshi",
        "waiqinglvguan",
       "dyewai",
        "haitan",
        "dongxue",
       "xiaoyuan",
        "tiantai",
    };
    public static int[] ChangeRoomMoney =
    {
        10,20,30,40,50,60,70,80,90,100,110
    };
    void Start()
    {
        ButNum = 11;
        Button = new GameObject[SystemData.Instance.SpareRoomBtnNum]; 
        menu = GameObject.Find("CanvasForButton").transform.Find("RoomButtonMenu").gameObject;
        grid = menu.transform.Find("Scroll View/Viewport/Grid").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetButton()
    { 
        //打开赋予属性菜单
        menu.SetActive(true);//开启菜单
        SystemData.Instance.SetGrid(ButNum, roomNameEnglish, roomName, ChangeRoomMoney, grid,this.gameObject);
    }
}
