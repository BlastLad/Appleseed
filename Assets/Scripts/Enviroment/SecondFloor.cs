using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondFloor : MonoBehaviour
{
    public static SecondFloor Instance { get; private set; }

    [SerializeField]
    public GameObject[] secondFloorBlockers;
    public GameObject[] SwitchOrbs;
    public GameObject[] firstFloorEnemies;

    private int floor = 2;
    void Awake()
    {
        Instance = this;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Thorn")
        {
            
            ThornController thornController = other.gameObject.GetComponent<ThornController>();
            if (SwitchOrbs != null)
            {
                foreach(GameObject orb in SwitchOrbs)
                {
                    orb.layer = LayerMask.NameToLayer("BossWalls");
                }
            }

            if (firstFloorEnemies != null)
            {
                foreach (GameObject enemy in firstFloorEnemies)
                {
                    enemy.layer = LayerMask.NameToLayer("BossWalls");
                }
            }

            if (thornController.GetFloor() == 0)
            {
                thornController.SetFloor(2);
                
            }
        }
    }



    public int GetSecondFloor()
    {
        return floor;
    }



}
