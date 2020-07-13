using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTimerMarionette : MonoBehaviour
{
    public static MoveTimerMarionette instance { get; private set; }
    public GameObject headObject;

    private int MovesUsedInCycle = 0;// Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("uh oh Timer");
        }
        else
        {
            
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BeginMoveSet()
    {
        StartCoroutine(UseCanonsLeft(6f));
    }



    private IEnumerator UseCanonsLeft(float time)
    {
        yield return new WaitForSeconds(time);
        MovesUsedInCycle++;
        StageManagerMarionetteController.instance.DetermineCanonsToFireLeft(3);

        if (MovesUsedInCycle == 1)
        {
            StartCoroutine(UseCanonsRight(4f));
        }
        if (MovesUsedInCycle == 3)
        {
            StartCoroutine(FullFrontalLeft(4f));
        }

    }


    private IEnumerator UseCanonsRight(float time)
    {
        yield return new WaitForSeconds(time);
        MovesUsedInCycle++;
        StageManagerMarionetteController.instance.DetermineCanonsToFireRight(3);

        if (MovesUsedInCycle == 2)
        {
            StartCoroutine(UseCanonsLeft(4f));
            //Maybe Also Right
        }
    }

    private IEnumerator FullFrontalLeft(float time)
    {
        yield return new WaitForSeconds(time);
        MovesUsedInCycle++;
        StageManagerMarionetteController.instance.StartCurtainCallLeft();

        if (MovesUsedInCycle == 4)
        {
            StartCoroutine(RollCallStart(3f));//RollCall
        }
    }

    private IEnumerator RollCallStart(float time)
    {
        StartCoroutine(animationForScan(1.4f));
        yield return new WaitForSeconds(time);
        
        MovesUsedInCycle++;
        StageManagerMarionetteController.instance.StartRollCall();
    }

    private IEnumerator animationForScan(float time)
    {
        yield return new WaitForSeconds(time);
        headObject.GetComponent<StageManagerHead>().lightThatFireUpInTheNight();
    }
}
