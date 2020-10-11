using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightEnemyController : MonoBehaviour
{
    [SerializeField]
    private GameObject dropShadow;
    [SerializeField]
    private GameObject ropeHolder = null;
    public GameObject destructionPrefab;
    GameObject targetPlayer;
    private GameObject arrestedPlayer;
    Vector3 startingPosition;
    Rigidbody2D rb;
    Animator stageLightAnim;
    [SerializeField]
    Animator headLightAnim;
    [SerializeField]
    GameObject[] attachedRopes;

    public bool isHunting;
    public bool isArresting;
    private bool found = false;
    private bool isVulnerable = false;
    bool suspicious = false;
    public float targetRange = 6.35f;
    public float rangeSetter;
    public float speed;
    public float moveDelay;

    public Vector2 forceDirection = new Vector2(1, 0);

    public Transform targetDestination;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        stageLightAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (isHunting)
        {
            if (Vector3.Distance(transform.position, targetPlayer.transform.position) > targetRange)
            {
                
                if (found == false)
                {
                    SetHunt(false);
                   
                    Debug.Log("false");

                }
                return;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, dropShadow.transform.position, (speed * Time.deltaTime));

                if (Vector2.Distance(dropShadow.transform.position, transform.position) < 0.2f)///used to be equals
                {
                    Debug.Log("Position Reached");
                    SetHunt(false);
                    GetComponent<SpotlightMovementController>().ReturnToStart(startingPosition, speed - 1);
                    
                }
               
            }
        }   
    }
    public void FindTarget(GameObject target)
    {
      
        Vector3 targetPosition = target.transform.position;
        targetPlayer = target.gameObject;

        if (isHunting == false) { targetRange = rangeSetter; }
        if (targetPlayer.tag == "Appleseed" && isArresting == false)
        {
        bool isTargetPlayingDead = targetPlayer.GetComponent<AppleseedController>().GetPlayDeadState();
        if (isTargetPlayingDead == true)
        {
            StartCoroutine(FuzzyDetection(2.0f, targetPosition));
            if (suspicious == false) { targetRange = 0.1f; }
            if (Vector3.Distance(transform.position, targetPosition) < targetRange) { BeginHuntMode(); }
            Debug.Log("AppleseedFound");
        }
        else
        {
            StartCoroutine(FuzzyDetection(0.2f, targetPosition));
            if (Vector3.Distance(transform.position, targetPosition) < targetRange) { BeginHuntMode(); }
        }
             }
        else    if (isArresting == false)
        {
            StartCoroutine(FuzzyDetection(0.2f, targetPosition));
            if (Vector3.Distance(transform.position, targetPosition) < targetRange) { BeginHuntMode(); }
        }//can also be called with a longer time for appleseed in play dead
    }

    private IEnumerator FuzzyDetection(float timeToWait, Vector3 targetPosition)
    {
        yield return new WaitForSeconds(timeToWait);

        targetRange = rangeSetter + 0.65f;
        suspicious = true;
        if (Vector3.Distance(transform.position, targetPosition) < targetRange)
        {
            targetRange = 10.0f;
        }
    }

    private void BeginHuntMode()
    {
        
        stageLightAnim.SetBool("IsHunting", true);
        headLightAnim.SetBool("IsHunting", true);
        StartCoroutine(EnemyMoveDelay(moveDelay));
        Debug.Log("Enemy About to Move");
    }

    private IEnumerator EnemyMoveDelay(float timeToWait)
    {
        dropShadow.GetComponentInChildren<SightConeMaterialController>().SetRed();
        yield return new WaitForSeconds(timeToWait);
        if (isArresting == false)
        {
            SetHunt(true);
            gameObject.layer = LayerMask.NameToLayer("Enemy");
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)//May need to make on collision Stay
    {
        if (isHunting)
        {
            if (other.gameObject.tag == "Appleseed")
            {
                ArrestPlayer(other.gameObject);
                other.gameObject.GetComponent<AppleseedController>().EnterCaptured();
                Debug.Log("PlayerCaptured");
                Debug.Log("+1 Strike");
            }
            else if (other.gameObject.tag == "Girl")
            {
                ArrestPlayer(other.gameObject);
                other.gameObject.GetComponent<GirlController>().EnterCaptured();
                Debug.Log("PlayerCaptured");
                Debug.Log("+1 Strike");
            }
        }

        if (isArresting)
        {
            if (other.gameObject.tag == "Thorn")
            {
                ArrestFailed();
                GetComponent<ArrestController>().DeacivateGameOverTimer();
               
                GetComponent<SpotlightMovementController>().ReturnToStart(startingPosition, speed);
                Debug.Log("Knocked Out");
                Destroy(other.gameObject);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D other)//This May cause problems will have to see...
    {
        if (isHunting && !isArresting)
        {
            if (other.gameObject.tag == "Appleseed")
            {
                ArrestPlayer(other.gameObject);
                other.gameObject.GetComponent<AppleseedController>().EnterCaptured();
                Debug.Log("PlayerCaptured");
                Debug.Log("+1 Strike");
            }
            else if (other.gameObject.tag == "Girl")
            {
                ArrestPlayer(other.gameObject);
                other.gameObject.GetComponent<GirlController>().EnterCaptured();
                Debug.Log("PlayerCaptured");
                Debug.Log("+1 Strike");
            }
        }

        if (isArresting)
        {
            if (other.gameObject.tag == "Thorn")
            {
                ArrestFailed();
                GetComponent<ArrestController>().DeacivateGameOverTimer();
     
                GetComponent<SpotlightMovementController>().ReturnToStart(startingPosition, speed);
                Debug.Log("Knocked Out");
                Destroy(other.gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isArresting)
        {
            if (other.gameObject.tag == "AppleseedAttack")
            {
                ArrestFailed();
                GetComponent<ArrestController>().DeacivateGameOverTimer();
             
                GetComponent<SpotlightMovementController>().ReturnToStart(startingPosition, speed);
                Debug.Log("Knocked Out");
            }
        }
        if (isVulnerable)
        {
            if (other.gameObject.tag == "AppleseedAttack")
            {
                Instantiate(destructionPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    private void ArrestPlayer(GameObject playerUnderArrest)
    {
        Debug.Log("Arrest Called");
        dropShadow.GetComponent<SpotlightFieldOfView>().enabled = false;
        dropShadow.GetComponentInChildren<SightConeMaterialController>().SetYellow();
        dropShadow.GetComponentInChildren<MeshRenderer>().enabled = false;
        arrestedPlayer = playerUnderArrest;
        isHunting = false;
        isArresting = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        HealthSystem.instance.TakeDamage(1);
        GetComponent<ArrestController>().ActivateGameOverTimer();
        

    }

    public void ResetEnemy()
    {
        dropShadow.SetActive(true);
        dropShadow.GetComponent<SpotlightFieldOfView>().enabled = true;
        dropShadow.GetComponentInChildren<SightConeMaterialController>().SetYellow();
        stageLightAnim.SetBool("IsHunting", false);
        headLightAnim.SetBool("IsHunting", false);
        dropShadow.GetComponentInChildren<MeshRenderer>().enabled = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        suspicious = false;
        isArresting = false;
        SetHunt(false);
        gameObject.layer = LayerMask.NameToLayer("AboveGround");
        Debug.Log("ReturnToStart Called");
    }

    private void ArrestFailed()
    {

        arrestedPlayer.GetComponent<Rigidbody2D>().AddForce(forceDirection * 2550f);

        if (arrestedPlayer.tag == "Girl")
        {
            arrestedPlayer.GetComponent<GirlController>().EnterMain();
        }
        if (arrestedPlayer.tag == "Appleseed")
        {
            arrestedPlayer.GetComponent<AppleseedController>().EnterCaptured();
        }
    }

    public void StunEnemy()
    {
        isVulnerable = true;
        stageLightAnim.SetBool("IsStunned", true);
        headLightAnim.SetBool("IsStunned", true);
        foreach(GameObject rope in attachedRopes)
        {
            rope.GetComponent<SpriteRenderer>().enabled = false;
        }
        rb.SetRotation(270);
        StartCoroutine(EndStun(4f));
        gameObject.layer = LayerMask.NameToLayer("Enemy");
    }

    private IEnumerator EndStun(float time)
    {
        yield return new WaitForSeconds(time);       
        ropeHolder.GetComponent<RopeBaseController>().RespwanRopes();
        isVulnerable = false;
        stageLightAnim.SetBool("IsStunned", false);
        headLightAnim.SetBool("IsStunned", false);
        foreach (GameObject rope in attachedRopes)
        {
            rope.GetComponent<SpriteRenderer>().enabled = true;
        }
        rb.SetRotation(0);
        GetComponent<SpotlightMovementController>().ReturnToStart(startingPosition, 3);
        //RespawnRopes
    }


    public bool GetHuntState() { return isHunting; }
    public void SetHunt(bool setter) { isHunting = setter; }
    public bool GetArrestState() { return isArresting; }

    public bool GetVulnState() { return isVulnerable; }

    public void SetVulState(bool setter) { isVulnerable = setter; }
}
