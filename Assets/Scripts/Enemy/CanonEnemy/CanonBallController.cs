using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBallController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Walls" || other.gameObject.tag == "SmallWalls" || other.gameObject.tag == "Objects") 
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Girl" || other.gameObject.tag == "Appleseed")
        {
            HealthSystem.instance.TakeDamage(1);
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
