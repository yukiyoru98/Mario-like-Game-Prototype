using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData
{
    public int InitialLife = 3;
    public int CurrentLife;
    public int MaxHP = 3;
    public int CurrentHP;
    public int Money = 0;
    public bool Power = false;
    public int LevelNum = 0;
    public void Setup() {
        CurrentHP = MaxHP;
        CurrentLife = InitialLife;
        while(Money > 99){
            Money -= 99;
            CurrentLife++;
        }
    }
    public void EarnMoney(int money){
        Money += money;
        while(Money > 99){
            Money -= 99;
            CurrentLife++;
        }
    }

    public void LoseHP(int hp){
        CurrentHP -= hp;
        if(CurrentHP < 0){
            CurrentHP = 0;
        }
    }

    public void NextLevel(){
        LevelNum++;
    }
}
