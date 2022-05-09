using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Declare the thing that the camera is looking at
    public Transform lookAt;
    // How far away can player go before the camera starts following it.
    public float boundX = 0.2f;
    public float boundY = 0.1f;

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;
        // Check if we are inside the bounds on the X axis.
        //            Player's current position  -   The middle point of the camera's current location
        float deltaX = lookAt.position.x - transform.position.x;
        if(deltaX > boundX || deltaX < -boundX)
        {
            if(transform.position.x < lookAt.position.x)
            {
                delta.x = deltaX - boundX;
            }
            else
            {
                delta.x = deltaX + boundX;
            }
        }
        // Check if we are inside the bounds on the Y axis.
        //            Player's current position  -   The middle point of the camera's current location
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY)
        {
            if (transform.position.y < lookAt.position.y)
            {
                delta.y = deltaY - boundY;
            }
            else
            {
                delta.y = deltaY + boundY;
            }
        }

        // Move the camera
        transform.position += new Vector3(delta.x, delta.y, 0);
    }


}
