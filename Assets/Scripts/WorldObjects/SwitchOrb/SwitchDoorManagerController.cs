using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoorManagerController : MonoBehaviour
{
    [SerializeField] GameObject[] switchOrbs;
    [SerializeField] GameObject[] redDoors;
    [SerializeField] GameObject[] whiteDoors;
    private bool isRed = true;// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetOrbState()
    {
        foreach  (GameObject orb in switchOrbs)
        {
            orb.GetComponent<SwitchOrbController>().ChangeOrbState();         
        }
        isRed = !isRed;
        foreach (GameObject redDoor in redDoors)
           {
                redDoor.gameObject.SetActive(isRed);
                foreach (GameObject whiteDoor in whiteDoors)
                {
                    whiteDoor.gameObject.SetActive(!isRed);
                }
           }
        
    }
}
