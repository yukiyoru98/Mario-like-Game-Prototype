using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPCtrl : MonoBehaviour
{
    public static HPCtrl self;
    public List<GameObject> HPImage = new List<GameObject>();
    private void Awake() {
        self = this;
    }

    private const string HPPrefabPath = "Prefabs/HP";
    private float Distance = 75f;

    private void Start() {
        //create HP UI 
        for(int i=0; i<PlayerData.self.MaxHP; i++){
            GameObject hp = Instantiate(Resources.Load(HPPrefabPath), transform) as GameObject;
            hp.transform.localPosition += new Vector3(Distance * i, 0, 0);
            hp.name = "HP" + (i+1);
            HPImage.Add(hp);
        }
    }

    public void LoseHP(int hp){
        PlayerData.self.LoseHP(hp);
        HPImage[PlayerData.self.CurrentHP].GetComponent<Animation>().Play("HP-Lose");
    }
}
