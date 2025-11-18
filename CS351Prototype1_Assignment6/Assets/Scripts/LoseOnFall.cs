using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseOnFall : MonoBehaviour
{
    //Set this in the inspector
    public float lowertY;

  
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < lowertY)
        {
            ScoreManager.gameOver = true;
        }
    }
}
