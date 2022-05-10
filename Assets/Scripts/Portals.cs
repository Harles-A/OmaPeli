//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Portals : Collidable
{
    public string[] sceneNames;
    protected override void OnCollide(Collider2D coll)
    {
        //Check if player is the one colliding with the portal
        if(coll.name == "Player")
        {
            //Save the game
            GameManager.instance.SaveState();
            //Teleport player
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
