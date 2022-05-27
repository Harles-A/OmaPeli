using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoins : Collectables
{
    //How much coins is this collectable worth
    public int coinsAmount = 3;
    //When player collides with the object, OnCollcet is called to grant him coins and show floating text about it
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GameManager.instance.coins += coinsAmount;
            GameManager.instance.ShowText("+" + coinsAmount + " coins!", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
            Destroy(gameObject);
        }



    }
}
