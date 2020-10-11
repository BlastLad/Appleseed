using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingZone : MonoBehaviour
{
    public GameObject appleseedPrefab;
   

 

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ThrownObject")
        {
            Instantiate(appleseedPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
