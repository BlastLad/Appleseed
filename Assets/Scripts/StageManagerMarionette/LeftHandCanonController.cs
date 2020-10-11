using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandCanonController : MonoBehaviour
{
    public static LeftHandCanonController instance { get; private set; }


    [SerializeField]
    private GameObject[] cannons;
    [SerializeField]
    public GameObject[] fingers;
    [SerializeField]
    private GameObject[] lights;
    void Awake()
    {
        instance = this;
    }

 


    public void FullFrontalBarrage(int numberToFire)
    {
        Debug.Log("Full Frontal Called");
        BossCanonController currentCanon = cannons[numberToFire].GetComponent<BossCanonController>();
        lights[numberToFire].GetComponent<Animator>().SetBool("IsActive", true);
        StartCoroutine(TurnOutTheLights(lights[numberToFire]));
        fingers[numberToFire].GetComponent<Animator>().SetTrigger("CloseFinger");
        //simple launch that coresponds to the number passed in
        currentCanon.StopAllCoroutines();
        currentCanon.fireCanon(1.5f);

    }


    public void FullFrontalBarrage()
    {
        CloseAllFingers();
        foreach (GameObject canon in cannons)
        {
            canon.GetComponent<BossCanonController>().fireCanon(2f);

        }
    }

    private void CloseAllFingers()
    {
        foreach (GameObject finger in fingers) 
        {
            finger.GetComponent<Animator>().SetTrigger("CloseFinger");
        }
        foreach (GameObject light in lights)
        {
            light.GetComponent<Animator>().SetBool("IsActive", true);
            StartCoroutine(TurnOutTheLights(light));
        }
    }

    private IEnumerator TurnOutTheLights(GameObject light) 
    {
        yield return new WaitForSeconds(1.55f);
        light.GetComponent<Animator>().SetBool("IsActive", false);
    }
}
