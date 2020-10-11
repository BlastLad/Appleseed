using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRopeControl : MonoBehaviour
{
    public GameObject ropeController;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Thorn")
        {
            ropeController.GetComponent<RopeBaseController>().CutFromBoss();
        }
    }
}
