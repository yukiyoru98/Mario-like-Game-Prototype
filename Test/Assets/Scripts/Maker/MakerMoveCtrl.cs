using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakerMoveCtrl : MonoBehaviour //Maker/SceneObjects/Maker
{
    public static MakerMoveCtrl self;
    private void Awake() {
        self = this;
    }
    private Vector3 MakerPos = new Vector3(0, 0, 0);
    private float MoveDistance = 1f;
    private float HoldCD = 0.2f;
    private float ComboCD = 0.05f;
    private float CDTimer = 0;
    private bool UpKey;
    private bool DownKey;
    private bool LeftKey;
    private bool RightKey;

    private Vector2 XMoveRange = new Vector2(0, 30);
    private Vector2 YMoveRange = new Vector2(0, 7);

    private void Update()
    {
        //get instant state of keys
        UpKey = Input.GetKey(KeyCode.UpArrow);
        DownKey = Input.GetKey(KeyCode.DownArrow);
        LeftKey = Input.GetKey(KeyCode.LeftArrow);
        RightKey = Input.GetKey(KeyCode.RightArrow);
        
        if (UpKey || DownKey)
        {
            VerticalMove();
        }
        if(LeftKey || RightKey){
            HorizontalMove();
        }
        MakerCamCtrl.self.CamMove();
    }

    void VerticalMove()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){ //on UpKey pressed
            CDTimer = Time.time + HoldCD;
            MoveDistance = Mathf.Abs(MoveDistance); //positive distance
            MakerPos.y += MoveDistance;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)){ //on DownKey pressed
            CDTimer = Time.time + HoldCD;
            MoveDistance = -Mathf.Abs(MoveDistance); //negative distance
            MakerPos.y += MoveDistance;
        }
        
        if(Time.time > CDTimer){ //hold UpKey/DownKey
            CDTimer = Time.time + ComboCD;
            MakerPos.y += MoveDistance;
        }

        //limit y position
        MakerPos.y = Mathf.Clamp(MakerPos.y, YMoveRange.x, YMoveRange.y);
        transform.localPosition = MakerPos;

    }

    void HorizontalMove()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow)){ //on RightKey pressed
            CDTimer = Time.time + HoldCD;
            MoveDistance = Mathf.Abs(MoveDistance); //positive distance
            MakerPos.x += MoveDistance;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)){ //on LeftKey pressed
            CDTimer = Time.time + HoldCD;
            MoveDistance = -Mathf.Abs(MoveDistance); //negative distance
            MakerPos.x += MoveDistance;
        }
        
        if(Time.time > CDTimer){ //hold LeftKey/RightKey
            CDTimer = Time.time + ComboCD;
            MakerPos.x += MoveDistance;
        }

        //limit x position
        MakerPos.x = Mathf.Clamp(MakerPos.x, XMoveRange.x, XMoveRange.y);
        transform.localPosition = MakerPos;
    }

}
