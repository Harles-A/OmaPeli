using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public string levelName;

    //When start the game button is pressed in main menu, load the First scene(set in public field in the editor)
    public void StartTheGame()
    {
        SceneManager.LoadScene(levelName);
    }
}
