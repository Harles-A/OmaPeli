using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChests : Collectables
{
    public Sprite emptyChest;
    public int coinsAmount = 5;

    //When player collides with the treasure chest, replace the treasure chest's sprite
    //with an empty treasure chest and grant player coins and show text
    protected override void OnCollect()
    {
        if(!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.coins += coinsAmount;
            GameManager.instance.ShowText("+" + coinsAmount + " coins!", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
        }


        
    }
}
