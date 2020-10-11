using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackPitController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AppleseedAttack" || other.gameObject.tag == "WorldObject")
        {
            return;
        }
        else
        {
            if (other.gameObject.tag == "Appleseed" || other.gameObject.tag == "Girl")
            {
               
            }
        }
    }
}
