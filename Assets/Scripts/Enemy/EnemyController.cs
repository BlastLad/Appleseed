using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{
    
    GameObject targetPlayer;
    private GameObject arrestedPlayer;
    public Vector3 startingPosition;
    Rigidbody2D rb;
    AudioSource enemyAudio;

    public bool isHunting;
    public bool isArresting;
    private bool found = false;
    bool suspicious = false;
    public float targetRange = 6.35f;
    public float rangeSetter;
    public float speed;
    public float moveDelay;

    Seeker seeker;
    Path path;
    int currentWaypoint = 0;
    public Transform targetDestination;
    public float nextWaypointDistance = 3f;
    bool reachedEndOfPath = false;
    public Transform parentSprite;
    [SerializeField]
    GameObject teleportPrefab;

 
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        enemyAudio = GetComponent<AudioSource>();
        seeker = GetComponent<Seeker>();
        InvokeRepeating("UpdatePath", 0f, .5f);
        seeker.StartPath(rb.position, targetDestination.position, OnPathComplete);
    }
  
    // FixedUpdate is called at a fixed rate
    void FixedUpdate()
    {
      
        if (suspicious == true) { StartCoroutine(ResetSuspicion(3.0f)); }
        if (path != null)
        {
            if (currentWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
                return;
            }
            else
            {
                reachedEndOfPath = false;
            }
        }

        if (isHunting)
        {           
            if (Vector3.Distance(transform.position, targetPlayer.transform.position) > targetRange)
            {
                FindPlayerWithRay();
                if (found == false)
                {
                    SetHunt(false);
                    StartCoroutine(ReturnToStart(2.0f));
                                       
                }
                return;
            }
            else
            {
                CalculateRay();
                targetDestination = targetPlayer.transform;
                Vector2 moveDirection = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
                Vector2 force = moveDirection * speed * Time.deltaTime;
                float pathFindDistance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
                if (path.GetTotalLength() < 2f)
                {
                    CalculateRay();
                    
                    rb.AddForce(force / 2.2f, ForceMode2D.Impulse);
                    CalculateRay();
                }
                else
                {
                    CalculateRay();//Maybe remove the doubel calculate
                    rb.drag = 2f;
                    rb.AddForce(force);
                    CalculateRay();
                }
                if (pathFindDistance < nextWaypointDistance)
                {
                    currentWaypoint++;
                }
            }
        }
    }

    void UpdatePath()
    {
        if (seeker.IsDone() && targetPlayer != null)
        {
            seeker.StartPath(rb.position, targetDestination.position, OnPathComplete);
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
                StartCoroutine(FuzzyDetection(0.5f, targetPosition));
                if (Vector3.Distance(transform.position, targetPosition) < targetRange) { BeginHuntMode(); }
            }
        }
        else if (isArresting == false)
        {
            StartCoroutine(FuzzyDetection(0.5f, targetPosition));
            if (Vector3.Distance(transform.position, targetPosition) < targetRange) { BeginHuntMode(); }
        }//can also be called with a longer time for appleseed in play dead
    }

    public void FindtargetFromCircle(GameObject target)
    {
        Vector3 targetPosition = target.transform.position;
        targetPlayer = target.gameObject;
        if (isHunting == false) { targetRange = 2f; }


        if (isArresting == false)
        {
            StartCoroutine(FuzzyDetection(0.75f, targetPosition));
            if (Vector3.Distance(transform.position, targetPosition) < targetRange) { BeginHuntMode(); }
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    private IEnumerator FuzzyDetection(float timeToWait, Vector3 targetPosition)
    {       
        yield return new WaitForSeconds(timeToWait);

            targetRange = rangeSetter + 0.65f ;
            suspicious = true;
            if (Vector3.Distance(transform.position, targetPosition) < targetRange)
            {
                targetRange = 10.0f;
            }
    }

    private IEnumerator EnemyMoveDelay(float timeToWait)
    {
        GetComponentInChildren<SightConeMaterialController>().SetRed();
        yield return new WaitForSeconds(timeToWait);
        if (isArresting == false)
        {
            SetHunt(true);
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void BeginHuntMode()
    {
        GetComponent<PawnMovementController>().enabled = false;
        StartCoroutine(EnemyMoveDelay(moveDelay));
        
    }
    private IEnumerator ReturnToStart(float waitForSeconds)
    {
        GetComponentInChildren<SightConeMaterialController>().SetYellow();
        yield return new WaitForSeconds(waitForSeconds);
        transform.position = startingPosition;
        GetComponent<PawnMovementController>().enabled = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        suspicious = false;
        
    }

    private IEnumerator ReturnToStartFromArrest(float waitForSeconds)
    {
        GetComponent<FieldOfView>().enabled = true;
        
        arrestedPlayer = null;
        Instantiate(teleportPrefab, new Vector3(transform.position.x, transform.position.y + 0.05f, 0), Quaternion.identity);
        Instantiate(teleportPrefab, startingPosition, Quaternion.identity);
        yield return new WaitForSeconds(waitForSeconds);
        GetComponentInChildren<MeshRenderer>().enabled = true;
        GetComponentInChildren<SightConeMaterialController>().SetYellow();
        transform.position = startingPosition;
        isArresting = false;
        GetComponent<PawnMovementController>().enabled = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        suspicious = false;
        
    }

    public void FindPlayerWithRay()
    {
        int layerMask = LayerMask.GetMask("Girl", "Appleseed", "Objects", "Walls");
        Vector3 direction = (targetPlayer.transform.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Vector3.Distance(transform.position, targetPlayer.transform.position), layerMask);
        
        if (hit)
        {
            if (hit.collider.gameObject.tag == "Appleseed" || hit.collider.gameObject.tag == "Girl")
            {
                
                targetDestination = targetPlayer.transform;
                found = true;
            }
            else { found = false; }
        }
    }

    private void CalculateRay()
    {
        int layerMask = LayerMask.GetMask("Girl", "Appleseed", "Objects", "Walls", "SmallWalls");
        Vector3 direction = (targetPlayer.transform.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        rb.rotation = angle;
          
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Vector3.Distance(transform.position, targetPlayer.transform.position), layerMask);
        if (hit)
        {
            if (hit.collider.gameObject.tag != "Appleseed" || hit.collider.gameObject.tag != "Girl")
            {
                targetRange -= 0.01f;
            }
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
                GetComponentInChildren<PawnAnimationController>().ArrestTrigger();
                               
            }
            else if (other.gameObject.tag == "Girl")
            {
                ArrestPlayer(other.gameObject);
                other.gameObject.GetComponent<GirlController>().EnterCaptured();
                GetComponentInChildren<PawnAnimationController>().ArrestTrigger();
                
            }
        }
        
        if (isArresting)
        {
            if (other.gameObject.tag == "Thorn")
            {
                ArrestFailed();
                GetComponent<ArrestController>().DeacivateGameOverTimer();
                StartCoroutine(ReturnToStartFromArrest(1.9f));
               
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
                GetComponentInChildren<PawnAnimationController>().ArrestTrigger();
               
            }
            else if (other.gameObject.tag == "Girl")
            {
                ArrestPlayer(other.gameObject);
                other.gameObject.GetComponent<GirlController>().EnterCaptured();
                GetComponentInChildren<PawnAnimationController>().ArrestTrigger();
             
            }
        }

        if (isArresting)
        {
            if (other.gameObject.tag == "Thorn")
            {
                ArrestFailed();
                GetComponent<ArrestController>().DeacivateGameOverTimer();
                StartCoroutine(ReturnToStartFromArrest(1.9f));
                
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
                StartCoroutine(ReturnToStartFromArrest(1.9f));
              
            }
        }
    }

    private void ArrestPlayer(GameObject playerUnderArrest)//Maybe pass in object
    {
                
        GetComponent<FieldOfView>().enabled = false;
        GetComponentInChildren<SightConeMaterialController>().SetYellow();
        GetComponentInChildren<MeshRenderer>().enabled = false;
        arrestedPlayer = playerUnderArrest;
        isHunting = false;
        isArresting = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        HealthSystem.instance.TakeDamage(1);
        GetComponent<ArrestController>().ActivateGameOverTimer();
      

    }

    private void ArrestFailed()
    {

        if (arrestedPlayer.tag == "Girl")
        {
            arrestedPlayer.GetComponent<GirlController>().EnterMain();
        }
        if (arrestedPlayer.tag == "Appleseed")
        {
            arrestedPlayer.GetComponent<AppleseedController>().EnterCaptured();
        }
        GetComponentInChildren<PawnAnimationController>().SetArrest(false);

    }

    private IEnumerator ResetSuspicion(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        suspicious = false;
    }
    public bool GetHuntState() { return isHunting; }
    public void SetHunt(bool setter) { isHunting = setter; }
    public bool GetArrestState() { return isArresting; }
}

/*Origional Script For Enemy Controller
 * using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    GameObject targetPlayer;
    public bool isHunting;
    public bool isArresting;
    public float targetRange = 6.35f;
    Vector3 startingPosition;
    private bool found = false;
    bool suspicious = false;
    Rigidbody2D rb;
    [SerializeField]
    private GameObject arrestedPlayer;


    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (suspicious == true) { StartCoroutine(ResetSuspicion(3.0f)); }

        if (isHunting)
        {
            if (Vector3.Distance(transform.position, targetPlayer.transform.position) > targetRange)
            {
                FindPlayerWithRay();
                if (found == false)
                {
                    SetHunt(false);
                    StartCoroutine(ReturnToStart(2.0f));
                    Debug.Log("false");
                    
                }
                return;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPlayer.transform.position, (speed * Time.deltaTime));
                //AIDestinationSetter destination = GetComponent<AIDestinationSetter>();
                //destination.GetComponent<AIDestinationSetter>().target = targetPlayer.transform;
                CalculateRay();
            }//speed += 0.13f;
        }
    }

    public void FindTarget(GameObject target)
    {

        Vector3 targetPosition = target.transform.position;
        targetPlayer = target.gameObject;
        if (isHunting == false) { targetRange = 6.35f; }



        if (targetPlayer.tag == "Appleseed" && isArresting == false)
        {
            bool isTargetPlayingDead = targetPlayer.GetComponent<AppleseedController>().GetPlayDeadState();
            if (isTargetPlayingDead == true)
            {
                StartCoroutine(FuzzyDetection(2.0f, targetPosition));
                if (suspicious == false) { targetRange = 0.1f; }                
                if (Vector3.Distance(transform.position, targetPosition) < targetRange)
                {
                    GetComponent<TempEnemySpinner>().enabled = false;
                    StartCoroutine(EnemyMoveDelay(1.5f));
                    Debug.Log("Enemy About to Move");
                }
                Debug.Log("AppleseedFound");
            }
            else
            {
                StartCoroutine(FuzzyDetection(0.5f, targetPosition));
                if (Vector3.Distance(transform.position, targetPosition) < targetRange)
                {
                    GetComponent<TempEnemySpinner>().enabled = false;
                    StartCoroutine(EnemyMoveDelay(1.5f));
                    Debug.Log("Hello");
                }
            }
        }
        else if (isArresting == false)
        {
            StartCoroutine(FuzzyDetection(0.5f, targetPosition));
            if (Vector3.Distance(transform.position, targetPosition) < targetRange)
            {
                GetComponent<TempEnemySpinner>().enabled = false;
                StartCoroutine(EnemyMoveDelay(1.5f));
                Debug.Log("Hello");
            }
        }//can also be called with a longer time for appleseed in play dead
    }

    public void FindtargetFromCircle(GameObject target)
    {
        Vector3 targetPosition = target.transform.position;
        targetPlayer = target.gameObject;
        if (isHunting == false) { targetRange = 2f; }


        if (isArresting == false)
        {
            StartCoroutine(FuzzyDetection(0.75f, targetPosition));//Next goal is to not have this detect player but have the enenmy spin to the direction of player
            if (Vector3.Distance(transform.position, targetPosition) < targetRange)
            {
                GetComponent<TempEnemySpinner>().enabled = false;
                StartCoroutine(EnemyMoveDelay(1.5f));
                Debug.Log("Hello");
            }
        }
    }

    public void SetHunt(bool setter)
    {
        isHunting = setter;
    }


    private IEnumerator FuzzyDetection(float timeToWait, Vector3 targetPosition)
    {
         
        yield return new WaitForSeconds(timeToWait);
        
            targetRange = 6.55f;
            suspicious = true;
            if (Vector3.Distance(transform.position, targetPosition) < targetRange)
            {
                targetRange = 10.0f;
            }
        //}
    }

    private IEnumerator EnemyMoveDelay(float timeToWait)
    {
        GetComponentInChildren<SightConeMaterialController>().SetRed();
        yield return new WaitForSeconds(timeToWait);
        if (isArresting == false)
        {
            SetHunt(true);
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        //isWaitingToMove = false;
    }

    private IEnumerator ReturnToStart(float waitForSeconds)
    {
        GetComponentInChildren<SightConeMaterialController>().SetYellow();
        yield return new WaitForSeconds(waitForSeconds);
        transform.position = startingPosition;
        GetComponent<TempEnemySpinner>().enabled = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        suspicious = false;
        Debug.Log("ReturnToStart Called");
    }

    private IEnumerator ReturnToStartFromArrest(float waitForSeconds)
    {
        GetComponent<FieldOfView>().enabled = true;
        
        arrestedPlayer = null;       
        yield return new WaitForSeconds(waitForSeconds);
        GetComponentInChildren<MeshRenderer>().enabled = true;
        GetComponentInChildren<SightConeMaterialController>().SetYellow();
        transform.position = startingPosition;
        isArresting = false;
        GetComponent<TempEnemySpinner>().enabled = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        suspicious = false;
        Debug.Log("ReturnToStart Called");
    }

    public void FindPlayerWithRay()
    {
        int layerMask = LayerMask.GetMask("Girl", "Appleseed", "Objects", "Walls");
        Vector3 direction = (targetPlayer.transform.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Vector3.Distance(transform.position, targetPlayer.transform.position), layerMask);
        //isWaitingToMove = true;//new
        if (hit)
        {
            if (hit.collider.gameObject.tag == "Appleseed" || hit.collider.gameObject.tag == "Girl")
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPlayer.transform.position, (speed * Time.deltaTime));
                //AIDestinationSetter destination = GetComponent<AIDestinationSetter>();
                //destination.GetComponent<AIDestinationSetter>().target = targetPlayer.transform;
                found = true;
            }
            else { found = false; }
        }
    }

    private void CalculateRay()
    {
        int layerMask = LayerMask.GetMask("Girl", "Appleseed", "Objects", "Walls");
        Vector3 direction = (targetPlayer.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        rb.rotation = angle;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Vector3.Distance(transform.position, targetPlayer.transform.position), layerMask);
        //isWaitingToMove = true;//new
        if (hit)
        {
            if (hit.collider.gameObject.tag != "Appleseed" || hit.collider.gameObject.tag != "Girl")
            {
                targetRange -= 0.01f;
            }
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
                StartCoroutine(ReturnToStartFromArrest(2.0f));
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
                StartCoroutine(ReturnToStartFromArrest(2.0f));
                Debug.Log("Knocked Out");
            }
        }
    }

    private void ArrestPlayer(GameObject playerUnderArrest)//Maybe pass in object
    {
        Debug.Log("Arrest Called");
        
        
        GetComponent<FieldOfView>().enabled = false;
        GetComponentInChildren<SightConeMaterialController>().SetYellow();
        GetComponentInChildren<MeshRenderer>().enabled = false;
        //speed = 0;
        arrestedPlayer = playerUnderArrest;
        isHunting = false;
        isArresting = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<ArrestController>().ActivateGameOverTimer();
        //need the timer for the shows over game over

    }

    private void ArrestFailed()
    {

        if (arrestedPlayer.tag == "Girl")
        {
            arrestedPlayer.GetComponent<GirlController>().EnterMain();
        }
        if (arrestedPlayer.tag == "Appleseed")
        {
            arrestedPlayer.GetComponent<AppleseedController>().EnterCaptured();
        }
    }

    private IEnumerator ResetSuspicion(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        suspicious = false;
    }
    public bool GetHuntState()
    {
        return isHunting;
    }

    public bool GetArrestState()
    {
        return isArresting;
    }
}
*/
