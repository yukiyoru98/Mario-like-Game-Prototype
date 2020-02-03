using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int HP = 100;
    public int Life = 3;
    public int Money = 0;
    public bool Power = false;

    public static PlayerData self;
    private void Awake() {
        self = this;    
    }

    public void EarnMoney(int money){
        Money += money;
    }
}
