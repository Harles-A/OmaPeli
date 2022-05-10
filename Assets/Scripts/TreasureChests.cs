using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChests : Collectables
{
    public Sprite emptyChest;
    public int coinsAmount = 5;
    protected override void OnCollect()
    {
        if(!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            Debug.Log("Grant " + coinsAmount + " coins!");
        }


        
    }
}
