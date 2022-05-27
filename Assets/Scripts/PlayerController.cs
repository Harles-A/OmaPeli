using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Mover
{
    private SpriteRenderer spriteRenderer;
    private bool isAlive = true;

    //Get the sprite to be used for the player character
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    //When player takes damage. This is an override from Fighter script.
    protected override void ReceiveDamage(Damage dmg)
    {
        //If player is dead, don't deal any more damage to him, he's suffered enough.
        if (!isAlive)
            return;

        base.ReceiveDamage(dmg);
        //Trigger the OnHitPointChange function in the GameManager
        GameManager.instance.OnHitpointChange();
    }


    //When player character dies set isAlive to false and trigger Game Over Screen to show up
    protected override void Death()
    {
        isAlive = false;
        GameManager.instance.gameOverAnim.SetTrigger("Show");
    }

    //Get input from player to see if movement keys are pressed
    private void FixedUpdate()
    {
        // Look for movement input on the X axis.
        float x = Input.GetAxisRaw("Horizontal");
        // Look for movement input on the Y axis.
        float y = Input.GetAxisRaw("Vertical");
        //If player isn't dead, call for UpdateMotor to move the character
        if(isAlive)
            UpdateMotor(new Vector3(x, y, 0));
    }

    //Main Menu script calls this to update the player sprite if the player character has been changed via the character menu
    public void SwapSprite(int skinId)
    {
        spriteRenderer.sprite = GameManager.instance.playerSprites[skinId];
    }


    //When player levels up, add +1 to his max health and heal him to full.
    public void OnLevelUp()
    {
        maxHitpoint++;
        hitpoint = maxHitpoint;
    }


    //This is called by the game manager when scene is loaded to set player's level to whatever it was at the end of last scene/last save
    public void SetLevel(int level)
    {
        for (int i = 0; i < level; i++)
            OnLevelUp();
        
    }

    //If this function is called, heal the player(unless he is at max health already)
    public void Heal(int healingAmount)
    {
        if (hitpoint == maxHitpoint)
            return;
        hitpoint += healingAmount;
        //If heal would put him above his max health, set his currenty health to max health
        if (hitpoint > maxHitpoint)
            hitpoint = maxHitpoint;
        else
        {
            GameManager.instance.ShowText("+" + healingAmount.ToString() + "hp", 25, Color.green, transform.position, Vector3.up * 30, 1.0f);
            GameManager.instance.OnHitpointChange();
        }
    }

    //When player dies and is respawned, his health is set to max
    //lastImmune is set to the current time to stop him from taking damage the moment he respawns
    //Reset any push vector he may have so the charatcer doesnt get knocked around when he respawns
    public void Respawn()
    {
        Heal(maxHitpoint);
        isAlive = true;
        lastImmune = Time.time;
        pushDirection = Vector3.zero;
    }
}
