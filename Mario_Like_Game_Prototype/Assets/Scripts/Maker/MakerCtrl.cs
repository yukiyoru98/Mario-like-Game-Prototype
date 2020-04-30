using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakerCtrl : MonoBehaviour //Maker/SceneObjects/Maker
{
    public static MakerCtrl self;
    private void Awake() {
        self = this;
    }
    private int TargetIdx = 0; //the child index of currently displaying object
    public GameObject Target; //currently displaying object
    private int ObjCount;

    private void Start() {
        ObjCount = this.transform.childCount;
        Target = transform.GetChild(TargetIdx).gameObject;
        Target.SetActive(true);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Z)){
            Switch(-1);
        }
        if(Input.GetKeyDown(KeyCode.X)){
            Switch(1);
        }
    }

    void Switch(int next){
        Target.SetActive(false);
        TargetIdx += next;
        if(TargetIdx < 0){
            TargetIdx = ObjCount;
        }
        else if(TargetIdx == ObjCount ){
            TargetIdx = 0;
        }
        Target = transform.GetChild(TargetIdx).gameObject;
        Target.SetActive(true);
    }
}
