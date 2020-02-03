using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlockCtrl : MonoBehaviour
{
    Animator anim;
    int CoinNum = 10;
    GameObject Coin;
    private void Start(){
        anim = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    public void isHit(){
        
        if(CoinNum > 0){ //when there are coins left(before hitting the CoinBlock)
            CoinNum--; //coin in coin block reduces
            Debug.Log("CoinNum: " + CoinNum);
            //play Move or LastCoin animation
            //after hitting the coin block
            //if there are coins left in the block, CoinLeft is set as true-> play Move animation
            //if no coins left, CoinLeft is false -> play LastCoin animation
            anim.SetBool("CoinLeft", CoinNum > 0); 
            anim.SetTrigger("Hit");
        }
    }

}
