using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowTargetEnabler : MonoBehaviour
{
    private bool isThrowable = true;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Walls" || other.gameObject.tag == "PitFalls")
        {
           
            isThrowable = false;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Walls" || other.gameObject.tag == "PitFalls")
        {
            
            isThrowable = false;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Walls" || other.gameObject.tag == "PitFalls")
        {
         
            isThrowable = true;
        }
    }


    public bool GetIsThrowable()
    {
        return isThrowable;
    }
}

