using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThisObject : MonoBehaviour {

    private Transform thisTs;
    private Vector3 oldts;
    private Vector3 newBaseV3 = Vector3.up;

    public Transform otherTs;
    private Vector3 v3_oldPos, v3_newPos, v3_desPos;

    public bool x_follow, y_follow, z_follow;
    public Vector3 offset;

    public bool hasSmoothFollow;
    public Transform baseTs;
    [Range(0, 100)]
    public float maxProcentInbetween;
    public float transitionTime;
    private float past_trasitionTime;
	
    void Start()
    {
        thisTs = GetComponent<Transform>();
    }

	// Update is called once per frame
	void Update () {

        if (!hasSmoothFollow)
        {
            SetOffset();
            if (x_follow) { thisTs.position += new Vector3(otherTs.position.x, 0, 0); }
            if (y_follow) { thisTs.position += new Vector3(0, otherTs.position.y, 0); }
            if (z_follow) { thisTs.position += new Vector3(0, 0, otherTs.position.z); }
        }
        else
        {
            MakeTrasition();
        }

    }

    void SetOffset()
    {
        thisTs.position = new Vector3(offset.x, offset.y, offset.z);
    }

    void MakeTrasition()
    {
        // old pos of 'other' = the old position of the last frame of 'other'
        v3_oldPos = v3_newPos;
        v3_newPos = otherTs.position;
        Vector3 oldBaseTs = newBaseV3;
        newBaseV3 = baseTs.position;
        
        // if the 
        if (v3_oldPos != v3_newPos || newBaseV3 != oldBaseTs)
        {
            // calculate the final position inbetween the 2 objects
            float _x = baseTs.position.x + ((otherTs.position.x - baseTs.position.x) * (maxProcentInbetween / 100));
            float _y = baseTs.position.y + ((otherTs.position.y - baseTs.position.y) * (maxProcentInbetween / 100));
            float _z = baseTs.position.z + ((otherTs.position.z - baseTs.position.z) * (maxProcentInbetween / 100));
            v3_desPos = new Vector3(_x, _y, _z) + new Vector3(offset.x, offset.y, offset.z);
            //print(v3_desPos);
            // the position of this object befor new math
            oldts = new Vector3(thisTs.position.x, thisTs.position.y, thisTs.position.z);

            past_trasitionTime = 0;
        }

        // timer adjustment
        past_trasitionTime += Time.deltaTime;
        if (past_trasitionTime > transitionTime)
        {
            // if timer is done. set the position to the position it needs to be
            thisTs.position = v3_desPos;
        }

        // if the position is not where it needs to be and timer hasn't run out. calculate the next position
        if (v3_oldPos == v3_newPos && past_trasitionTime < transitionTime)
        {
            float _x = (v3_desPos.x - oldts.x) * (Time.deltaTime / transitionTime);
            float _y = (v3_desPos.y - oldts.y) * (Time.deltaTime / transitionTime);
            float _z = (v3_desPos.z - oldts.z) * (Time.deltaTime / transitionTime);
            thisTs.position += new Vector3(_x, _y, _z);
        }

        //thisTs.position = new Vector3(Mathf.Clamp(), Mathf.Clamp(), Mathf.Clamp());
    }

}
