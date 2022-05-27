using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sludge : Fighter
{
    //This script is attached to the invisible box colliders on top of green goo
    //The sludge has Fighter tag in order to deal damage to the player
    //The purpose of this script is to override the ReceiveDamage function of the Fighter script to make sure that sludge cant be killed
    protected override void ReceiveDamage(Damage dmg)
    {
        
    }
}
