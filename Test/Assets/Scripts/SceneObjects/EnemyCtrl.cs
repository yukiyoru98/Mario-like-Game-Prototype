using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    //move horizontally, change direction when collide with sth on left or right side
    //die when player steps on top of enemy
    //hurt player when player touches enemy on other sides
    private float Speed = -11.0f;
    private float TurnCD = 0.3f; //time interval to check if enemy needs to change direction(when stuck)
    private float MaxTurnCD = 0.0f; // when to check if needs to change direction
    private Vector2 PreviousPos; // record position when previous check
    Rigidbody2D body;
    Animator anim;
    

    private void Start(){
        body = this.GetComponent<Rigidbody2D>();
        anim = this.transform.GetChild(0).GetComponent<Animator>();
        PreviousPos = this.transform.localPosition;
    }

    private void FixedUpdate() {
        body.velocity = new Vector2(Speed, body.velocity.y); //move
        
        if(Time.time >= MaxTurnCD){ // check if stucked
            
            if(Vector2.Distance(PreviousPos, this.transform.localPosition) <= 1.0f){ //is stucked
                Speed *= -1; // change direction
                ;
            }
            PreviousPos = this.transform.localPosition; // record position
            MaxTurnCD = Time.time + TurnCD; // update check time
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //when collide with sth on left/right side
        if(collision.GetContact(0).normal == Vector2.right || collision.GetContact(0).normal == Vector2.left){
            Speed *= -1; //change direction
            MaxTurnCD += TurnCD; // update check time
        }
    }


}
