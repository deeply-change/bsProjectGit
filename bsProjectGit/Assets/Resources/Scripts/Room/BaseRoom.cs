using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class BaseRoom : MonoBehaviour
{
    int buttonNum;
    GameObject[] Button;
    // Start is called before the first frame update
    void Start()
    {
        buttonNum = 5;
        Button = new GameObject[buttonNum];
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetButton()
    {
        GameObject menu=GameObject.Find("CanvasForButton").transform.Find("RoomButtonMenu").gameObject;
        GameObject grid = menu.transform.Find("Scroll View/Viewport/Grid").gameObject;
        menu.SetActive(true);//开启菜单

        for (int i=0;i< buttonNum; i++)
        {
            Button[i] = Instantiate(Resources.Load("Prefab/UI/BuildingSetButton") as GameObject);
            Button[i].transform.SetParent(grid.transform);
            Button[i].GetComponent<RectTransform>().localScale = Vector3.one;
        }
        SystemData.Instance.roomData = this.gameObject;
        //决定按钮名字
        Button[0].transform.GetChild(0).GetComponent<Text>().text = "空房子";
        Button[0].name = "SpareRoom";
        Button[0].AddComponent<SpareRoomButton>();

        Button[1].transform.GetChild(0).GetComponent<Text>().text = "制片室";
        Button[1].name = "zhipianshi";
        Button[2].transform.GetChild(0).GetComponent<Text>().text = "休息室";
        Button[2].name = "xiuxishi"; 
        Button[3].transform.GetChild(0).GetComponent<Text>().text = "外派室";
        Button[3].name = "waipaishi";
        Button[4].transform.GetChild(0).GetComponent<Text>().text = "办公室";
        Button[4].name = "bangongshi";
    }
}
