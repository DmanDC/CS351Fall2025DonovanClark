using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    //Set this reference in the inspector
    public GameObject player;
    public float lookAhead = 2f;
    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        //set the camera's position to the players position
        transform.position = new Vector3 (
            player.transform.position.x,
            player.transform.position.y,
            transform.position.z);

        float targetX = player.transform.position.x;

    }

}
