using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHeart : Collectables
{
    public int healingAmount = 2;
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GameManager.instance.player.Heal(healingAmount);
            Destroy(gameObject);
        }



    }
}
