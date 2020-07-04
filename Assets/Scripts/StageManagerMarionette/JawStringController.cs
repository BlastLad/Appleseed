using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawStringController : MonoBehaviour
{
    public GameObject ropeSprite;// Start is called before the first frame update
    private bool isCut = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Thorn" && isCut == false)
        {
            Destroy(ropeSprite);
            isCut = true;
            BossJawController.instance.CheckJaw();
        }
    }

    public bool GetCutState()
    {
        return isCut;
    }
}
