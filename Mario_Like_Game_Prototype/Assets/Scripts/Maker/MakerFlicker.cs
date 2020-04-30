using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakerFlicker : MonoBehaviour //Maker/SceneObjects/Maker
{
    private bool FlickerBool = true;
    private void Start() {
        Invoke("Flicker", 0.5f);
    }
    
    void Flicker(){
        FlickerBool = !FlickerBool;
        MakerCtrl.self.Target.SetActive(FlickerBool);
        Invoke("Flicker", 0.5f);
    }
}
