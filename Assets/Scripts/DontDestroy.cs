using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    //This script is added to objects that must be saved when moving from one scene to another, such as HUD and Game Manager etc.
    //It will make sure that once next scene is loaded the object with this script is not destroyed
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
