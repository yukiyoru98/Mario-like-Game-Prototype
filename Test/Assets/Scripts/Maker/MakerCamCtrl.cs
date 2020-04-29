using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakerCamCtrl : MonoBehaviour //Maker/MainCamPosition
{
    public static MakerCamCtrl self;
    private void Awake() {
        self = this;
    }
    float min = -3; //min value of camera's x position
    float max = 15; //max value of camera's x position

    public void CamMove()
    {
        float tmpX = Mathf.Clamp(MakerMoveCtrl.self.transform.position.x, min, max); //camera follows Maker, but is limited in order not to get out of the scene's background
        transform.localPosition = new Vector3(tmpX, -2.954f, -10);
    }

}
