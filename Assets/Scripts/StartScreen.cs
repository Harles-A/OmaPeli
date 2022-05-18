using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public string levelName;

    public void StartTheGame()
    {
        SceneManager.LoadScene(levelName);
    }
}
