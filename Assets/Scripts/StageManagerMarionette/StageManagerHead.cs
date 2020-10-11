using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManagerHead : MonoBehaviour
{
    Animator anim;// Start is called before the first frame update
    AudioSource recardoAudio;
    public AudioClip lightThatFireSound;
    public GameObject preshowShadow;
    public GameObject afterDefeatWalls;
    public GameObject beforeDefeatWall;
    void Start()
    {
        anim = GetComponent<Animator>();
        recardoAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startEyes()
    {
        anim.SetTrigger("StartUp");
        Destroy(preshowShadow);

    }


    public void lightThatFireUpInTheNight()
    {
        anim.SetBool("CurrentlyInMove", true);
        recardoAudio.PlayOneShot(lightThatFireSound);
        anim.SetTrigger("UsingMove");
    }
    

    public void lightsOut()
    {
        anim.SetBool("CurrentlyInMove", false);
    }

    public void SetDefeated()
    {
        anim.SetBool("IsDefeated", true);
        GetComponent<SpriteRenderer>().sortingLayerName = "AboveGround";
        GetComponent<SpriteRenderer>().sortingOrder = 2;
        AppleseedController.instance.gameObject.transform.position = new Vector3(0.61f, 4.526952f, 0f);
        GirlController.Instance.gameObject.transform.position = new Vector3(-0.51f, 4.526952f, 0f);
        afterDefeatWalls.SetActive(true);
        beforeDefeatWall.SetActive(false);

    }
}
