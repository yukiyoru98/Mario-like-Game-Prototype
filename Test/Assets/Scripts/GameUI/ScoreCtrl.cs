using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCtrl : MonoBehaviour
{
    public Text ScoreNumText;
    public static ScoreCtrl self;
    private void Awake(){
        self = this;
    }

    private int ScoreNum = 0;
    private int MaxLength = 5;
    private char PadZero = '0';

    public void AddScore(int score){
        ScoreNum += score;
        ScoreNumText.text = ScoreNum.ToString().PadLeft(MaxLength, PadZero);
    }
}
