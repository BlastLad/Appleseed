using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightMovementController : MonoBehaviour
{
    private bool isMoving = false;
    Vector3 startingPosition;
    float speed = 0;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, startingPosition, (speed * Time.deltaTime));
            if (Vector2.Distance(startingPosition, transform.position) < 0.2f)
            {
                transform.position = startingPosition;
              
                isMoving = false;
                GetComponent<SpotlightEnemyController>().ResetEnemy();
               
                
            }
        }
    }

    public void ReturnToStart(Vector3 startPos, float speedVal)
    {
        isMoving = true;
        startingPosition = startPos;
        speed = speedVal;
    }
}
