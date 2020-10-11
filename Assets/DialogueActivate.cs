using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivate : MonoBehaviour
{
    [SerializeField]
    GameObject triggerObject;
    private bool activated = false;
    public bool enemyAttachment = false;
    public GameObject enemy;
  

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Thorn" && activated == false)
        {
            activated = true;
            if (enemyAttachment == true)
            {
                enemy.transform.rotation = Quaternion.Euler(0, 0, 0);
                enemy.GetComponent<PawnMovementController>().enabled = false;
            }
            triggerObject.GetComponent<TestDialogue>().DifferentActivation();
            
        }
    }
}
