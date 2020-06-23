using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornController : MonoBehaviour
{
    private bool isOnFirstFloor;
    private bool isOnSecondFloor;
    private bool isOnThirdFloor;


    private GameObject[] blockers;

    private int currentFloor = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        if (currentFloor == 2)
        {
            DisableSecondFloorBlockers();
        }
    }


    void Start()
    {
        blockers = SecondFloor.Instance.secondFloorBlockers;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFloor == 1)
        {
            EnableSecondFloorBlockers();
        }
        else if (currentFloor == 2)
        {
            DisableSecondFloorBlockers();
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Walls" || other.gameObject.tag == "SmallWalls") {
            if (currentFloor == 2)
            {
                Physics2D.IgnoreLayerCollision(10, 16, true);
                Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.otherCollider);
                return;
            }
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "SecondFloorBlockers")
        {
            Destroy(gameObject);
        }
    }

    public void DisableSecondFloorBlockers()
    {
        foreach (GameObject blocker in blockers)
        {
            blocker.SetActive(false);
        }
    }

    public void EnableSecondFloorBlockers()
    {
        foreach (GameObject blocker in blockers)
        {
            blocker.SetActive(true);
        }
    }

    /*public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Girl" && collision.gameObject.tag != "MountingBounds") 
        {
            Debug.Log("on tigger reconozed");
        }
    }*/

    public void SetFloor(int floorNum)
    {
        currentFloor = floorNum;
    }

    public int GetFloor()
    {
        return currentFloor;
    }
}
