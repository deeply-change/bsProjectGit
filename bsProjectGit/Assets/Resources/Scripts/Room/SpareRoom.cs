using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpareRoom : MonoBehaviour
{
    int buttonNum;
    GameObject[] Button;
    public static int costMoney = 20;
    string[] roomName =
    {
        "电车 花费:X",
        "公厕 花费:X",
        "温泉 花费:X",
        "电车 花费:X",
        "公厕 花费:X",
        "温泉 花费:X",
        "电车 花费:X",
        "公厕 花费:X",
        "温泉 花费:X",
        "公厕 花费:X",
        "温泉 花费:X",
    };
    string[] roomNameEnglish =
    {
        "denche",
        "gongce",
        "wenquan",
        "denche",
        "gongce",
        "wenquan",
       "denche",
        "gongce",
        "wenquan",
       "denche",
        "gongce",
    };
    void Start()
    {
        buttonNum = 11;
        Button = new GameObject[buttonNum];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetButton(GameObject go)
    {
        GameObject menu = GameObject.Find("CanvasForButton").transform.Find("Menu").gameObject;
        GameObject grid = menu.transform.Find("Scroll View/Viewport/Grid").gameObject;
        menu.SetActive(true);//开启菜单

        for (int i = 0; i < buttonNum; i++)
        {
            Button[i] = Instantiate(Resources.Load("Prefab/UI/BuildingSetButton") as GameObject);
            Button[i].transform.SetParent(grid.transform);
            Button[i].GetComponent<RectTransform>().localScale = Vector3.one;
            Button[i].transform.GetChild(0).GetComponent<Text>().text = roomName[i];
            Button[i].name = roomNameEnglish[i];
        }

        Button[0].AddComponent<SpareRoomButton>();
        Button[0].GetComponent<SpareRoomButton>().room = this.gameObject;
      
    }
}
