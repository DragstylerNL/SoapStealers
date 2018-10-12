using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        GameObject.FindGameObjectWithTag("ChunkController").GetComponent<ChunkController>().SpawnNextChunk();
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().AddScore(1);
        Destroy(transform.parent.gameObject);
    }
}
