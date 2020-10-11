using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloor : MonoBehaviour
{
    public static FirstFloor instance { get; private set; }// Start is called before the first frame update

    public GameObject[] SwitchOrbs;
    public GameObject[] firstFloorEnemies;
    void Awake()
    {
        instance = this;
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Thorn")
        {
            
            ThornController thornController = other.gameObject.GetComponent<ThornController>();
         

            if (thornController.GetFloor() == 0) { thornController.SetFloor(1);
                if (SwitchOrbs != null)
                {
                    foreach (GameObject orb in SwitchOrbs)
                    {
                        orb.layer = LayerMask.NameToLayer("Objects");
                    }
                }

                if (firstFloorEnemies != null)
                {
                    foreach (GameObject enemy in firstFloorEnemies)
                    {
                        enemy.layer = LayerMask.NameToLayer("Default");
                    }
                }

            }
     
        }
    }

    


}
