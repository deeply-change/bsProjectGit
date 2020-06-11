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
        buttonNum = 2;
        Button = new GameObject[buttonNum];
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetButton(GameObject go)
    {
        GameObject menu=GameObject.Find("CanvasForButton").transform.Find("Menu").gameObject;
        GameObject grid = menu.transform.Find("Scroll View/Viewport/Grid").gameObject;
        menu.SetActive(true);//开启菜单

        for (int i=0;i< buttonNum; i++)
        {
            Button[i] = Instantiate(Resources.Load("Prefab/UI/BuildingSetButton") as GameObject);
            Button[i].transform.SetParent(grid.transform);
            Button[i].GetComponent<RectTransform>().localScale = Vector3.one;
        }

        Button[0].transform.GetChild(0).GetComponent<Text>().text = "空房子";
        Button[0].name = "SpareRoom";
        //空房间
        Button[0].AddComponent<SpareRoomButton>();
        Button[0].GetComponent<SpareRoomButton>().room = this.gameObject;
        Button[1].transform.GetChild(0).GetComponent<Text>().text = "制片房";
    }
}
