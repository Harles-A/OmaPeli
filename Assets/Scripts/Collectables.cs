using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : Collidable
{
    protected bool collected;

    //If player collides with a asset that this script is added to, trigger OnCollect
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
            OnCollect();
    }

    //Set collected value to true
    protected virtual void OnCollect()
    {
        collected = true;
    }

}
