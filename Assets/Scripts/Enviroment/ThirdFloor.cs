using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdFloor : MonoBehaviour
{
    
    public static ThirdFloor instance { get; private set; }

    [SerializeField]
    public GameObject[] secondFloorBlockers;

    private int floor = 3;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Thorn")
        {
            Debug.Log("Collision" + other.name + "Floor3)");
            ThornController thornController = other.gameObject.GetComponent<ThornController>();

            if (thornController.GetFloor() == 0)
            {
                thornController.SetFloor(2);
                Debug.Log(thornController.GetFloor());
            }
        }
    }

    public int GetThirdFloor()
    {
        return floor;
    }

}
