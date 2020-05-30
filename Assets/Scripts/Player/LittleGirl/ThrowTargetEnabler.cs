using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowTargetEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Walls")
        {
            Debug.Log("Can Not Throw");
            gameObject.GetComponentInParent<GirlController>().SetThrowable(false);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Walls")
        {
            Debug.Log("Can Throw");
            gameObject.GetComponentInParent<GirlController>().SetThrowable(true);
        }
    }
}

