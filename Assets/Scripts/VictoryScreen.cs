using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : Collidable
{
    public GameObject victoryScreen;
    //Trigger victory screen when player collides with the object this script is attached to
    protected override void OnCollide(Collider2D coll)
    {
        //Check if player is the one colliding with the object
        if (coll.name == "Player")
        {
            victoryScreen.gameObject.SetActive(true);
        }
    }

    //Back To Main Menu Button
    public void BackToTheMainMenu()
    {
        victoryScreen.gameObject.SetActive(false);
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("StartMenu");
    }
}
