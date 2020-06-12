using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemData : MonoBehaviour
{

    public  bool isUIOpen;
    private int money;  //金钱
    private int sales;  //销量
    private int popularity; //人气
    //单例
    public static SystemData Instance;
    public int SpareRoomBtnNum;
    public GameObject roomData;
   
    private GameObject[] buttons;
    private int reallyTime= 10; //现实时间 10就是现实10秒游戏10分钟
    private float minute;
    private int hour;
    private int month;
    private int week;
    private int year;

    private float makeFilmMaxTime ;//一天时间做游戏
    public void Awake()
    {
        Instance = this;
        SpareRoomBtnNum = 11;
        isUIOpen = false;
        money = 500;
        sales = 0;
        popularity = 0;
        minute = 0;
        hour = 0;
        month = 0;
        week = 0;
        year = 0;
        makeFilmMaxTime = 1f;
    }
    private void Update()
    {
        TimeRun();
    }
    //SetGet
    public int Money {set { value = money;} get{return money; } }
    public int Sales { set { value = sales; } get { return sales; } }
    public float Minute { set { value = minute; } get { return minute; } }
    public int Popularity { set { value = popularity; } get { return popularity; } }
    public int Hour { set { value = hour; } get { return hour; } }
    public int Month { set { value = month; } get { return month; } }
    public int Week { set { value = week; } get { return week; } }
    public int Year { set { value = year; } get { return year; } }
    public int ReallyTime { get { return reallyTime; } }
    public float MakeFilmMaxTime { get { return makeFilmMaxTime; } }
    public bool CeckMoney(int cos)
    {
        if ((money - cos) >= 0) return true;
        else return false;
    }

    public bool ReduceMoney(int cos)
    {
        if ((money - cos) >= 0)
        {
            money -= cos;
            return true;
        }
        else return false;
    }
    //设定按钮grid
    public  void SetGrid(int BtnNum,string[] roomNameEnglish, string[] roomName,int[]changeRoomMoney,GameObject grid,GameObject targetObj)
    {
        buttons = new GameObject[BtnNum];
        for (int i = 0; i < SystemData.Instance.SpareRoomBtnNum; i++)
        {
            buttons[i] = Instantiate(Resources.Load("Prefab/UI/BuildingSetButton") as GameObject);//读取按钮prefab
            buttons[i].transform.SetParent(grid.transform);
            buttons[i].GetComponent<RectTransform>().localScale = Vector3.one;
            buttons[i].transform.GetChild(0).GetComponent<Text>().text = roomName[i];//按钮文字设定
            buttons[i].name = roomNameEnglish[i];
            buttons[i].AddComponent<SpareAttributeButton>();//为按钮添加脚本
            //Button[i].GetComponent<SpareAttributeButton>().room = this.gameObject;//指定建筑物
            SystemData.Instance.roomData = targetObj;
            buttons[i].GetComponent<SpareAttributeButton>().attribute = roomNameEnglish[i];     //属性赋值
            buttons[i].GetComponent<SpareAttributeButton>().cosMoney = changeRoomMoney[i];  //花费金钱赋值
        }
    }
     private void TimeRun()
    {
        minute += (Time.deltaTime/reallyTime);
        if (minute >= 6)
        {
            minute = 0;
            hour += 1;
        }
        if (hour >= 24)
        {
            hour = 0;
            week += 1;
        }
        if (week >= 4)
        {
            week = 0;
            month += 1;
        }
        if (month >= 12)
        {
            month = 0;
            year += 1;
        }
    }
}
