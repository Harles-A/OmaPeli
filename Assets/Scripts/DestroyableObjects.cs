using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObjects : Fighter
{
    //Destroy the object when it "dies"
    protected override void Death()
    {
        Destroy(gameObject);
    }
}
