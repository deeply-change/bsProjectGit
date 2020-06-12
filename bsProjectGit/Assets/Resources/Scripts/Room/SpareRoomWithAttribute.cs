using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpareRoomWithAttribute : MonoBehaviour
{
    SystemData data;
    public string attribute;
    private GameObject SRMMenu;  //SpareRoomMenu
    private GameObject SRMAttribute;
    private Text AttributeText;
    public bool isMakeFilm;

    private GameObject barUI;
    private Slider barSlider;
    private float rate;//制片进度
    // Start is called before the first frame update
    void Awake()
    {
        data = SystemData.Instance;
        isMakeFilm = false;
        SRMMenu = GameObject.Find("CanvasForButton").transform.Find("SpareRoomMenu").gameObject;
        SRMAttribute = SRMMenu.transform.Find("Attribute").gameObject;
        AttributeText = SRMAttribute.GetComponent<Text>();
        //Bar设置
        barUI = transform.Find("BarUI").gameObject;
        barSlider = barUI.transform.Find("MkaeFilmBar").GetComponent<Slider>();
        barSlider.value = 0f;
        rate = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMakeFilm)
        {
            barUI.SetActive(true);
            rate += Time.deltaTime / data.ReallyTime;
            barSlider.value = rate / data.MakeFilmMaxTime;
            if (rate == data.MakeFilmMaxTime)
            {
                barUI.SetActive(false);
                isMakeFilm = false;
                rate = 0f;
                barSlider.value = 0f;
            }
        }
    }

    //点击带属性的房间
    void SetButton()
    {
        data.roomData = this.gameObject;
        SRMMenu.SetActive(true);
        SRMMenu.GetComponent<SpareRoomMenuButton>().OpenAttributeUI();
        AttributeText.text = "属性:" + attribute;
    }
}