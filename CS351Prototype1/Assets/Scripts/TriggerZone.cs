using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Need this to use TextMeshPro
using TMPro;

public class TriggerZone : MonoBehaviour
{
    //set this reference in the inspector
    public TMP_Text output;

    //enter the text you want to display in the inspector
    public string textToDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print a test message to the console
        //Debug.Log("Triggered by: " + collision.gameObject.name);

        //set the player tag on the player in the inspector
        if(collision.gameObject.tag == "Player")
        {
            //dispay "You Win!" on the screen
            output.text = textToDisplay;
        }


    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
