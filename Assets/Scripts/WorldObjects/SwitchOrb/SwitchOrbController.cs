using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOrbController : MonoBehaviour
{
    Animator anim;
    AudioSource orbAudio;
    public AudioClip soundSFX;
    bool isRed = true;
    SwitchDoorManagerController systemManager;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        orbAudio = GetComponent<AudioSource>();
        systemManager = GetComponentInParent<SwitchDoorManagerController>();
    }



    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Thorn" || other.gameObject.tag == "WorldObject")
        {
           
                systemManager.SetOrbState();
          
                Destroy(other.gameObject);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AppleseedAttack")
        {
            systemManager.SetOrbState();
            
  
        }
    }

    public void ChangeOrbState()
    {
        isRed = !isRed;
        orbAudio.PlayOneShot(soundSFX, .3f);
        anim.SetBool("isRed", isRed);
    }
}
