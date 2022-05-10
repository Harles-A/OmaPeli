using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    public float robustMoveSpeed = 1.5f;
    public float boxCastCorrection = 0.5f;

    private void Start()
    {
        //At the start of the game get the box collider information.
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        // Look for movement input on the X axis.
        float x = Input.GetAxisRaw("Horizontal");
        // Look for movement input on the Y axis.
        float y = Input.GetAxisRaw("Vertical");
        // Reset moveDelta.
        moveDelta = new Vector3(x * boxCastCorrection, y * boxCastCorrection, 0);

        // Swap Sprite direction depending on which way character is moving.
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        // Do a boxcast to see if there's anything in the way that should stop us from moving on the Y axis.
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Characters", "Blockers"));
        // If no hit is detected, allow character to move on the Y axis.
        if(hit.collider == null)
        {
            // Apply movement to the character
            transform.Translate(0, (moveDelta.y * robustMoveSpeed) * Time.deltaTime, 0);
        }
        // Do a boxcast to see if there's anything in the way that should stop us from moving on the X axis.
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Characters", "Blockers"));
        // If no hit is detected, allow character to move on the X axis.
        if (hit.collider == null)
        {
            // Apply movement to the character
            transform.Translate((moveDelta.x * robustMoveSpeed) * Time.deltaTime, 0, 0);
        }


    }
}
