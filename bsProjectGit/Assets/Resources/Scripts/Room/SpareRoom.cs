using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpareRoom : MonoBehaviour
{
    int buttonNum;
    void Start()
    {
        buttonNum = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetButton(GameObject go)
    {
        FollowWorldObj Building = GameObject.Find("CanvasForButton").GetComponent<FollowWorldObj>();
        if (Building.state == (int)FollowWorldObj.UIFollow.Wait || go != Building.worldPos)
        {
            if (go != Building.worldPos) Building.ClearButton();
            //为按钮建立数组
            Building.worldPos = this.gameObject;
            Building.UIObj = new GameObject[buttonNum];
            Building.offset = new Vector2[buttonNum];
            Building.mUIObj = new GameObject[buttonNum];
            for (int i = 0; i < buttonNum; i++)
            {
                //读取prefab
                //Building.UIObj[i] = new GameObject();             
                Building.UIObj[i] = Resources.Load("Prefab/UI/BuildingSet") as GameObject;
                Building.offset[i] = new Vector2(40 * (i * buttonNum - 1), 5);
                //建立prefab
                //Building.mUIObj[i] = new GameObject();
                Building.mUIObj[i] = Instantiate(Building.UIObj[i], transform.position, transform.rotation);
                Building.mUIObj[i].transform.SetParent(GameObject.Find("CanvasForButton").gameObject.transform);
                Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
                Building.mUIObj[i].GetComponent<RectTransform>().position = screenPos + Building.offset[i];
            }
            Building.mUIObj[0].transform.GetChild(0).GetComponent<Text>().text = "不知道1";
            Building.mUIObj[0].name = "SpareRoom";
            Building.mUIObj[0].AddComponent<SpareRoomButton>();
            Building.mUIObj[0].GetComponent<SpareRoomButton>().room = this.gameObject;
            Building.mUIObj[1].transform.GetChild(0).GetComponent<Text>().text = "不知道2";

            Building.state = (int)FollowWorldObj.UIFollow.Draw;
        }

    }
}
