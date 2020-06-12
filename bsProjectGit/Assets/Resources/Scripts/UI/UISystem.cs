using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UISystem : MonoBehaviour
{
    private Text UImoney;
    private Text UIsales;
    private Text UIpopularity;
    private Text UITime;
    SystemData system;
    void Start()
    {
        UImoney = this.transform.Find("Panel/Money").GetComponent<Text>();
        UIsales = this.transform.Find("Panel/Sales").GetComponent<Text>();
        UIpopularity = this.transform.Find("Panel/Popularity").GetComponent<Text>();
        UITime = this.transform.Find("Panel/Time").GetComponent<Text>();
        system = SystemData.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        UImoney.text = "金钱: " + system.Money;
        UIsales.text = "销量: " + system.Sales;
        UIpopularity.text = "人气: " + system.Popularity;
        UITime.text = system.Year + "年" + system.Month + "月" + system.Week + "周    " + system.Hour + "小时" + (int)system.Minute*10 + "分钟";      
    }
}
