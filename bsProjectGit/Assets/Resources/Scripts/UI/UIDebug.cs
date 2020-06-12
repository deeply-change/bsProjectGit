using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIDebug : MonoBehaviour
{
    public Rect UICube = new Rect(0, 240, 100, 50);
    public int fontSize = 15;
    protected GUIStyle style;
    public GUIStyleState styleState;
    
    void Start()
    {
        styleState.textColor = Color.red;
        style = new GUIStyle();
        style.fontSize = fontSize;
        style.normal = styleState;
    }

    // Update is called once per frame
    private void OnGUI()
    {
        GUI.Label(UICube, "isOpen:" + SystemData.Instance.isUIOpen, style);
        if (SystemData.Instance.roomData) GUI.Label(new Rect(0, 300, 100, 50), "roomData:" + SystemData.Instance.roomData.name, style);
        else GUI.Label(new Rect(0, 300, 100, 50), "roomData:Null", style);
    }
}
