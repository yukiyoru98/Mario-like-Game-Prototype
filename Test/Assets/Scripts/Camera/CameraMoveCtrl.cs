using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMoveCtrl : MonoBehaviour
{
    float Duration = 3f;
    private void Start() {
        this.gameObject.GetComponent<CameraCtrl>().enabled = false; //deactivate CameraCtrl to stop camera from following the player
        PauseCtrl.self.isPaused = true; //pause the game first
        transform.localPosition = new Vector3(LevelData.self.CamXRange.y, -2.954f, -10); //set initial position at end of map
        transform.DOMoveX(LevelData.self.CamXRange.x, Duration); //move to start point

        Invoke("GO", Duration + 1f);
    }

    void GO(){
        this.gameObject.GetComponent<CameraCtrl>().enabled = true; //activate the camera
        PauseCtrl.self.isPaused = false; //start the game
    }
}
