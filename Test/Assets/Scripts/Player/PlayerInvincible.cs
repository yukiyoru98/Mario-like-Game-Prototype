using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvincible : MonoBehaviour
{
    public bool IsInvincible = false;
    public static PlayerInvincible self;
    private void Awake(){
        self = this;
    }

    SpriteRenderer PlayerSprite;
    private float InvincibleCD = 0.1f; //sprite flicks per 0.2 seconds 
    private float MaxInvincibleCD = 0; //record when to flick
    private int MaxFlickerNum = 20;
    private int CurrentFlickerNum = 0;

    private void Start(){
        PlayerSprite = this.gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update(){
        if(IsInvincible){
            Flicker();
        }
    }

    void Flicker(){
        if(Time.time >= MaxInvincibleCD){
            PlayerSprite.enabled = !PlayerSprite.enabled; // sprite flicks
            CurrentFlickerNum++;

            if(CurrentFlickerNum >= MaxFlickerNum){//invincible ends
                CurrentFlickerNum = 0;
                IsInvincible = false;
            }

            MaxInvincibleCD = Time.time + InvincibleCD;

        }
    }
}
