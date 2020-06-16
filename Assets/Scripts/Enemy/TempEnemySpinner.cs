using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemySpinner : MonoBehaviour
{
    public Transform enemyTransform;// Start is called before the first frame update
    public float speed;
    public float pointA;
    public float pointB;
    public bool isCalled = false;
    public int callCount = 0;
    public int callCountMax;//112 is 180
    private float currentPoint;
    public bool isPatrol = true;
    void Start()
    {
        enemyTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        
        if (callCount > callCountMax)
        {
            if (isCalled == true) { return; }
            else
            {
                isCalled = true;
                StartCoroutine(WaitForSpin(5.0f));
            }
            
        }
        else
        {
            RotateCounterClockWise();
        }
       // = new Quaternion(0, 0, (enemyTransform.rotation.z + 0.01f), 0);
    }

    void RotateCounterClockWise()
    {
        Debug.Log("Called");
        enemyTransform.Rotate(Vector3.forward * speed * Time.deltaTime);
        callCount++;
    }

    void RotateClockWise()
    {
        Debug.Log("Clockwise Called");
        enemyTransform.Rotate(-Vector3.forward * speed * Time.deltaTime);
        callCount++;
    }

    private IEnumerator WaitForSpin(float timeToWait)
    {
        isCalled = true;
        
        if(currentPoint == pointA)
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
        RotateCounterClockWise();
        isCalled = false;
        
    }

    private void OnEnable()
    {
        callCount = 0;
        isCalled = false;
        currentPoint = pointB;
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
