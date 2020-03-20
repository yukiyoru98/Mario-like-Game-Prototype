using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public bool HurtBool = false; //determines whether player is hurt
    public static PlayerCtrl self;
    private void Awake(){
        self = this;
    }
    private float Speed = 10.0f; //determines player's running speed
    private float JumpVelocity = 600f; //refers to player's ability to jump
    private float HighFallMultiplier = 3.0f; //multipler for high jump's falling motion
    private float LowFallMultiplier = 2.0f; //multipler for low jump's falling motion
    Rigidbody2D body;
    Animator anim;
    //boolean variables below are used to control animations
    bool RunBool = false; //determines whether player is running
    bool JumpKeyPressed = true;
    bool JumpingUpBool = false; //determines whether player is jumping up
    bool GroundBool = true; //determines whether player is on the ground
    
    private void Start(){
        body = this.gameObject.GetComponent<Rigidbody2D>(); //assign Player_Root's rigidbody2D 
        anim = this.gameObject.transform.GetChild(0).GetComponent<Animator>(); //assign Player's animator 
    }
   
    private void FixedUpdate() {
        if(!HurtBool){ //can act only if if player is not hurt
            Run();
            Jump();
            SetAnimator();
        }
    }
    
    void Run(){
        //Player Movement:horizontal
        float h = Input.GetAxis("Horizontal"); //receive keyboard input:arrow keys, a, d
        body.velocity = new Vector2(h*Speed, body.velocity.y); //set player's velocity.x, y component remains
        //set run bool as true if is running(h!=0)
        RunBool = (h!=0);
        //change sprite direction according to h
        if(h > 0){//run along +x, so player faces +x
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(h < 0){//run along -x, so player faces -x
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Jump(){
        //can jump when (1)space is pressed (2)player is on the ground (3)Jump Key not pressed
        if(Input.GetKey(KeyCode.Space) && GroundBool && !JumpKeyPressed){ 
            //give a upward force(determined by JumpVelocity) to let player jump
            body.AddForce(Vector2.up * JumpVelocity);
        }
        //check current state of jump key to avoid infinite jump
        JumpKeyPressed = Input.GetKey(KeyCode.Space);

        //set bool: JumpingUpBool as true when player is moving upwards (velocity.y is (+)) 
        //and false when downwards (velocity.y is (-))
        JumpingUpBool = (body.velocity.y > 0);
        
        //fall faster for better game effect
        if(body.velocity.y < 0){ //when falling after high jump
            //gravity is multiplied
            body.velocity += Vector2.up * Physics2D.gravity.y * (HighFallMultiplier - 1) * Time.deltaTime;
        }
        else if (JumpingUpBool && !(Input.GetKey(KeyCode.Space))){ //low jump: is jumping up and not holding jump key
            body.velocity += Vector2.up * Physics2D.gravity.y * (LowFallMultiplier - 1) * Time.deltaTime;
        }

        //set bool: GroundBool as true when no vertical motion(velocity.y is 0)->player is on the ground
        GroundBool = (body.velocity.y == 0);
        if(GroundBool){
            //Debug.Log("Ground");
        }

    }

    public void Hurt(){
        
        anim.SetTrigger("Hurt");
        HurtBool = true; // player is hurt
        body.velocity = new Vector2(0, body.velocity.y);
    }

    void SetAnimator(){
        anim.SetBool("Running", RunBool);
        anim.SetBool("JumpingUp", JumpingUpBool);
        anim.SetBool("Ground", GroundBool);
    }

}
