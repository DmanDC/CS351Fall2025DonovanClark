using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayerController : MonoBehaviour
{
    //a float to hold th espped of our tank player
    //try setting this to 8 in the inspector
    public float speed;

    //a float for our own turn speed
    //try setting this to 100 in the inspector
    public float turnSpeed;

    public float horizontalInput;
    public float verticalInput;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        //move foward
        //transform.Translate(1,0,0);

        // Does the same thing
        //transform.Translate(Vector3.right);

        //Move foward at 8 m/s since spped is set to 8
        //transform.Translate(Vector3.right  * Time.deltatime * speed);

        //Get input in Update()
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Move the player foward with veritcal input
        transform.Translate(Vector2.right * Time.deltaTime * speed * verticalInput);

        //rotate player with horizonal input
        //transform.Rotate(Vector3.back,turnSpeed * Time.deltaTime * horizontalInput);

        //Rotate player with horizonal input 
        //but reverse the rotation direction when moving backwards
        if(verticalInput < 0)
        {
            transform.Rotate(Vector3.back, -turnSpeed * Time.deltaTime * horizontalInput);
        }
        else
        {
            transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime * horizontalInput);

        }
    }
}
