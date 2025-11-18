using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Must include this to use the Slider
using UnityEngine.UI;

public class DisplayBar : MonoBehaviour
{
    //Reference to slider for health bar
    public Slider slider;

    // Gradient for the heath bar
    public Gradient gradient;

    public Image fill;

    //Function to set the current value of the slider
    public void SetValue(float value)
    {
        //set value of the slider;
        slider.value = value;

        //set the color of the fill of the slider
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    // function to set the max value of the slider
    public void SetMaxValue(float value)
    {
        //set the max value of the slider
        slider.maxValue = value;
        //set the curret value of the slider to maxValue
        slider.value = value;

        //Set the color of the fill of the slider
        fill.color = gradient.Evaluate(1f);
    }
   
}
