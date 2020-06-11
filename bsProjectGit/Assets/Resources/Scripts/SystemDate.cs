using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemDate : MonoBehaviour
{

    public  bool isUIOpen;
    private int money;  //金钱
    private int sales;  //销量
    private int popularity; //人气
    //单例
    private static readonly SystemDate _instance = new SystemDate();
    public static SystemDate Instance;
    

    private Text UImoney;
    private Text UIsales;
    private Text UIpopularity;
    private void Awake()
    {
        Instance = this;
        UImoney = this.transform.Find("Panel/Money").GetComponent<Text>();
        UIsales = this.transform.Find("Panel/Sales").GetComponent<Text>();
        UIpopularity = this.transform.Find("Panel/Popularity").GetComponent<Text>();

    }
    void Start()
    {
        isUIOpen = false;
        money = 500;
        sales = 0;
        popularity = 0;
    }
    private void Update()
    {
        UImoney.text = "金钱: " + money;
        UIsales.text = "销量: " + sales;
        UIpopularity.text = "人气: " + popularity;
    }
    public int SetGetMoney {set { value = money;} get{return money; } }

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

}
