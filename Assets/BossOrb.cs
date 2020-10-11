using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOrb : MonoBehaviour
{
    public GameObject openSprite;
    public GameObject closeSprite;



    public void OrbOff()
    {
        closeSprite.GetComponent<SpriteRenderer>().enabled = true;
        openSprite.GetComponent<SpriteRenderer>().enabled = false;
        
    }
}
