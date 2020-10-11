using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMovementController : MonoBehaviour
{
    public Transform enemyTransform;// Start is called before the first frame update
    public float speed;
    public float pointA;
    public float pointB;
    public float startingZPos;
    public float spinWaitModNum = 0f;
    private bool isCalled = false;
    private bool heardSound= false;
    private int callCount = 0;
    private int waypointIndex = 0;
    public int callCountMax;//112 is 180
    private float currentPoint;
    public bool isPatrol = true;
    bool isAbletoTurn = false;
    Transform targetPath;
    public Transform basePath;
    Vector2 direction;
    public float pointAStart;

    public bool rotateType = false;
    public bool staticType = false;
    public bool movementType = false;
    public bool rotateCounterClockWise = true;
    public bool shouldSwitchSpin = false;


    private GameObject soundSource = null;
    //[Header("insert movement type below; 1 Rotate, 2 static, 3 moving")]
    //public int enemyType = 0;

    void Awake()
    {
        enemyTransform = GetComponent<Transform>();
        
    }

    private void Start()
    {
        if (movementType == true)
        {
            targetPath = basePath.GetComponent<WayPointPathGet>().points[0];
            
        }
    }

    private void Update()
    {
        if (soundSource != null)
        {
            if (transform.position == soundSource.transform.position)
            {
                if (soundSource.gameObject.tag == "SandBag")
                {
                    heardSound = false;
                    enemyTransform.rotation = Quaternion.Euler(0, 0, startingZPos);
                    GetComponent<EnemyController>().startingPosition = soundSource.transform.position;
                    Destroy(soundSource.gameObject);
                    soundSource = null;
                }
            }
        }
        if (movementType == true)
        {
            direction = targetPath.position - transform.position;            
        }
    }
        // Update is called once per frame
        void FixedUpdate()
    {
        if (heardSound == true)
        {
            MoveToSound();
        }
        if (rotateType == true)
        {
            if (callCount > callCountMax)
            {
                if (isCalled == true) { return; }
                else
                {
                    isCalled = true;
                    StartCoroutine(WaitForSpin(5.0f - spinWaitModNum));
                    if (shouldSwitchSpin == true)
                    {
                        rotateCounterClockWise = !rotateCounterClockWise;
                    }
                }

            }
            else
            { if (rotateCounterClockWise == true)
                {
                    RotateCounterClockWise();
                }
            else
                {
                    RotateClockWise();
                }
            }
        }
        else if (movementType == true)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, targetPath.position, (speed/35 * Time.deltaTime));
            if (callCount < callCountMax && isAbletoTurn == true)
            {
                if (rotateCounterClockWise == true)
                {
                    RotateCounterClockWise();
                }
                else
                {
                    RotateClockWise();
                }
            }
            else if (callCount == callCountMax)
            {
                enemyTransform.rotation = Quaternion.Euler(0, 0, pointA);
                isAbletoTurn = false;
            }
            if (Vector2.Distance(transform.position, targetPath.position) <= 0.15f)
            {
                isAbletoTurn = true;
                GetNextWaypoint();
            }

            }
       
    }

    void RotateCounterClockWise()
    {
        
        enemyTransform.Rotate(Vector3.forward * speed * Time.deltaTime);
        callCount++;
    }

    void RotateClockWise()
    {
        enemyTransform.Rotate(-Vector3.forward * speed * Time.deltaTime);
        callCount++;
    }

    private IEnumerator WaitForSpin(float timeToWait)
    {
        isCalled = true;
        if (currentPoint == pointA)
        {
            currentPoint = pointB;
        }
        else
        {
            currentPoint = pointA;
        }

        enemyTransform.rotation = Quaternion.Euler(0, 0, currentPoint);
        yield return new WaitForSeconds(timeToWait);
        callCount = 0;
        if (rotateCounterClockWise == true)
        {
            RotateCounterClockWise();
        }
        else
        {
            RotateClockWise();
        }
        isCalled = false;

    }
    void GetNextWaypoint()
    {
        if (waypointIndex >= basePath.GetComponent<WayPointPathGet>().points.Length - 1)
        {
            waypointIndex = 0;
            return;
        }
        waypointIndex++;
        callCount = 0;
        
        if (rotateCounterClockWise == true)
        {
            pointA += 90;
        }
        else
        {
            pointA -= 90;
        }
        targetPath = basePath.GetComponent<WayPointPathGet>().points[waypointIndex];
    }

    public void MoveToSound()
    {
       
        Vector2 directionToTarget = (soundSource.transform.position - transform.position).normalized;

        float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg + 90f;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.rotation = angle;

      
        transform.position = Vector2.MoveTowards(transform.position, soundSource.transform.position, (speed / 35 * Time.deltaTime));
     
    }


    public void SetSoundSource(GameObject soundSourceOrigin)
    {
        heardSound = true;
        soundSource = soundSourceOrigin;
       
    }

    private void OnEnable()
    {
        heardSound = false;
        soundSource = null;
        if (rotateType == true)
        {
          
            callCount = 0;
            isCalled = false;
            currentPoint = pointB;
            rotateCounterClockWise = true;
            transform.rotation = Quaternion.Euler(0, 0, startingZPos);
        }
        else if(movementType == true)
        {
            waypointIndex = 0;
            targetPath = basePath.GetComponent<WayPointPathGet>().points[0];
            pointA = pointAStart;
        }
        else
        {
            enemyTransform.rotation = Quaternion.Euler(0, 0, startingZPos);
        }
        
    }
}
