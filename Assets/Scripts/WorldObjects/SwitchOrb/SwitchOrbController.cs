using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOrbController : MonoBehaviour
{
    Animator anim;
    bool isRed = true;// Start is called before the first frame update
    SwitchDoorManagerController systemManager;
    void Start()
    {
        anim = GetComponent<Animator>();
        systemManager = GetComponentInParent<SwitchDoorManagerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Thorn" || other.gameObject.tag == "WorldObject")
        {
           
                systemManager.SetOrbState();
                //isRed = !isRed;
                //anim.SetBool("isRed", isRed);
                Destroy(other.gameObject);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AppleseedAttack")
        {
            systemManager.SetOrbState();
            //isRed = !isRed;
            //anim.SetBool("isRed", isRed);
  
        }
    }

    public void ChangeOrbState()
    {
        isRed = !isRed;
        anim.SetBool("isRed", isRed);
    }
}
