using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
    //Damage
    public int[] damagePoint = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public float[] pushForce = { 2.0f, 2.2f, 2.4f, 2.6f, 2.8f, 3.0f, 3.2f, 3.4f, 3.5f };

    //Upgrades
    public int weaponLevel = 0;
    public SpriteRenderer spriteRenderer;

    //Weapon swing
    private Animator anim;
    private float cooldown = 0.5f;
    private float lastSwing;


    //Get the reference to the animator of the weapon
    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    //Swing the weapon if player presses spacebar
    protected override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    //If enemy collides with the weapon's collider, deal damage to it
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.tag == "Fighter")
        {
            if (coll.name == "Player")
                return;

            //Create a damage object and send it to the enemy we've hit
            Damage dmg = new Damage
            {
                damageAmount = damagePoint[weaponLevel],
                origin = transform.position,
                pushForce = pushForce[weaponLevel]

            };

            coll.SendMessage("ReceiveDamage", dmg);
            
            
        }
        
    }

    //Start the swing animation
    private void Swing()
    {
        anim.SetTrigger("Swing");
    }

    //Increase weapon level by 1 if the UpgradeWeapon is Called
    public void UpgradeWeapon()
    {
        weaponLevel++;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];

         
    }

    //Set player's current weapon level when scene is loaded and this is called by the Game Manager
    public void SetWeaponLevel(int level)
    {
        weaponLevel = level;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }
}
