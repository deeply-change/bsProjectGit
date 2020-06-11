using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //移动用变量
    float moveX, moveZ;
    float currentSacale;
    [SerializeField]
    [Header("移动速度")]
    private float moveSpeed = 0.3f;
    [SerializeField]
    [Header("滚轮最大速度")]
    private float scalespeed = 2f;
    [SerializeField]
    [Header("滚轮最大速度")]
    private float min = -3f;
    [SerializeField]
    [Header("滚轮最小速度")]
    private float max = 3f;

    float rotationY;
    void Start()
    {
        moveX = 0f;
        moveZ = 0f;
        rotationY = transform.rotation.eulerAngles.y;
        currentSacale = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
       
        Move(); //移动控制
        Pick(); //射线选房间
    }
    private void Pick()
    {
        if (Input.GetMouseButtonDown(0)&&!SystemDate.Instance.isUIOpen)
        {
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            LayerMask layer = 1 << LayerMask.NameToLayer("Building");
            RaycastHit hit;
            GameObject Canvas = GameObject.Find("CanvasForButton").gameObject;

            if (Physics.Raycast(cameraRay, out hit, 100f, layer))
            {
                hit.collider.gameObject.SendMessage("SetButton",hit.collider.gameObject, SendMessageOptions.DontRequireReceiver);
                SystemDate.Instance.isUIOpen=true;
            }
          
        }
       
    }
    private void Move()
    {
    
        //滚轮移动镜头
        currentSacale = Input.mouseScrollDelta.y * scalespeed * Time.deltaTime;
        if (currentSacale != 0)currentSacale = Mathf.Clamp(currentSacale, min, max);
        transform.Translate(new Vector3(0, 0, currentSacale));
        if(transform.position.y<0) transform.Translate(new Vector3(0, 0, -currentSacale));
        else if(transform.position.y>=25) transform.Translate(new Vector3(0, 0, -currentSacale));
        //根据摄像机旋转WASD移动
        moveX = 0f;
        moveZ = 0f;
        if (Input.GetKey(KeyCode.D))
        {
            moveX -= Mathf.Sin((0-rotationY)* Mathf.Deg2Rad)* moveSpeed*Time.deltaTime;
            moveZ -= Mathf.Cos((0-rotationY) * Mathf.Deg2Rad) * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveX += Mathf.Sin((0-rotationY) * Mathf.Deg2Rad) * moveSpeed * Time.deltaTime;
            moveZ += Mathf.Cos((0-rotationY) * Mathf.Deg2Rad) * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveX -= Mathf.Sin(rotationY * Mathf.Deg2Rad) * moveSpeed * Time.deltaTime;
            moveZ -= Mathf.Cos(rotationY * Mathf.Deg2Rad) * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            moveX += Mathf.Sin(rotationY * Mathf.Deg2Rad) * moveSpeed * Time.deltaTime;
            moveZ += Mathf.Cos(rotationY * Mathf.Deg2Rad) * moveSpeed * Time.deltaTime;
        }

        //Camera.main.transform.position += new Vector3(moveX, 0f, moveZ);
        Vector3 memoryC = Camera.main.transform.position + new Vector3(moveX, 0f, moveZ);
        if (memoryC.x <= 40f && memoryC.x >= -15f && memoryC.z <= 40f && memoryC.z >= -15f)
        {
            Camera.main.transform.position += new Vector3(moveX, 0f, moveZ);
        }

    }
}

