using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornController : MonoBehaviour
{
    private bool isOnFirstFloor;
    private bool isOnSecondFloor;
    private bool isOnThirdFloor;


    private GameObject[] blockers;
    private GameObject[] thirdBlockers;

    private int currentFloor = 0;

    private void Awake()
    {
        if (currentFloor == 2)
        {
            DisableSecondFloorBlockers();
            GetComponent<SpriteRenderer>().sortingLayerName = "AboveGround";
        }
        else if (currentFloor == 3)
        {
            DisableThirdFloorBlockers();
            DisableThirdFloorBlockers();
            GetComponent<SpriteRenderer>().sortingLayerName = "AboveGround";
        }
    }


    void Start()
    {
        if (SecondFloor.Instance)
        {
            blockers = SecondFloor.Instance.secondFloorBlockers;
        }
        if (ThirdFloor.instance)
        {
            thirdBlockers = ThirdFloor.instance.thirdFloorBlockers;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFloor == 1)
        {
            EnableSecondFloorBlockers();
            EnableThirdFloorBlockers();
            
        }
        else if (currentFloor == 2)
        {
            
            DisableSecondFloorBlockers();
            EnableThirdFloorBlockers();
        }
        else if (currentFloor == 3)
        {
            
            DisableSecondFloorBlockers();
            DisableThirdFloorBlockers();
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Walls" || other.gameObject.tag == "SmallWalls") {
            if (currentFloor == 2)
            {
                //Physics2D.IgnoreLayerCollision(10, 16, true);
                //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), other.otherCollider);

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

    public void DisableThirdFloorBlockers()
    {

        GetComponent<SpriteRenderer>().sortingLayerName = "AboveGround";
        if (thirdBlockers != null)
        {
            foreach (GameObject blocker in thirdBlockers)
            {
                blocker.SetActive(false);
            }
        }
    }

    public void EnableThirdFloorBlockers()
    {
        
      
        if (thirdBlockers != null)
        {
            foreach (GameObject blocker in thirdBlockers)
            {
                blocker.SetActive(true);
            }
        }
    }

    public void EnableSecondFloorBlockers()
    {
        foreach (GameObject blocker in blockers)
        {
            blocker.SetActive(true);
        }
    }

    public void SetFloor(int floorNum)
    {
        currentFloor = floorNum;
    }

    public int GetFloor()
    {
        return currentFloor;
    }
}
