using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeakPointController : MonoBehaviour
{
    public GameObject parentEnemy;// Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        bool huntState = GetComponentInParent<SightConeMaterialController>().GetIsRed();
        if (other.gameObject.tag == "AppleseedAttack" && huntState == true)
        {
            bool isBehind = other.GetComponentInParent<AppleseedController>().GetBehindState();
            if (isBehind == true)
            {
                Destroy(parentEnemy);
            }
        }
    }
}
