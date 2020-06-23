using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Thorn")
        {
            Debug.Log("Collision" + other.name);
            ThornController thornController = other.gameObject.GetComponent<ThornController>();
            
            if (thornController.GetFloor() == 0) { thornController.SetFloor(1);
                Debug.Log(thornController.GetFloor()); }
     
        }
    }

  


}
