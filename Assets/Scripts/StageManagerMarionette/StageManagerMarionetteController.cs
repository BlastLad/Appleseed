using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManagerMarionetteController : MonoBehaviour
{
    public static StageManagerMarionetteController instance { get; private set; }

    private AudioSource coreAudio;
    [SerializeField]
    private GameObject weakPointOrb;
    [SerializeField]
    private GameObject BossFieldOfViewObject;
    public GameObject bossHead;
    private int hitNumber;// Start is called before the first frame update
    private bool isSearching = false;
    private float spinSpeed = 45;
    private int callCount = 0;
    private GameObject[] players = new GameObject[2];
    [SerializeField]
    private GameObject dialogueTrigger;
    [SerializeField]
    GameObject teleportPrefab;
    [SerializeField]
    PlayerDataGameObject player;
    [SerializeField]
    GameObject topJaw;
    [SerializeField]
    AudioSource mainCamera;
    public Animator bossCenterPiece;

    public GameObject[] orbDamaged;
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
        coreAudio = GetComponent<AudioSource>();

    }

    void Start()
    {       
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
            coreAudio.Play();
            hitNumber++;

            Debug.Log("BossHit" + hitNumber);
            if (hitNumber >= 3)
            {
                player.BossDefeated(true);
                player.SavePlayer(true);
                bossHead.GetComponent<StageManagerHead>().SetDefeated();
                topJaw.GetComponent<SpriteRenderer>().sortingLayerName = "AboveGround";
                topJaw.GetComponent<SpriteRenderer>().sortingOrder = 6;
                dialogueTrigger.GetComponent<TestDialogue>().DifferentActivation();
                mainCamera.Stop();
                bossCenterPiece.SetBool("IsActive", false);
                Destroy(weakPointOrb);
            }
            else if (hitNumber == 2)
            {
                orbDamaged[1].SetActive(true);
                orbDamaged[0].SetActive(false);
            }
            else if (hitNumber == 1)
            {
                orbDamaged[0].SetActive(true);

            }
        }
    }


    public void DetermineCanonsToFireLeft(int totalToFire)
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

    public void DetermineCanonsToFireRight(int totalToFire)
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

    public void StartCurtainCallLeft()
    {
        Debug.Log("Curtain Call called left");       
        LeftHandCanonController.instance.FullFrontalBarrage();
    }

    public void StartCurtainCallRight()
    {
        Debug.Log("Curtain Call called right");
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
        bossHead.GetComponent<StageManagerHead>().lightsOut();
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
                    Instantiate(teleportPrefab, player.transform.position, Quaternion.identity);
                    Instantiate(teleportPrefab, new Vector3(4.4f, -3.3f), Quaternion.identity);
                    player.transform.position = new Vector3(4.4f, -3.3f);
                }
                else
                {
                    Instantiate(teleportPrefab, player.transform.position, Quaternion.identity);
                    Instantiate(teleportPrefab, new Vector3(-4.4f, -3.3f), Quaternion.identity);
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
        
    }

}
