using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloor : MonoBehaviour
{
    public static FirstFloor instance { get; private set; }// Start is called before the first frame update

    public GameObject[] SwitchOrbs;
    void Awake()
    {
        instance = this;
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
            /*if (SwitchOrbs != null)
            {
                if (SwitchOrbs[0].layer != LayerMask.NameToLayer("BossWalls"))
                {
                    foreach (GameObject orb in SwitchOrbs)
                    {
                        orb.layer = LayerMask.NameToLayer("Objects");
                    }
                }
               
            }*/

            if (thornController.GetFloor() == 0) { thornController.SetFloor(1);
                if (SwitchOrbs != null)
                {
                    foreach (GameObject orb in SwitchOrbs)
                    {
                        orb.layer = LayerMask.NameToLayer("Objects");
                    }
                }

                Debug.Log(thornController.GetFloor()); }
     
        }
    }

    


}
