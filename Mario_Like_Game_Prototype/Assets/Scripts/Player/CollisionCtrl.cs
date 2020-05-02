using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCtrl : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "SceneObjects"){
        Debug.Log("Collision");

            CollideSceneObj(collision);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "SceneObjects"){
            TriggerSceneObj(collider);
        }
    }
    void CollideSceneObj(Collision2D collision){
        
        if(collision.gameObject.name == "Block_Root" && collision.GetContact(0).normal == Vector2.down){
            //if hit the bottom of the Block
            Debug.Log("Hit Block");
            Debug.Log(PlayerDataManager.self.data.Power);
            collision.gameObject.SendMessage("isHit", PlayerDataManager.self.data.Power);
        }

        if(collision.gameObject.name == "CoinBlock_Root" && collision.GetContact(0).normal == Vector2.down){
            //if hit the bottom of the CoinBlock
            collision.gameObject.SendMessage("isHit");
        }

        if(collision.gameObject.name == "Enemy_Root" && collision.GetContact(0).normal == Vector2.up){
            //if hit the top of the Enemy
            collision.gameObject.SendMessage("isKilled");
        }
        if(collision.gameObject.name == "Complete"){
            //if reach goal
            collision.gameObject.SendMessage("Complete");
        }
    }
    void TriggerSceneObj(Collider2D collider){
        if(collider.gameObject.name == "Coin_Root"){
            //if touch the Coin
            Debug.Log("GetCoin");
            collider.gameObject.SendMessage("GetCoin");
        }
    }
}
