using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTriggerZone : MonoBehaviour
{
    //a bool variable to keep tract of if the trigger zone is 
    bool active = true;
    private void OnTriggerEnter2D (Collider2D collision)
    {
        //if the trigger zone is active...
        if (active && collision.gameObject.tag == "Player")
        {
            //Deativate the trigger zone
            active = false;
            //Add 1 to the score when the plaer enters the trigger
            ScoreManager.score++;

            //Destory this GameObject;
            Destroy(gameObject);
        }
        

    }
}
