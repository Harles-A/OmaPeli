using UnityEngine;

public struct Damage
{
    //Direction from where the damage is coming from
    public Vector3 origin;
    //How much damage is done 
    public int damageAmount;
    //How much the character being damaged is pushed back
    public float pushForce;
}
