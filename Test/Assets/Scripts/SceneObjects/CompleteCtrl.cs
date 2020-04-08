using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteCtrl : MonoBehaviour
{
    public static CompleteCtrl self;
    private void Awake() {
        self = this;
    }

    private bool CompleteBool = false;

    void Complete(){
        CompleteBool = true;
        PauseCtrl.self.Pause(true);
        PlayerCtrl.self.anim.SetBool("Running", false);
        PlayerCtrl.self.anim.SetBool("Ground", true);
        PlayerCtrl.self.anim.SetBool("JumpingUp", false);
        Debug.Log("Complete!");
        PlayerDataManager.self.Save();
        Invoke("GoToNextLevel", 2f);
    }

    void GoToNextLevel(){
        PlayerDataManager.self.data.NextLevel();
        LoadingScenes.self.ChangeScene("Level", 0.5f);
    }
}
