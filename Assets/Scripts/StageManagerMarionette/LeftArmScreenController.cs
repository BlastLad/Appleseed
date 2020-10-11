using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArmScreenController : MonoBehaviour
{
    public static LeftArmScreenController instance { get; private set; }
    
    
    public float speed;// Start is called before the first frame update

    [SerializeField]
    private GameObject moveTarget;
    [SerializeField]
    private GameObject thornBlocker;
    public GameObject wallBlocker;
    private bool isMovingToFloor3 = false;
    private bool isMovingToStart = false;
    private bool isFallen = false;
    public float waitTime;

    public Vector2 rightPlatformLanding;

    public GameObject switchOrb;
    public GameObject ArrowSet;
    [SerializeField]
    GameObject appleseedThrowPrefab;
    GameObject throwSprite;
    [SerializeField]
    BoxCollider2D[] ropes;

    private bool throwCalled = false;


    private Vector3 startPosition;
    void Awake()
    {
        instance = this;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovingToFloor3 == true)
        {
            transform.position = Vector2.MoveTowards(GetComponentInParent<Transform>().position, new Vector2(-9.85f, 0.15f), (speed * Time.deltaTime));
            if (transform.position == new Vector3(-9.85f, 0.15f, 0f))
            {
                isMovingToFloor3 = false;
                StartCoroutine(ReturnToStart(waitTime));
            }
        }
        if (isMovingToStart == true)
        {
            transform.position = Vector2.MoveTowards(GetComponentInParent<Transform>().position, startPosition, (speed * Time.deltaTime));
            if (transform.position == startPosition)
            {
                isMovingToStart = false;
                MoveTimerMarionette.instance.BeginMoveSet();
            }
        }

        if (throwCalled == true && Vector2.Distance(throwSprite.transform.position, rightPlatformLanding) < 1.0f)
        {
            AppleseedController.instance.gameObject.SetActive(true);
            throwSprite.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Appleseed" && isFallen == false)
        {
            Debug.Log("Appleseed landed");
            isMovingToFloor3 = true;
            MoveTimerMarionette.instance.StopAllCoroutines();
            FirstFloor.instance.GetComponent<Collider2D>().enabled = false;
            thornBlocker.SetActive(false);
            wallBlocker.SetActive(true);
            //GetComponentInParent<Transform>().position = Vector2.MoveTowards(GetComponentInParent<Transform>().position, , (speed * Time.deltaTime));
            //transform.position = Vector2.MoveTowards(GetComponentInParent<Transform>().position, moveTarget.transform.position, (speed * Time.deltaTime));
        }
    }

    private IEnumerator ReturnToStart(float time)
    {
        yield return new WaitForSeconds(time);
        isMovingToStart = true;
        thornBlocker.SetActive(true);
        wallBlocker.SetActive(false);
        FirstFloor.instance.GetComponent<Collider2D>().enabled = true;
        AppleseedThrow();
        StartCoroutine(ReSpawnAppleseed(2.2f, throwSprite));
    }


    public void TheWallsFall()
    {
        if (RightArmScreenController.instance.GetFallState() == false)
        {
            AppleseedThrow();
            if (switchOrb.GetComponentInParent<SwitchDoorManagerController>().GetIsRed() == true)
            {
                switchOrb.GetComponentInParent<SwitchDoorManagerController>().SetOrbState();
            }
            switchOrb.GetComponent<BossOrb>().OrbOff();
            switchOrb.SetActive(false);
            
            
        }
        else { MoveTimerMarionette.instance.StopAllMoves(); }
        StopAllCoroutines();
        StartCoroutine(ReSpawnAppleseed(2.2f, throwSprite));
        speed = 4;
        isMovingToStart = true;
        FirstFloor.instance.GetComponent<Collider2D>().enabled = true;
        thornBlocker.SetActive(false);
        wallBlocker.SetActive(false);
        ArrowSet.SetActive(true);
        foreach (BoxCollider2D rope in ropes)
        {
            if (rope != null)
            {
                rope.enabled = true;
            }
        }
        StartCoroutine(TurnOffArrows(6f));
        isFallen = true;
        
        //You Can change layer with gameObject.layer = int
    }

    private IEnumerator TurnOffArrows(float time)
    {
        yield return new WaitForSeconds(time);
        ArrowSet.SetActive(false);
    }

    public bool GetFallState()
    {
        return isFallen;
    }

    private IEnumerator ReSpawnAppleseed(float time, GameObject appleseedThrown)
    {
        yield return new WaitForSeconds(time);
        AppleseedController.instance.gameObject.SetActive(true);
        if (throwSprite != null)
        {
            throwSprite.SetActive(false);
            Destroy(throwSprite);
        }
        throwCalled = false;
    }

    private void AppleseedThrow()
    {
        Debug.Log("This Was Called Hellp");
        if (throwCalled == true) { return; }
        else
        {
            throwCalled = true;
            Vector3 landingArea = new Vector3(rightPlatformLanding.x, rightPlatformLanding.y, 0);
            Vector3 direction = (landingArea - AppleseedController.instance.transform.position).normalized;
            throwSprite = Instantiate(appleseedThrowPrefab, AppleseedController.instance.gameObject.transform.position, Quaternion.identity);

            throwSprite.GetComponent<Rigidbody2D>().velocity = direction * 5.75f;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            throwSprite.GetComponent<Rigidbody2D>().rotation = angle;

            AppleseedController.instance.gameObject.SetActive(false);
            AppleseedController.instance.transform.position = rightPlatformLanding;


        }
    }
}
