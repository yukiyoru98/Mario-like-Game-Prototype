using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCtrl : MonoBehaviour
{
    public static PauseCtrl self;
    private void Awake() {
        self = this;
    }

    public bool isPaused = false;
    public float TrueTime; //record true time of the level(response to pause)
    
    private void Start() {
        TrueTime = 0; //reset time when the scene starts
    }

    private void Update() {
        if(!isPaused){
            TrueTime += Time.deltaTime; //update time when not paused
        }
    }

    public void Pause(bool p){
        isPaused = p;
        //TODO:Game Pause UI
         
    }

    public void ResetTrueTime(){
        TrueTime = 0;
    }
}
