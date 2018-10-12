using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void Die()
    {
        GameObject.FindGameObjectWithTag("Death").transform.position = new Vector3(0, 0, 0);
    }
}
