using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataTemplate : MonoBehaviour
{
    public PlayerData data;
    private void Start() {
        SaveTemplate();
    }

    void SaveTemplate(){
        SaveData.self.Save(data);
    }
}
