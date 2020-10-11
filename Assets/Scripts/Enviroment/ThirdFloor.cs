using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdFloor : MonoBehaviour
{
    
    public static ThirdFloor instance { get; private set; }

    [SerializeField]
    public GameObject[] secondFloorBlockers;
    public GameObject[] thirdFloorBlockers;
    public GameObject[] SwitchOrbs;
    public GameObject[] firstFloorEnemies;

    private int floor = 3;

    void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Thorn")
        {
            
            ThornController thornController = other.gameObject.GetComponent<ThornController>();

            if (SwitchOrbs != null)
            {
                foreach (GameObject orb in SwitchOrbs)
                {
                    orb.layer = LayerMask.NameToLayer("BossWalls");
                }
            }

            if (firstFloorEnemies != null)
            {
                foreach (GameObject enemy in firstFloorEnemies)
                {
                    enemy.layer = LayerMask.NameToLayer("BossWalls");
                    //Made weakpoint orb on bosswalls
                }
            }

            if (thornController.GetFloor() == 0)
            {
                thornController.SetFloor(3);
               
            }
        }
    }

    public int GetThirdFloor()
    {
        return floor;
    }

}
