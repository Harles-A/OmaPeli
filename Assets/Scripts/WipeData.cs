using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WipeData : MonoBehaviour
{
   public void WipeSaveData()
    {
        PlayerPrefs.DeleteAll();
    }
}
