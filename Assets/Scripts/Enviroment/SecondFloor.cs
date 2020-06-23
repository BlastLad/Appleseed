using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondFloor : MonoBehaviour
{
    public static SecondFloor Instance { get; private set; }

    [SerializeField]
    public GameObject[] secondFloorBlockers;

    private int floor = 2;// Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Thorn")
        {
            Debug.Log("Collision" + other.name + "Floor2)");
            ThornController thornController = other.gameObject.GetComponent<ThornController>();

            if (thornController.GetFloor() == 0)
            {
                thornController.SetFloor(2);
                Debug.Log(thornController.GetFloor());
            }
        }
    }



    public int GetSecondFloor()
    {
        return floor;
    }
}
