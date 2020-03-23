using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCtrl : MonoBehaviour
{
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Return)){
            LoadingScenes.self.ChangeScene("Level", 0.5f);
        }    
    }
}
