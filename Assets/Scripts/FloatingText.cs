using UnityEngine;
using UnityEngine.UI;


//Removed MonoBehaviour as it is performance heavy and not needed in this script
public class FloatingText
{
    //If the text is currently active/being used
    public bool active;
    //Reference to game object
    public GameObject go;
    //The text that is being shown
    public Text txt;
    //Direction where the ext is moving in
    public Vector3 motion;
    //How long the text should be shown for
    public float duration;
    //Time when the text was last shown
    public float lastShown;


    //Function to show the text
    public void Show()
    {
        active = true;
        //Saves the time when text was activated to be used later to determine when to turn off the text
        lastShown = Time.time;
        go.SetActive(active);
    }


    //Function to hide the text
    public void Hide()
    {
        active = false;
        go.SetActive(active);
    }

    //Function to check if text is active and if it is then to check if enough time has passed to hide it
    //If not then update the movement of the text
    public void UpdateFloatingText()
    {
        if (!active)
            return;

        if (Time.time - lastShown > duration)
            Hide();
        go.transform.position += motion * Time.deltaTime;
    }
}
