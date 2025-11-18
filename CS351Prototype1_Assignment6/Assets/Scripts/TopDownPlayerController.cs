using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPlayerController : MonoBehaviour
{
    //Adujst this value in the inspector to set the player's movement speed
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        //Get the Rigidbody2D component attacted to the GameObject
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get input values for horiznonal and vertical movement
        //use GetAxisRaw so the input is either a  1, 0, or -1
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Normalize the movement vector to prevent faster diagonal 
        movement.Normalize();
    }

    private void FixedUpdate()
    {
        //Move the player using Rigidbody2D in FixedUpdate
        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }
}

