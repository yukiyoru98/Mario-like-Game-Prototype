using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCtrl : MonoBehaviour
{
    Animator anim;

    private void Start(){
        anim = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
    }

    public void isHit(bool Power){
        Debug.Log("is Hit");
        //play move animation when player's power is not enough -> SetBool Power=false, SetTrigger Hit
        anim.SetBool("Power", Power);
        anim.SetTrigger("Hit");

        if(Power){
            //close boxCollider and play break animation when player's power is enough -> SetBool Power=true, SetTrigger Hit
            this.GetComponent<BoxCollider2D>().enabled = false;
            //destroy block after break animation is finished(0.4sec)
            Destroy(this.gameObject, 0.4f);
            ScoreCtrl.self.AddScore(10);
        }
    }


}
