using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        //Check to see if GameManager already exists in the scene
        if(GameManager.instance != null)
        {
            //If it does then destroy the extra copy
            Destroy(gameObject);
            return;
        }

        //Delete old save data when game starts
        //PlayerPrefs.DeleteAll();

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        //Keep the GameManager around throughout all the scenes
        DontDestroyOnLoad(gameObject);
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public PlayerController player;

    public int coins;
    public int experience;

    //Save the current state of the game
    public void SaveState()
    {
        string s = "";
        s += "0" + "|";
        s += coins.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0";


        PlayerPrefs.SetString("SaveState", s);
    }
    //Load the current state of the game
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        //Change character model - TODO
        coins = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        //Change weapon - TODO

        Debug.Log("LoadState");
    }
}
