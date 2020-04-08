using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeverDestroy : MonoBehaviour
{
    public List<GameObject> NeverDestroyObj = new List<GameObject>();
    public static bool OnceBool = false; //note that this must be static!!or it will be reset in every scene
    private void Awake() {
        if(!OnceBool){
            for(int i=0; i<NeverDestroyObj.Count; i++){
                DontDestroyOnLoad(Instantiate(NeverDestroyObj[i]) as GameObject);
            }
            OnceBool = true;
        }
    }
}
