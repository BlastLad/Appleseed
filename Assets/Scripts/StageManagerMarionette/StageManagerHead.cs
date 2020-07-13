using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManagerHead : MonoBehaviour
{
    Animator anim;// Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startEyes()
    {
        anim.SetTrigger("StartUp");

    }


    public void lightThatFireUpInTheNight()
    {
        anim.SetBool("CurrentlyInMove", true);
        anim.SetTrigger("UsingMove");
    }
    

    public void lightsOut()
    {
        anim.SetBool("CurrentlyInMove", false);
    }
}
