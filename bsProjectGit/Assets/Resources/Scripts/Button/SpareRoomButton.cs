using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpareRoomButton : MonoBehaviour
{
    public GameObject room;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ChangeRoom);
    }
    void Start()
    {

    }

    public void ChangeRoom()
    {
        Instantiate(Resources.Load("Prefab/Room/SpareRoom") as GameObject, room.transform.position, room.transform.rotation).name="SpareRoom";
        Destroy(room);
        GameObject.Find("CanvasForButton").GetComponent<FollowWorldObj>().ClearButton();
    }
}
