using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCtrl : MonoBehaviour
{
    public static LifeCtrl self;
    public List<GameObject> LifeImage = new List<GameObject>();
    private void Awake() {
        self = this;
    }

    private const string LifePrefabPath = "Prefabs/Life";
    private float Distance = 75f;

    private void Start() {
        //create Life UI 
        for(int i=0; i<PlayerData.self.MaxLife; i++){
            GameObject life = Instantiate(Resources.Load(LifePrefabPath), transform) as GameObject;
            life.transform.localPosition += new Vector3(Distance * i, 0, 0);
            life.name = "Life" + (i+1);
            LifeImage.Add(life);
        }
    }

    public void LoseLife(int life){
        PlayerData.self.LoseLife(life);
        LifeImage[PlayerData.self.CurrentLife].GetComponent<Animation>().Play("Life-Lose");
    }
}
