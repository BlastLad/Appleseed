using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandCanonController : MonoBehaviour
{
    public static LeftHandCanonController instance { get; private set; }


    [SerializeField]
    private GameObject[] cannons;// Start is called before the first frame update
    [SerializeField]
    public GameObject[] fingers;
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void FullFrontalBarrage(int numberToFire)
    {
        Debug.Log("Full Frontal Called");
        BossCanonController currentCanon = cannons[numberToFire].GetComponent<BossCanonController>();
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
    }
}
