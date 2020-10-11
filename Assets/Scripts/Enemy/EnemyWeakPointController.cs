using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeakPointController : MonoBehaviour
{
    public GameObject parentEnemy;
    public GameObject destructionPrefab;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool huntState = GetComponentInParent<SightConeMaterialController>().GetIsRed();
        if (other.gameObject.tag == "AppleseedAttack" && huntState == true)
        {
            bool isBehind = other.GetComponentInParent<AppleseedController>().GetBehindState();
            if (isBehind == true)
            {
                Instantiate(destructionPrefab, parentEnemy.transform.position, Quaternion.identity);
                Destroy(parentEnemy);
            }
        }
    }
}
