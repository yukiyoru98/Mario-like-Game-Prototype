using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    //move horizontally, change direction when collide with sth on left or right side
    //die when player steps on top of enemy
    //hurt player when player touches enemy on other sides
    private float Speed = -8.0f;
    private float TurnCD = 0.3f; //time interval to check if enemy needs to change direction(when stuck)
    private float MaxTurnCD = 0.0f; // when to check if needs to change direction
    private Vector2 PreviousPos; // record position when previous check
    private Vector2 HurtContactBuffer = new Vector2(-0.3f, 0.3f); //buffer for the x component of the contact's normal vector when hurts the player
    Rigidbody2D body;
    Animator anim;


    private void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
        anim = this.transform.GetChild(0).GetComponent<Animator>();
        PreviousPos = this.transform.localPosition;
    }

    private void FixedUpdate()
    {
        if (PauseCtrl.self.isPaused)
        {
            anim.speed = 0;
            body.velocity = Vector2.zero;
            body.gravityScale = 0;
            return;
        }
        else
        {
            anim.speed = 1;
            body.gravityScale = 1;
        }
        body.velocity = new Vector2(Speed, body.velocity.y); //move

        if (Time.time >= MaxTurnCD)
        { // check if stucked

            if (Vector2.Distance(PreviousPos, this.transform.localPosition) < 0.6f)
            { //is stucked
                Speed *= -1; // change direction
            }
            PreviousPos = this.transform.localPosition; // record position
            MaxTurnCD = Time.time + TurnCD; // update check time

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when collide with sth on left/right side
        if (collision.GetContact(0).normal == Vector2.right || collision.GetContact(0).normal == Vector2.left)
        {
            Speed *= -1; //change direction
            MaxTurnCD += TurnCD; // update check time
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // use "Stay" to avoid player become invincible when sticking to the enemy
        if (collision.gameObject.tag == "Player" && collision.GetContact(0).normal != Vector2.down)
        { //if hit Player
            if (collision.GetContact(0).normal.x < HurtContactBuffer.x || collision.GetContact(0).normal.x > HurtContactBuffer.y)
            {//if out of buffer range
                if (!PlayerCtrl.self.HurtBool && !PlayerInvincible.self.IsInvincible)
                { //if player is not hurt and is not invincible
                    collision.gameObject.SendMessage("Hurt");
                    //print(collision.GetContact(0).normal);
                }
            }
        }
    }

    public void isKilled()
    {
        anim = this.transform.GetChild(0).GetComponent<Animator>();
        anim.SetBool("Dead", true);
        //this.GetComponent<BoxCollider2D>().enabled = false; //seems not neccessary
        Speed = 0; //stop moving
        Destroy(this.gameObject, 0.2f);
        ScoreCtrl.self.AddScore(100);
    }

    void ChangeDirection()
    {
        Speed *= -1;
        transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
    }
}
