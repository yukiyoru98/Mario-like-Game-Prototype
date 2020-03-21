using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCtrl : MonoBehaviour
{
    public Text TimeText;
    public static TimeCtrl self;
    private void Awake()
    {
        self = this;
    }
    private int MaxTime = 3;
    private int CurrentTime;
    private int MaxLength = 3;
    private char PadZero = '0';

    private void Start()
    {
        CurrentTime = MaxTime;
    }

    private void Update()
    {
        if (CurrentTime <= 0)
        {
            Debug.Log("Time Up");
        }
        else
        {
            CurrentTime = MaxTime - (int)Time.time;
        }
        TimeText.text = (CurrentTime.ToString()).PadLeft(MaxLength, PadZero);
    }
}
