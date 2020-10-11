using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossJawController : MonoBehaviour
{
    public static BossJawController instance { get; private set; }

    [SerializeField]
    private GameObject[] jawStrings;
    private Vector3 startingPosition;
    public Vector3 targetPosition;
    private bool isJawCut = false;
    public float speed;
    public bool isBossActive = false;

    private bool movingToStart = true;
    private bool movingToClosedPos = false;
    private bool isBossUsingMove = false;

    [SerializeField]
    GameObject weakOrb;
    [SerializeField]
    GameObject protectedOrb;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBossActive == false) { return; }

        if (isJawCut == false && movingToClosedPos == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, (speed * Time.deltaTime));
            if (transform.position == targetPosition)
            {
                movingToClosedPos = false;
                StartCoroutine(ReturnToStart(2f));
            }
        }
        else if (isJawCut == false && movingToStart == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, startingPosition, (speed * Time.deltaTime));
            if (transform.position == startingPosition)
            {
                if (speed == 2) { isJawCut = true; return; }
                movingToStart = false;
                movingToClosedPos = true;
            }
        }
    }

    private IEnumerator ReturnToStart(float time)
    {
        yield return new WaitForSeconds(time);
        movingToStart = true;
    }


    public void CheckJaw()
    {
        int sentValue = 0;
        foreach(GameObject jawString in jawStrings)
        {
            bool isStringCut = jawString.GetComponentInChildren<JawStringController>().GetCutState();//check if cut if both cut stop movement and destroy the box colliders
            if (isStringCut) { sentValue++; }
            if (sentValue == jawStrings.Length)
            {
                movingToClosedPos = false;
                isBossUsingMove = false;
                movingToStart = true;
                speed = 2;
                //weakOrb.SetActive(true);               
                //protectedOrb.SetActive(false);

            }
            //This method should be called when a jaw string is cut
        }
        if (speed == 2)
        {
            foreach (GameObject jawString in jawStrings)
            {
                Destroy(jawString);
            }
        }
    }
}
