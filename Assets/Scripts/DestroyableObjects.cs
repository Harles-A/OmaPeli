using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObjects : Fighter
{
    protected override void Death()
    {
        Destroy(gameObject);
    }
}
