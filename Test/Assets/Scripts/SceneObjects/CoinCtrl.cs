using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCtrl : MonoBehaviour
{
    Animator anim;
    void GetCoin(){ //play get animation and destroy
        PlayerData.self.EarnMoney(1);
        ScoreCtrl.self.AddScore(20);
        //anim is not assigned in Start since it won't be executed if the coin is spawn in the middle of the game
        anim = this.transform.GetChild(0).GetComponent<Animator>(); 
        anim.SetTrigger("GetCoin"); //play animation
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false; //disable box collider
        Destroy(this.gameObject, 0.3f); // destroy
    }
}
