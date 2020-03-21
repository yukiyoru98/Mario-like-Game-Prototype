using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int HP = 100;
    public int MaxLife = 3;
    public int CurrentLife;
    public int Money = 0;
    public bool Power = false;

    public static PlayerData self;
    private void Awake() {
        self = this;    
    }

    private void Start() {
        CurrentLife = MaxLife;
    }
    public void EarnMoney(int money){
        Money += money;
        if(Money > 99){
            Money = 1;
        }
    }

    public void LoseLife(int life){
        CurrentLife -= life;
        if(CurrentLife < 0){
            CurrentLife = 0;
        }
    }
}
