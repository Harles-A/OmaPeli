using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoins : Collectables
{
    public int coinsAmount = 3;
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
