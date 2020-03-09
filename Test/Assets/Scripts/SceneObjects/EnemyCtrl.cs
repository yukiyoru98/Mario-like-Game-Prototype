using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    //move horizontally, change direction when collide with sth on left or right side
    //die when player steps on top of enemy
    //hurt player when player touches enemy on other sides
    private float Speed = 5.0f;
    Rigidbody2D body;
    Animator anim;

    private void Start(){
        body = this.GetComponent<Rigidbody2D>();
        anim = this.transform.GetChild(0).GetComponent<Animator>();
    }

    private void FixedUpdate() {
        Move();
    }

    void Move(){
        body.velocity = new Vector2(Speed, body.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //when collide with sth on left/right side
        if(collision.GetContact(0).normal == Vector2.right || collision.GetContact(0).normal == Vector2.left){
            Speed *= -1; //change direction
        }
    }


}
