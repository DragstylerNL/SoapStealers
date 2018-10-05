using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_MovementSystem : MonoBehaviour {
    
    // privates systems
    private int lanePos = 1, lastLanePos = 1, distance = 4;
    private bool leftButton = false, rightButton = false;

    private Transform pl_pos;

    //public Valuas 
    public float pl_speed = 10;

	void Start () {
        pl_pos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	void Update () {

        //get input for left/right movement
        leftButton = Input.GetButtonDown("LeftButton");
        rightButton = Input.GetButtonDown("RightButton");
        //change position acording to input //then actually move there
        if (leftButton && lanePos != 0) { lanePos--; ChangePos(-1); } 
        if (rightButton && lanePos != 2) { lanePos++; ChangePos(1); }

        //Move Forward
        pl_pos.position += new Vector3(0, 0, pl_speed) * Time.deltaTime;

    }

    private void ChangePos(int direction)
    {
        if (direction == -1) { pl_pos.position -= new Vector3(distance,0,0); }
        if (direction == 1) { pl_pos.position += new Vector3(distance,0,0); }
    }
}
