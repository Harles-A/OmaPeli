using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcTexts : Collidable
{
    public string message;

    private float cooldown = 4.0f;
    private float lastText;

    protected override void Start()
    {
        base.Start();
        lastText = -cooldown;
    }
    protected override void OnCollide(Collider2D coll)
    {
        if(Time.time - lastText > cooldown)
        {
            lastText = Time.time;
            GameManager.instance.ShowText(message, 25, Color.white, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);

        }
        
    }
}