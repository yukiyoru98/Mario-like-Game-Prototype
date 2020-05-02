using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public static CameraCtrl self; 
    private void Awake() {
        self = this;
    }
    float min = -3; //min value of camera's x position
    float max = 15; //max value of camera's x position

    public Transform PlayerPosition; //record Player's position

    private void Update(){
        float tmpX = Mathf.Clamp(PlayerPosition.localPosition.x, min, max); //camera follows player, but is limited in order not to get out of the scene's background
        transform.localPosition = new Vector3(tmpX, -2.954f, -10);
    }
}
