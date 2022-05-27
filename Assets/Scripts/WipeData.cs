using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WipeData : MonoBehaviour
{
    //When pressing wipe data button in the main menu, delete all saved player variables such as level, gold etc
   public void WipeSaveData()
    {
        PlayerPrefs.DeleteAll();
    }
}
