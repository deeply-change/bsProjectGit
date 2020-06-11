using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpareRoomButton : MonoBehaviour
{
    public GameObject room;
    private MenuCloseButton MenuBtn;
    private SystemDate date;
    private void Awake()
    {
        date = SystemDate.Instance;
        GetComponent<Button>().onClick.AddListener(ChangeRoom);
        MenuBtn = GameObject.Find("CanvasForButton").transform.Find("Menu/Close").GetComponent<MenuCloseButton>();
    }
    void Start()
    {

    }

    public void ChangeRoom()
    {
        if (date.CeckMoney(SpareRoom.costMoney))
        {
            date.ReduceMoney(SpareRoom.costMoney);
            GameObject fakeroom = Instantiate(Resources.Load("Prefab/Room/SpareRoom") as GameObject, room.transform.position, room.transform.rotation);
            fakeroom.name = "SpareRoom";
            fakeroom.transform.localScale = new Vector3(fakeroom.transform.localScale.x, 5f, fakeroom.transform.localScale.z);
            fakeroom.transform.position = new Vector3(fakeroom.transform.position.x, fakeroom.transform.localScale.y / 2, fakeroom.transform.position.z);
            Destroy(room);
            MenuBtn.Close();
        }
        else MenuBtn.Close();
    }
}
