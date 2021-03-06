using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    private Vector3 originalSize;
    
    protected private BoxCollider2D boxCollider;
    protected private Vector3 moveDelta;
    protected private RaycastHit2D hit;
    public float ySpeed = 0.75f;
    public float xSpeed = 1.0f;

    protected virtual void Start()
    {
        originalSize = transform.localScale;
        //At the start of the game get the box collider information.
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //This is the system that is used to move characters
    protected virtual void UpdateMotor(Vector3 input)
    {
        // Reset moveDelta.
        moveDelta = new Vector3(input.x * xSpeed, input.y * ySpeed, 0);

        // Swap Sprite direction depending on which way character is moving.
        if (moveDelta.x > 0)
            transform.localScale = originalSize;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(originalSize.x * -1, originalSize.y, originalSize.z);

        //Add push vector, if any
        moveDelta += pushDirection;

        //Reduce the push force every frame, based on the push recovery speed
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        // Do a boxcast to see if there's anything in the way that should stop us from moving on the Y axis.
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Characters", "Blockers"));
        // If no hit is detected, allow character to move on the Y axis.
        if (hit.collider == null)
        {
            // Apply movement to the character
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }
        // Do a boxcast to see if there's anything in the way that should stop us from moving on the X axis.
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Characters", "Blockers"));
        // If no hit is detected, allow character to move on the X axis.
        if (hit.collider == null)
        {
            // Apply movement to the character
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }
    }
}
