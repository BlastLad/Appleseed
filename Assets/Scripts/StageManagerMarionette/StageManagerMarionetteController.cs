using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManagerMarionetteController : MonoBehaviour
{
    public static StageManagerMarionetteController instance { get; private set; }
    
    
    [SerializeField]
    private GameObject weakPointOrb;
    [SerializeField]
    private GameObject BossFieldOfViewObject;
    private int hitNumber;// Start is called before the first frame update
    private bool isSearching = false;
    private float spinSpeed = 45;
    private int callCount = 0;
    private GameObject[] players = new GameObject[2];
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
        StartRollCall();
        //StartCoroutine(StartCurtainCallRight());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isSearching == true)
        {
            BossFieldOfViewObject.transform.Rotate(-Vector3.forward * spinSpeed * Time.deltaTime);
            callCount++;
            if (callCount > 150)
            {
                isSearching = false;
                RollCallCheck();
            }          
        }
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


    public void StartRollCall()
    {
        isSearching = true;
        BossFieldOfViewObject.SetActive(true);
        BossFieldOfViewObject.transform.rotation = Quaternion.Euler(0, 0, 70);
    }

    public void RollCallCheck()
    {
        callCount = 0;
        BossFieldOfViewObject.transform.rotation = Quaternion.Euler(0, 0, 70);
        BossFieldOfViewObject.SetActive(false);
        SonicShuffle();
    }


    public void AddTarget(GameObject target)
    {
        Vector3 targetPosition = target.transform.position;
        GameObject targetPlayer = target.gameObject;
      

        if (targetPlayer.tag == "Appleseed")
        {
            bool isTargetPlayingDead = targetPlayer.GetComponent<AppleseedController>().GetPlayDeadState();
            if (isTargetPlayingDead == true)
            {             
                Debug.Log("AppleseedNotFound");
                
            }
            else
            {
                Debug.Log("AppleseedFound");
                players.SetValue(targetPlayer, 0);
            }
        }
        else if (targetPlayer.tag == "Girl")
            {
            Debug.Log("EliseFound");
            players.SetValue(targetPlayer, 1);
        }//can also be called with
    }

    public void SonicShuffle()
    {
        foreach(GameObject player in players)
        {
            if (player != null)
            {
                if (player.transform.position.x < 0)
                {
                    player.transform.position = new Vector3(4.4f, -3.3f);
                }
                else
                {
                    player.transform.position = new Vector3(-4.4f, -3.3f);
                }
            }
        }

        EndRollCall();
    }

    public void EndRollCall()
    {
        players.SetValue(null, 0);
        players.SetValue(null, 1);
        StartRollCall();
    }

}
