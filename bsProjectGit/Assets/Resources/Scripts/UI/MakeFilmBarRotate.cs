using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeFilmBarRotate : MonoBehaviour
{
    
    private void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
