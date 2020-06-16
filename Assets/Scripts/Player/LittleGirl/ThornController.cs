using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Walls" || other.gameObject.tag == "SmallWalls") {
            Destroy(gameObject);        
        }
        else if (other.gameObject.tag == "Soul-dier")
        {
            bool isArresting = other.gameObject.GetComponent<EnemyController>().GetArrestState();//GetCaptureState
            if (isArresting == false)
            {
                Destroy(gameObject);
            }
            
        }
    }
}
