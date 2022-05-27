using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHeart : Collectables
{
    public int healingAmount = 2;

    //This script is attached to collectbles that when collided with will heal the player
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GameManager.instance.player.Heal(healingAmount);
            //Destroy the object once it has been picked up
            Destroy(gameObject);
        }



    }
}
