using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMapCtrl : MonoBehaviour
{
    private const string DataPath = "Data/Scene/Level";
    private const string SceneObjPath = "Prefabs/SceneObjects/";
    private string[] SceneObjName = new string[] { "", "Coin_Root", "Block_Root", "Enemy_Root", "CoinBlock_Root", "Player_Root" };
    private List<GameObject> Obj = new List<GameObject>();
    private void Awake()
    {

    }

    private void Start()
    {
        LoadMap();
    }

    void LoadMap()
    {
        string data = Resources.Load<TextAsset>(DataPath + "1").text;
        string[] Row = data.Split('\n');
        for (int y = 0; y < Row.Length; y++)
        {
            string[] Col = Row[y].Split(',');
            for (int x = 0; x < Col.Length; x++)
            {
                int ID = int.Parse(Col[x]);
                
                if (ID != 0)
                {
                    GameObject obj = Instantiate(Resources.Load(SceneObjPath + SceneObjName[ID]), transform) as GameObject;
                    obj.name = SceneObjName[ID];
                    obj.transform.localPosition = new Vector3(x, y, 0);
                    Obj.Add(obj);
                    if(ID == 5){
                        obj.transform.parent = null; 
                        CameraCtrl.self.PlayerPosition = obj.transform;
                    }
                }
            }
        }
    }
}
