using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingZone : MonoBehaviour
{
    public GameObject appleseedPrefab;// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
