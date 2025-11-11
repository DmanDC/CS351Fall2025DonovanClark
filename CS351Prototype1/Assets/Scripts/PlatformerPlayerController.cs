/*Donovan Clark
 * Date:9/22/25
* Platformer Prototype
* Controls player movement
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerController : MonoBehaviour
{
    // Player Movement Speed
    public float moveSpeed = 5f;

    //Force applied when jimping
    public float jumpForce = 10f;

    //Layer mask for detecting ground
    public LayerMask groundLayer;

    //Transform representing the position to check for ground 
    public Transform groundCheck;

    //Raduis for groundCheck
    public float groundCheckRadius = 0.2f;

    //Reference to our Rigidbody2D
    private Rigidbody2D rb;

    //Boolean to keep tract of if we are on the ground
    private bool isGrounded;

    // a variable to hole horizontal input
    private float horizontalInput;

    //set this referecne to the jump sound in the the inspector
    public AudioClip jumpSound;

    //an audio source to play sound effects
    private AudioSource playerAudio;

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        //Set reference to player audio source
        playerAudio = GetComponent<AudioSource>();

        //Get the Rigidbody2D component attached to the gameobject
        rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        //Ensure the groundCheck variable is assigned
        if(groundCheck == null)
        {
            Debug.LogError("groundCheck not assinged to the player controller");
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Get input vales for horizonal movevemnt 
        horizontalInput = Input.GetAxis("Horizontal");

        //Check for jump input
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            //Apply an upward force for Jumping
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            //Play jump sound effect
            playerAudio.PlayOneShot(jumpSound, 1.0f);

            
            
        }
        
        
        
    }

    void FixedUpdate()
    {
        if (!PlayerHealth.hitRecently) { 
        // Move the player using Rigidbody2D in FixedUpdate
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        }

        // Move the player using RigidBody2D in FixedUpdate
        animator.SetFloat("xVelocityAbs", Mathf.Abs(rb.velocity.x));

        animator.SetFloat("yVelocity", rb.velocity.y);

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        animator.SetBool("onGround", isGrounded);

        //TODO: Optionally, we can add animations here later

        // Ensure the player is facing the direction of movement

        if(horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); // face right
        }
        else if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);  //face left
        }
    }
}
