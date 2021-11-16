using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateChunk : MonoBehaviour
{

    public GameObject DirtTile;
    public GameObject GrassTile;
    public GameObject StoneTile;

    public GameObject tileDimond;
    public GameObject tileGold;
    public GameObject tileIron;
    public GameObject tileCoal;

    public float chanceToDimond;
    public float chanceToGold;
    public float chanceToIron;
    public float chanceToCoal;

    public int width;
    public float heightMultiplier;
    public int heightAddition;

    public float smoothness;

    [HideInInspector]
    public float seed;

    

    void Start()
    {
        Generate();
    }

    public void Generate()
    {
        for(int i = 0; i<width; i++){ 
            int h = Mathf.RoundToInt(Mathf.PerlinNoise(seed ,(i+transform.position.x)/smoothness) * heightMultiplier) + heightAddition;
            for(int j = 0; j<h; j++){
                GameObject selectedTile;
                if(j<h-4){
                    selectedTile = StoneTile;
                }       
                else if(j<h-1){
                    selectedTile = DirtTile;
                }
                else{
                    selectedTile = GrassTile;
                }
                GameObject newTile = Instantiate(selectedTile, Vector3.zero , Quaternion.identity) as GameObject;
                newTile.transform.parent = this.gameObject.transform;
                newTile.transform.localPosition = new Vector3(i,j,0);
            }    
        }
        papulate();    
    }

    public void papulate(){
        foreach(GameObject t in GameObject.FindGameObjectsWithTag("TileStone")){
            if(t.transform.parent == this.gameObject.transform){
                float r = Random.Range(0f,100f);
                GameObject selectedTile = null;

                if(r<chanceToDimond){
                    selectedTile = tileDimond;
                }
                else if(r<chanceToGold){
                    selectedTile = tileGold;
                }
                else if(r<chanceToIron){
                    selectedTile = tileIron;
                }
                else if(r<chanceToCoal){
                    selectedTile = tileCoal;
                }

                if(selectedTile!=null){
                    GameObject newResourceTile = Instantiate(selectedTile, t.transform.position , Quaternion.identity) as GameObject;
                    Destroy(t);
                }
            }
        }
    }
}
