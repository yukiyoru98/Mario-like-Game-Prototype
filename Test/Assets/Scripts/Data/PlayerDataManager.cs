using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public PlayerData data;
    public static PlayerDataManager self;
    private void Awake() {
        self = this;    
    }

    private void Start() {
        data.Setup();
    }
    public void Save(){
        this.gameObject.GetComponent<SaveData>().Save(data);
    }
}
