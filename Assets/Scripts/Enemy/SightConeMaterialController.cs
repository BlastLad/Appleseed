using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightConeMaterialController : MonoBehaviour
{
    public Material yellowCone;
    public Material redCone;// Start is called before the first frame update
    private bool isRed = false;
    void Start()
    {
        GetComponent<MeshRenderer>().material = yellowCone;
    }

    // Update is called once per frame
    public void SetYellow()
    {
        GetComponent<MeshRenderer>().material = yellowCone;
        isRed = false;
    }

    public void SetRed()
    {
        GetComponent<MeshRenderer>().material = redCone;
        isRed = true;
    }

    public bool GetIsRed()
    {
        return isRed;
    }
}
