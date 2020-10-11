using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour
{

    public Slider slider;
    

    public void SetTimer(float time)
    {
        slider.value = time;
    }

    public void SetMax(float max)
    {
        slider.maxValue = max;
        slider.value = max;
    }
}
