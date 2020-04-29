using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventCtrl : MonoBehaviour
{
    
    public void HurtEnd(){
        PlayerCtrl.self.HurtBool = false; //player is not hurt
        PlayerInvincible.self.IsInvincible = true; //player becomes invincible for a short period of time
    }

}
