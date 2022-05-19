using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyForDoor : Collectables
{
    public GameObject doorToUnlock;
    public string messageToShow;
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GameManager.instance.ShowText(messageToShow, 25, Color.magenta, transform.position, Vector3.up * 15, 3.0f);
            Destroy(doorToUnlock);
            Destroy(gameObject);
        }



    }
}
