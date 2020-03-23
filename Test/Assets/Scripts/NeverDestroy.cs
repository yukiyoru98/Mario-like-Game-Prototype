using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeverDestroy : MonoBehaviour
{
    public List<GameObject> NeverDestroyObj = new List<GameObject>();
    private bool OnceBool = false;
    private void Awake() {
        if(!OnceBool){
            for(int i=0; i<NeverDestroyObj.Count; i++){
                DontDestroyOnLoad(Instantiate(NeverDestroyObj[i]) as GameObject);
            }
            OnceBool = true;
        }
    }
}
