using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int HP;
    public int Life;
    public int Money;
    public bool Power = false;

    public static PlayerData self;
    private void Awake() {
        self = this;    
    }

}
