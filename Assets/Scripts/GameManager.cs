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
            //If it does then destroy the extra copy of the game manager and other objects that would logically also have to
            //exist if the extra game manager exists due to them all using the DontDestroyOnLoad
            Destroy(gameObject);
            Destroy(player.gameObject);
            Destroy(floatingTextManager.gameObject);
            Destroy(hud.gameObject);
            Destroy(menu.gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        SceneManager.sceneLoaded += OnSceneLoaded;
       
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public PlayerController player;
    public Weapon weapon;
    public FloatingTextManager floatingTextManager;
    public RectTransform hitpointBar;
    public GameObject hud;
    public GameObject menu;
    public Animator gameOverAnim;
    

    public int coins;
    public int experience;

    //Floating text stuff
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    // Weapon Upgrade System
    public bool TryUpgradeWeapon()
    {
        //Check if weapon is at max level
        if (weaponPrices.Count <= weapon.weaponLevel)
            return false;
        //If we can upgrade, check if we have enough money. If we do then call UpgradeWeapon.
        if(coins >= weaponPrices[weapon.weaponLevel])
        {
            coins -= weaponPrices[weapon.weaponLevel];
            weapon.UpgradeWeapon();
        }
        return false;
    }

    //HealthBar System
    //When player loses health, change the healthbar graphics to indicate it
    public void OnHitpointChange()
    {
        float ratio = (float)player.hitpoint / (float)player.maxHitpoint;
        hitpointBar.localScale = new Vector3(1, ratio, 1);
    }

    //EXP System
    //Check what level the player should be based on how much xp he has.
    public int GetCurrentLevel()
    {
        int r = 0;
        int add = 0;

        while(experience >= add)
        {
            add += xpTable[r];
            r++;
            //Check if we are already at max level
            if (r == xpTable.Count)
                return r;
        }

        return r;
    }

    public int GetXpToLevel(int level)
    {
        int r = 0;
        int xp = 0;

        while(r < level)
        {
            xp += xpTable[r];
            r++;
        }

        return xp;
    }

    //Grant player some xp. If it is enough to level him up, call OnLevelUp
    public void GrantXp(int xp)
    {
        int currentLevel = GetCurrentLevel();
        experience += xp;
        if (currentLevel < GetCurrentLevel())
            OnLevelUp();
    }
    //When GameManager calls OnLevelUp, also call the OnLevelUp function (different function, same name) in the PlayerController script
    //When player levels up, also call OnHitpointChange because player receivesd +1max health and heals to full
    //and his healthbar needs to be updated
    public void OnLevelUp()
    {
        player.OnLevelUp();
        OnHitpointChange();
    }

    // When loading a scene
    public void OnSceneLoaded(Scene s, LoadSceneMode mode)
    {
        player.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }

    //Restarting the game
    public void Restart()
    {
        gameOverAnim.SetTrigger("Hide");
        SceneManager.LoadScene("Main");
        player.Respawn();
    }
    

    //Save the current state of the game(coins, EXP, weapon level)
    public void SaveState()
    {
        string s = "";
        s += "0" + "|";
        s += coins.ToString() + "|";
        s += experience.ToString() + "|";
        s += weapon.weaponLevel.ToString();


        PlayerPrefs.SetString("SaveState", s);
    }
    //Load the current state of the game(coins, EXP, weapon level)
    public void LoadState(Scene s, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= LoadState;

        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        

        //Change the amount of coins
        coins = int.Parse(data[1]);

        //Change EXP and level(if needed)
        experience = int.Parse(data[2]);
        if (GetCurrentLevel() != 1)
            player.SetLevel(GetCurrentLevel());
        //Change weapon model
        weapon.SetWeaponLevel(int.Parse(data[3]));

        
    }

    
}
