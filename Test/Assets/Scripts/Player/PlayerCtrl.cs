using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float Speed = 6.0f;
    Rigidbody2D body;

    private void Start(){
        body = this.gameObject.GetComponent<Rigidbody2D>(); //assign game object's rigidbody2D when start
    }
   
    private void FixedUpdate() {

        //Player Movement:horizontal
        float h = Input.GetAxis("Horizontal"); //receive keyboard input:arrow keys, a, d
        body.velocity = new Vector2(h*Speed, body.velocity.y); //change player's velocity.x, y component remains

    }

}
