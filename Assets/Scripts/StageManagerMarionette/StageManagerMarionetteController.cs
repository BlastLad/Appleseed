using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManagerMarionetteController : MonoBehaviour
{
    public static StageManagerMarionetteController instance { get; private set; }
    
    
    [SerializeField]
    private GameObject weakPointOrb;
    private int hitNumber;// Start is called before the first frame update

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Uh oh StageManagerController");
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        StartCoroutine(fire());
        //StartCoroutine(StartCurtainCallRight());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AppleseedAttack")
        {
            
            hitNumber++;
            Debug.Log("BossHit" + hitNumber);
            if (hitNumber >= 3)
            {
                Destroy(weakPointOrb);
            }
        }
    }


    private void DetermineCanonsToFireLeft(int totalToFire)
    {
        Debug.Log("DCTF Called");
        int occupiedSentNum = -1;
        for (int i = 0; i < totalToFire; i++)
        {

            int canonNum = Random.Range(0, 5);

            if (occupiedSentNum != -1)
            {
                if (canonNum == occupiedSentNum)
                {
                    canonNum = Random.Range(0, 5);
                }
            }

            if (i == 0)
            {
                occupiedSentNum = canonNum;
            }     

            Debug.Log("Fire Called" + canonNum);
            LeftHandCanonController.instance.FullFrontalBarrage(canonNum);
        }
    }

    private void DetermineCanonsToFireRight(int totalToFire)
    {
        Debug.Log("DCTF Called");
        int occupiedSentNum = -1;
        for (int i = 0; i < totalToFire; i++)
        {

            int canonNum = Random.Range(0, 5);

            if (occupiedSentNum != -1)
            {
                if (canonNum == occupiedSentNum)
                {
                    canonNum = Random.Range(0, 5);
                }
            }

            if (i == 0)
            {
                occupiedSentNum = canonNum;
            }

            Debug.Log("Fire Called" + canonNum);
            RightHandController.instance.FullFrontalBarrage(canonNum);
        }
    }


    public IEnumerator fire()
    {
        Debug.Log("Fire Called");
        yield return new WaitForSeconds(3);
        DetermineCanonsToFireLeft(3);
        DetermineCanonsToFireRight(2);
    }

    public IEnumerator StartCurtainCallLeft()
    {
        Debug.Log("Curtain Call called left");
        yield return new WaitForSeconds(3);
        LeftHandCanonController.instance.FullFrontalBarrage();
    }

    public IEnumerator StartCurtainCallRight()
    {
        Debug.Log("Curtain Call called right");
        yield return new WaitForSeconds(3);
        RightHandController.instance.FullFrontalBarrage();
    }
}
