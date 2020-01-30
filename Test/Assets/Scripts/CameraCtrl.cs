using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    float min = -3;
    float max = 15;
    public Transform PlayerPosition;

    private void Start(){
        transform.localPosition = new Vector3(PlayerPosition.localPosition.x, -2.954f, -10); //y and z is fixed
    }

    private void Update(){
        float tmpX = Mathf.Clamp(PlayerPosition.localPosition.x, min, max);
        transform.localPosition = new Vector3(tmpX, -2.954f, -10);
    }
}
