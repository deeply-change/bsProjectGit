using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class RoomButtonMenuCloseButton : MonoBehaviour
{
    GameObject button;
    private void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(Close);
    }

    public void Close()
    {

        SystemData.Instance.isUIOpen = false;
        SystemData.Instance.roomData = null;
        GameObject grid = this.transform.parent.transform.Find("Scroll View/Viewport/Grid").gameObject;
        for (int i=0;i < grid.transform.childCount; i++)
        {
            Destroy(grid.transform.GetChild(i).gameObject);       
        }
        this.transform.parent.gameObject.SetActive(false);
    }
}
