using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTypeChange : MonoBehaviour
{
    public float changeTime;
   

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "SandBag")
        {
            StartCoroutine(changeType(changeTime));
        }
    }

    public IEnumerator changeType(float time)
    {
        yield return new WaitForSeconds(time);
        GetComponent<PawnMovementController>().staticType = false;
        GetComponent<PawnMovementController>().rotateType = true;
    }
}
