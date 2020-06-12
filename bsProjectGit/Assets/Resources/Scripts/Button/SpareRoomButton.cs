using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpareRoomButton : MonoBehaviour
{
    //public GameObject room;
    private RoomButtonMenuCloseButton MenuBtn;
    private SystemData data;
    private void Awake()
    {
        data = SystemData.Instance;
        GetComponent<Button>().onClick.AddListener(ChangeRoom);
        MenuBtn = GameObject.Find("CanvasForButton").transform.Find("RoomButtonMenu/Close").GetComponent<RoomButtonMenuCloseButton>();
    }
    void Start()
    {

    }

    public void ChangeRoom()
    {
        //在空地点击了空房间按钮使其成为空房间
        if (data.CeckMoney(SpareRoom.costMoney))
        {
            data.ReduceMoney(SpareRoom.costMoney);
            GameObject fakeroom = Instantiate(Resources.Load("Prefab/Room/SpareRoom") as GameObject, SystemData.Instance.roomData.transform.position, SystemData.Instance.roomData.transform.rotation);
            fakeroom.name = "SpareRoom";
            fakeroom.transform.localScale = new Vector3(fakeroom.transform.localScale.x, 5f, fakeroom.transform.localScale.z);
            fakeroom.transform.position = new Vector3(fakeroom.transform.position.x, fakeroom.transform.localScale.y / 2, fakeroom.transform.position.z);
            Destroy(SystemData.Instance.roomData);
            MenuBtn.Close();
        }
        else MenuBtn.Close();
    }
}
