using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChunks : MonoBehaviour
{

    public GameObject chunk;
    int chunkWidth;
    public int numOfChunks;
    float seed;

    void Start()
    {
        chunkWidth = chunk.GetComponent<GenerateChunk>().width;
        seed = Random.Range(-10000f,10000f);
        Generate();
    }

    void Generate()
    {
        int lastX = -chunkWidth;
        for(int i = 0; i<numOfChunks;i++){
            GameObject newChunk = Instantiate(chunk, new Vector3(lastX + chunkWidth, 0f) , Quaternion.identity) as GameObject;
            newChunk.GetComponent<GenerateChunk>().seed = seed;
            lastX+=chunkWidth;
        }
    }
}
