using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FollowWorldObj : MonoBehaviour
{
    public GameObject worldPos;//3D物体（人物）
    public GameObject[] UIObj;//UI元素（如：血条等）
    public Vector2[] offset;//偏移量
    public int state;
    public GameObject[] mUIObj;
    public enum UIFollow
    {
        None,
        Wait,
        Set,
        Draw,
    }
    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case (int)UIFollow.None:
               for(int i = 0; i < mUIObj.Length; i++)
                {
                    if (mUIObj[i]) Destroy(mUIObj[i]);
                }
                state++;
            break;
            case (int)UIFollow.Wait:          
                break;
            case (int)UIFollow.Draw:
                {
                    for (int i = 0; i < offset.Length; i++)
                    {
                        Vector2 screenPos = Camera.main.WorldToScreenPoint(worldPos.transform.position);
                        mUIObj[i].GetComponent<RectTransform>().position = screenPos + offset[i];
                    }
                        break;
                }
        }
    }

    public void ClearButton()
    {
        for (int i = 0; i < mUIObj.Length; i++)
        {
            if (mUIObj[i]) Destroy(mUIObj[i]);
        }
    }
}
