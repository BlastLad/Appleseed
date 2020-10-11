using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemyRotationEvent : MonoBehaviour
{
    [SerializeField]
    GameObject enemyObject;
    public float startingZposition;
    

    public void BeginEvent()
    {
        enemyObject.transform.rotation = Quaternion.Euler(0, 0, startingZposition);
        
        enemyObject.GetComponent<PawnMovementController>().enabled = false;
    }

    public void StartEnemy()
    {
        enemyObject.GetComponent<PawnMovementController>().enabled = true;
    }
}
