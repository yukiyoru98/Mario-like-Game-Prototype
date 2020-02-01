using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCtrl : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "SceneObjects"){
            CollideSceneObj(collision);
        }
    }

    void CollideSceneObj(Collision2D collision){
        
        Debug.Log("CollideSceneObj");
        Debug.DrawRay(collision.GetContact(0).point, collision.GetContact(0).normal);

        if(collision.gameObject.name == "Block_Root" && collision.GetContact(0).normal == Vector2.down){
            Debug.Log("Block");
            //if hit the bottom of the Block
            collision.gameObject.SendMessage("isHit", PlayerData.self.Power);
        }
        
    }
}
