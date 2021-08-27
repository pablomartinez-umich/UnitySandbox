using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private Vector3 moveDelta;
    private RaycastHit2D hit; // Casting our players colliders box  where it should be in the future and we'll check are we allowed to go there

    // Start is called before the first frame update
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        // Gets the input from keyboard
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");


        // Reset MoveDelta to get new inputs
        moveDelta = new Vector3(x,y,0);


        // SWAP SPRITE DIRECTION

        // Needed to move to facing right when originally facing left
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one; // Vector3.one = Vector3(1, 1, 1)

        // Needed to move back to facing left when originally facing right
        if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1); // Flips the scale x variable 


        // MOVEMENT

        // Make sure we can move in this direction by casting a box there first, if the box returns null we're free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Avatar", "Blocking"));
        
        if(hit.collider == null)
        {
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0); // Translates position by +/- y
        }

        // Make sure we can move in this direction by casting a box there first, if the box returns null we're free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Avatar", "Blocking"));

        if (hit.collider == null)
        {
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0); // Translates position by +/- y
        }
    }
}
