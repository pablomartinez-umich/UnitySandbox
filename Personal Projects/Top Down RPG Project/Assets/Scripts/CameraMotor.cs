using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt; // The player but can be used to put focus on something else in scene
    public float boundX = 0.15f; // How far player can go in x before camera starts following player
    public float boundY = 0.05f; //How far player can go in y before camera starts following player

    // Update is called once per frame
    private void LateUpdate() // After the Update, after the player moves
    {
        Vector3 delta = Vector3.zero;

        // This is to check if we're inside the bounds on the X axis
        float deltaX = lookAt.position.x - transform.position.x; // lookAt is the player, so their position - the cameras position
        if (deltaX > boundX || deltaX < -boundX) // if it's outside the set bound constant for x
        {
            if (transform.position.x < lookAt.position.x) // if camera's x is smaller than player's, then player is on the right
            {
                delta.x = deltaX - boundX; // centers camera by getting new edge and +/- bound
            }
            else
            {
                delta.x = deltaX + boundX; // centers camera by getting new edge and +/- bound
            }
        }

        // This is to check if we're inside the bounds on the Y axis
        float deltaY = lookAt.position.y - transform.position.y; // lookAt is the player, so their position - the cameras position
        if (deltaY > boundY || deltaY < -boundY) // if it's outside the set bound constant for y
        {
            if (transform.position.y < lookAt.position.y) // if camera's y is smaller than player's, then player is above
            {
                delta.y = deltaY - boundY; // centers camera by getting new edge and +/- bound
            }
            else
            {
                delta.y = deltaY + boundY; // centers camera by getting new edge and +/- bound
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0); // moving camera by new determined center
    }
}
