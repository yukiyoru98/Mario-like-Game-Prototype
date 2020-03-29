using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCtrl : MonoBehaviour
{
    Animator anim;
    private void Start() {
        anim = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    private void FixedUpdate() {
        if(PauseCtrl.self.isPaused){
            anim.speed = 0;
        }
        else{
            anim.speed = 1;
        }
    }
    void GetCoin(){ //play get animation and destroy
        UICoinCtrl.self.GetMoney(1);
        ScoreCtrl.self.AddScore(20);
        //anim is assigned here again in case it won't be executed if the coin is spawn in the middle of the game
        anim = this.transform.GetChild(0).GetComponent<Animator>(); 
        anim.SetTrigger("GetCoin"); //play animation
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false; //disable box collider
        Destroy(this.gameObject, 0.3f); // destroy
    }
}
