using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpareRoomMenuButton : MonoBehaviour
{
    GameObject closeBtn;  //关闭按钮

    private GameObject roomButtonMenu;//下拉菜单
    private GameObject grid;//下拉菜单子菜单
    private GameObject attribute;//属性文字
    private GameObject changeAttrBtn;//属性变更按钮
    private GameObject makeFilmBtn;//制作电影按钮
    private SystemData data;

    void Awake()
    {
        //关闭按钮
        closeBtn = transform.Find("Close").gameObject;
        closeBtn.GetComponent<Button>().onClick.AddListener(Close);
        //属性变更按钮
        changeAttrBtn = transform.Find("ChangeAttribute").gameObject;
        changeAttrBtn.GetComponent<Button>().onClick.AddListener(ChangeAttribute);
        //下拉菜单
        roomButtonMenu = transform.root.transform.Find("RoomButtonMenu").gameObject;
        grid = roomButtonMenu.transform.Find("Scroll View/Viewport/Grid").gameObject;
        //制作电影按钮
        makeFilmBtn = transform.Find("MakeFilm").gameObject;
        makeFilmBtn.GetComponent<Button>().onClick.AddListener(MakeFilm);
        attribute= transform.Find("Attribute").gameObject;
        data = SystemData.Instance;


    }

   
    //关闭菜单
    public void Close()
    {
        data.isUIOpen = false;
        data.roomData = null;
        this.transform.gameObject.SetActive(false);

    }
    //更改属性
    public void ChangeAttribute()
    {
        this.transform.gameObject.SetActive(false);
        data.SetGrid(data.SpareRoomBtnNum, SpareRoom.roomNameEnglish, SpareRoom.roomName, SpareRoom.ChangeRoomMoney, grid, data.roomData);
        roomButtonMenu.SetActive(true);
    }
    //制作电影
    public void MakeFilm()
    {
        this.gameObject.SetActive(false);
        CloseAttributeUI();
        data.isUIOpen = false;
        data.roomData.GetComponent<SpareRoomWithAttribute>().isMakeFilm = true;
    }

    //关闭状态UI
    public void CloseAttributeUI()
    {
        makeFilmBtn.SetActive(false);
        changeAttrBtn.SetActive(false);
        attribute.SetActive(false);
    }
    //开启状态UI
    public void OpenAttributeUI()
    {
        makeFilmBtn.SetActive(true);
        changeAttrBtn.SetActive(true);
        attribute.SetActive(true);
    }
}
