using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoinCtrl : MonoBehaviour
{
    public Text CoinNumText;
    public static UICoinCtrl self;
    private void Awake() {
        self = this;
    }

    private int Money = 0;
    private int MaxLength = 2;
    private char PadZero = '0';

    private void Start() {
        GetMoney(0); //setup coin num for UI at the beginning of the scene
    }
    public void GetMoney(int money){
        PlayerData.self.EarnMoney(money);
        Money = PlayerData.self.Money;
        CoinNumText.text = "x " + Money.ToString().PadLeft(MaxLength, PadZero);

    }

}
