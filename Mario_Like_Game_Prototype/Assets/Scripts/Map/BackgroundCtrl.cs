using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCtrl : MonoBehaviour
{
    private const string BG_Path = "Prefabs/SampleBackground";
    private void Start(){
        //create continuous background at the beginning
        for(int i=0; i<10; i++){
            GameObject bg = Instantiate(Resources.Load(BG_Path), this.transform) as GameObject;
            bg.transform.localPosition = new Vector3(i * 10, 0, 0);
        }
       
    }
}
