using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    const string path = "Prefabs/SceneObjects/Coin_Root";

    void Spawn(){ //generate and return a coin(idle animation played defaultly)
        GameObject Coin = Instantiate(Resources.Load(path)) as GameObject;
        Coin.transform.localPosition = this.transform.position + new Vector3(0, 1, 0); //appears 2 unit above the CoinBlock
        Coin.SendMessage("GetCoin"); //call GetCoin in CoinCtrl    
    }

}
