using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkController : MonoBehaviour {

    // active chunks
    public List<GameObject> chunksLst = new List<GameObject>();
    // random chunks
    public List<GameObject> allChunks = new List<GameObject>();
    private float allChunkSize = 0;

    // placeholders or object for instantiation of class and systems
    public GameObject temp1, temp2, temp3;
    public GameObject chunkSoap;
    

	void Start () {
        // get the curent ones in the list
        chunksLst.Add(temp1);
        chunksLst.Add(temp2);
        chunksLst.Add(temp3);
        // get the size of all chunks
        foreach(GameObject chunk in allChunks){
            allChunkSize++;
        }
	}
	
	void Update () {
		
	}

    public void SpawnNextChunk()
    {
        // spawn the new chunk
        Vector3 nextSpawnPos = chunksLst[2].transform.position;
        nextSpawnPos.z += 64;
        chunksLst.Add(allChunks[Mathf.FloorToInt(Random.value * allChunkSize)]);
        chunksLst[3].transform.position = nextSpawnPos;
        Instantiate(chunksLst[3]);

        // delete previous chunk
        Destroy(chunksLst[0]);
        chunksLst.RemoveAt(0);

        // new soaptrigger
        chunkSoap.transform.position = new Vector3(0, 5.5f, chunksLst[2].transform.position.z - 14);
        Instantiate(chunkSoap);
    }
}
