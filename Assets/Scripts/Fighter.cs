using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitpoint = 10;
    public int maxHitpoint = 10;
    public float pushRecoverySpeed = 0.2f;

    //Immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    //Push
    protected Vector3 pushDirection;

    //Everyone tagged as a Fighter can receive damage and die
     protected virtual void ReceiveDamage(Damage dmg)
    {
        //Check if enough time has passed since last damage came in
        if(Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitpoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            //Show Floating Combat Text with the amount of damage that the target took
            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);

            //If the damage receiver is at 0 health after the damage, call Death function.
            //If the damage receiver would end up with negative health after damage, set the damage to 0 and call Death function
            if (hitpoint <= 0)
            {
                hitpoint = 0;
                Death();
            }
        }
    }
    //Base function for other scripts to override in case of someone or something dies in the game
    protected virtual void Death()
    {

    }
}
