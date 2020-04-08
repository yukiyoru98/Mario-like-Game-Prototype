using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    public Vector2 CamXRange;
    public int LevelTime;

    public static LevelData self;
    private void Awake() {
        self = this;
    }
    
}
