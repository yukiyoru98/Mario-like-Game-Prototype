using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MakerCtrl : MonoBehaviour //Maker/SceneObjects/Maker
{
    public static MakerCtrl self;
    private void Awake() {
        self = this;
    }
    private int TargetIdx = 0; //the child index of currently displaying object
    public GameObject Target; //currently displaying object
    private int ObjCount;
    private int MapHeight;
    private int MapWidth;
    private int[,] Map;
    private GameObject [,] Obj;
    private const string DataPath = "Assets/Resources/Data/Scene/Level";

    private void Start() {
        MapHeight = (int)MakerMoveCtrl.self.YMoveRange.y + 1;
        MapWidth = (int)MakerMoveCtrl.self.XMoveRange.y + 1;

        Map = new int[MapWidth,MapHeight];
        Obj = new GameObject[MapWidth,MapHeight];

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
        if(Input.GetKeyDown(KeyCode.Space)){
            Place();
        }
        if(Input.GetKeyDown(KeyCode.Return)){
            SaveMap();
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

    void Place(){
        int ID = TargetIdx + 1;
        Vector3 Pos = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
        print(Pos);
        if( Obj[(int)Pos.x, (int)Pos.y] != null){
            Destroy(Obj[(int)Pos.x, (int)Pos.y]);
        }
        GameObject obj = Instantiate(Target, transform.parent.transform);
        obj.transform.localPosition = Pos;
        obj.SetActive(true);
        Obj[(int)Pos.x, (int)Pos.y] = obj;
        Map[(int)Pos.x, (int)Pos.y] = ID;
    }

    void SaveMap(){
        string data = "";
        for(int y=0; y<MapHeight; y++){
            for(int x=0; x<MapWidth; x++){
                data += Map[x, y].ToString();
                if(x != MapWidth - 1){ //not last column
                    data += ",";
                }
            }
            if(y != MapHeight - 1){ //not last column
                    data += "\n";
            }
        }
        print(data);
        File.WriteAllText(DataPath + "1" + ".txt", data);
        Debug.Log("Save Map!");
    }
}
