using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_MovementSystem : MonoBehaviour {

    [SerializeField]
    private int lanePos = 1, lastLanePos = 1;
    private bool leftButton = false, rightButton = false;

    private Transform pl_pos;

    public float distance = 5f;

    

	void Start () {
        pl_pos = GetComponent<Transform>();
	}
	
	void Update () {

        //get input for left/right movement
        leftButton = Input.GetButtonDown("LeftButton");
        rightButton = Input.GetButtonDown("RightButton");
        //change position acording to input //then actually move there
        if (leftButton && lanePos != 0) { lanePos--; ChangePos(-1); } 
        if (rightButton && lanePos != 2) { lanePos++; ChangePos(1); } 


    }

    private void ChangePos(int direction)
    {
        //if (direction == 1) { pl_pos.position.x }
    }
}
