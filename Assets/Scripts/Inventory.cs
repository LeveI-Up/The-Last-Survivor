using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inventory : MonoBehaviour
{
    public Text InventoryText;
    int[] counts = new int[4];

    void Update()
    {
        InventoryText.text = "Coal: " + counts[0] +"\nIron: " + counts[1] + "\nGold: " + counts[2] +"\nDimond: " + counts[3];        
    }

    public void Add(int tileData,int x){
        counts[tileData]+=x;
    }
}
