using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyForDoor : Collectables
{
    public GameObject doorToUnlock;
    public string messageToShow;
    //When the item with this script is collected, Show floating text and destroy both this item and whatever item is linked to it
    //via the doorToUnlock public field. This is used to trigger hidden doors in the game.
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
