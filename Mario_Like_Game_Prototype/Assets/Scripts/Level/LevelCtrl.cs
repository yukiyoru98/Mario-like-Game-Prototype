using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCtrl : MonoBehaviour
{
    public Text LifeNumText;
    public Text LevelNumText;
    private void Start() {
        //setup Level Text
        int level = PlayerDataManager.self.data.LevelNum;
        LevelNumText.text = (level / 8 + 1).ToString() + "-" + (level % 8 + 1).ToString();
        //setup Life Text
        LifeNumText.text = "x " + PlayerDataManager.self.data.CurrentLife.ToString();
        //Change Scene
        Invoke("Go", 2.0f);
    }

    void Go(){
        LoadingScenes.self.ChangeScene("Main", 1.0f);
    }
}
