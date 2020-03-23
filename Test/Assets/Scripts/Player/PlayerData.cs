using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int HP = 100;
    public int MaxHP = 3;
    public int CurrentHP;
    public int Money = 0;
    public bool Power = false;

    public static PlayerData self;
    private void Awake() {
        self = this;    
    }

    private void Start() {
        CurrentHP = MaxHP;
    }
    public void EarnMoney(int money){
        Money += money;
        if(Money > 99){
            Money = 1;
        }
    }

    public void LoseHP(int hp){
        CurrentHP -= hp;
        if(CurrentHP < 0){
            CurrentHP = 0;
        }
    }
}
