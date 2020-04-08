using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMoveCtrl : MonoBehaviour
{
    public GameObject UI;
    float Duration = 3f;
    private void Start()
    {
        UI.SetActive(false); //hide UI
        this.gameObject.GetComponent<CameraCtrl>().enabled = false; //deactivate CameraCtrl to stop camera from following the player
        PauseCtrl.self.isPaused = true; //pause the game first
        CamMove();
        Invoke("GO", Duration + 1f);
    }

    void CamMove()
    {
        transform.localPosition = new Vector3(LevelData.self.CamXRange.y, -2.954f, -10); //set initial position at end of map
        transform.DOMoveX(LevelData.self.CamXRange.x, Duration); //move to start point

    }
    void GO()
    {
        UI.SetActive(true); //show UI
        this.gameObject.GetComponent<CameraCtrl>().enabled = true; //activate the camera
        PauseCtrl.self.isPaused = false; //start the game
    }
}
