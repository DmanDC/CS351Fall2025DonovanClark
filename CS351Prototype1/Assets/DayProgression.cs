/*
* Donovan Clark
* FinalProjectGame
* Changes the text being shown and 
* enables the button to be used and increase the day when it is clicked.
*/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class DayProgression : MonoBehaviour
{

    public static int Day;
    //set this this in the inspector
    public TMP_Text textbox;
    public Button button;
    public Button statusReport;
    public Animator dayAnimator;
    public TMP_Text Status;
    public GameObject SunAndMoo;
    
    
    // Start is called before the first frame update
    void Start()
    { 
        textbox.text = "Day: " + Day;
        button.onClick.AddListener(NextDay);
        Status.text = "Day:" + Day;
        statusReport.onClick.AddListener(Destroy);
    }
    private void NextDay()
        {
        Day += 1;
        Debug.Log("Button was clicked!");
        if (textbox != null) textbox.text = "Day: " + Day;
        GameObject SunAndMoon = Instantiate(SunAndMoo);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
