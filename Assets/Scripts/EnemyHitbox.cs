using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    //Damage
    public int damage = 1;
    //Strength of pushback force
    public float pushForce = 3;


    //When player collides with the object this script is attached to, player takes damage.
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag == "Fighter" && coll.name == "Player")
        {
            //Create a new damage object before sending it to the player
            Damage dmg = new Damage
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce

            };
            //Send it to the ReceiveDamage function in th Fighter script
            coll.SendMessage("ReceiveDamage", dmg);
        }
    }
}
