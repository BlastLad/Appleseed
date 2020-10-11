using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightConeMaterialController : MonoBehaviour
{
    public Material yellowCone;
    public Material redCone;
    public bool isRed = false;
    AudioSource enemyAudio;

    [SerializeField]
    AudioClip sightSFX;
    void Start()
    {
        GetComponent<MeshRenderer>().material = yellowCone;
        enemyAudio = GetComponent<AudioSource>();
    }


    public void SetYellow()
    {
        GetComponent<MeshRenderer>().material = yellowCone;
        isRed = false;
    }

    public void SetRed()
    {
        GetComponent<MeshRenderer>().material = redCone;
        if (isRed == false) { enemyAudio.PlayOneShot(sightSFX); }     
        isRed = true;
    }

    public bool GetIsRed()
    {
        return isRed;
    }
}
