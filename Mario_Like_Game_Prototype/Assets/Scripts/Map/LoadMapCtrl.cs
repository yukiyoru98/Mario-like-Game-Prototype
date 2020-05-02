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
        for (int i = 0; i < Row.Length; i++)
        {
            string[] Col = Row[i].Split(',');
            for (int j = 0; j < Col.Length; j++)
            {
                int ID = int.Parse(Col[j]);
                print(ID);
                if (ID != 0)
                {
                    GameObject obj = Instantiate(Resources.Load(SceneObjPath + SceneObjName[ID]), transform) as GameObject;
                    obj.transform.localPosition = new Vector3(j, i, 0);
                    Obj.Add(obj);
                }
            }
        }
    }
}
