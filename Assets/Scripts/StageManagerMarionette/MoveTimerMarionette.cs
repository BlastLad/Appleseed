using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTimerMarionette : MonoBehaviour
{
    public static MoveTimerMarionette instance { get; private set; }
    public GameObject headObject;
    LeftArmScreenController leftWall;
    RightArmScreenController rightWall;

    private int MovesUsedInCycle = 0;// Start is called before the first frame update
    private bool isLeft = true;
    [SerializeField]
    GameObject weakOrb;
    public GameObject weakOrbGraphic;
    public GameObject protectedOrbGraphic;
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

    private void Start()
    {
        leftWall = LeftArmScreenController.instance;
        rightWall = RightArmScreenController.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BeginMoveSet()
    {
        MovesUsedInCycle = 0;
        if (leftWall.GetFallState() == true)
        {
            if (rightWall.GetFallState() == true)
            {
                Debug.Log("Congrats You Basically Win");
                weakOrb.GetComponent<CircleCollider2D>().enabled = true;
                weakOrbGraphic.SetActive(true);
                protectedOrbGraphic.SetActive(false);

            }
            else
            {
                StartCoroutine(UseCanonsRightSequel(5f, true));
            }
        }
        else if (rightWall.GetFallState() == true)
        {
            StartCoroutine(UseCanonsLeftSequel(5f, true));
        }
        else
        {
            StartCoroutine(UseCanonsLeft(6f, true));
        }
    }



    private IEnumerator UseCanonsLeft(float time, bool isCounted)
    {
        yield return new WaitForSeconds(time);
        if (isCounted) { MovesUsedInCycle++; }
        StageManagerMarionetteController.instance.DetermineCanonsToFireLeft(3);

        if (MovesUsedInCycle == 1 && isCounted)
        {
            StartCoroutine(UseCanonsRight(4f, true));
        }
        if (MovesUsedInCycle == 3 && isCounted)
        {
            StartCoroutine(UseCanonsRight(4f, false));
            StartCoroutine(UseCanonsLeft(4f, false));
            if (isLeft == true)
            {
                StartCoroutine(FullFrontalLeft(8f, true));
                isLeft = false;
            }
            else
            {
                StartCoroutine(FullFrontalRight(8f, true));
                isLeft = true;
            }
        }

    }

    private IEnumerator UseCanonsLeftSequel(float time, bool isCounted)
    {
        yield return new WaitForSeconds(time);
        if (isCounted) { MovesUsedInCycle++; }
        StageManagerMarionetteController.instance.DetermineCanonsToFireLeft(4);

        if (MovesUsedInCycle == 1 && isCounted)
        {
            StartCoroutine(UseCanonsLeft(4f, false));
            StartCoroutine(UseCanonsLeft(8f, false));
            StartCoroutine(UseCanonsLeftSequel(11f, true));
        }
        else if (MovesUsedInCycle == 2 && isCounted)
        {
            StartCoroutine(UseCanonsLeft(4f, false));
            StartCoroutine(UseCanonsLeftSequel(9f, false));
        }
        else if (isCounted == false)
        {
            StartCoroutine(FullFrontalLeft(8f, false));
            StartCoroutine(FullFrontalLeft(13f, false));
            StartCoroutine(FullFrontalLeft(19f, false));
        }
    }

    private IEnumerator UseCanonsRightSequel(float time, bool isCounted)
    {
        yield return new WaitForSeconds(time);
        if (isCounted) { MovesUsedInCycle++; }
        StageManagerMarionetteController.instance.DetermineCanonsToFireRight(4);

        if (MovesUsedInCycle == 1 && isCounted)
        {
            StartCoroutine(UseCanonsRight(4f, false));
            StartCoroutine(UseCanonsRight(8f, false));
            StartCoroutine(UseCanonsRightSequel(11f, true));
        }
        else if (MovesUsedInCycle == 2 && isCounted)
        {
            StartCoroutine(UseCanonsRight(4f, false));
            StartCoroutine(UseCanonsRightSequel(9f, false));
        }
        else if (isCounted == false)
        {
            StartCoroutine(FullFrontalRight(5f, false));
            StartCoroutine(FullFrontalRight(10f, false));
            StartCoroutine(FullFrontalRight(15f, false));
        }
    }


    private IEnumerator UseCanonsRight(float time, bool isCounted)
    {
        yield return new WaitForSeconds(time);
        if (isCounted) { MovesUsedInCycle++; }
        StageManagerMarionetteController.instance.DetermineCanonsToFireRight(3);

        if (MovesUsedInCycle == 2 && isCounted)
        {
            StartCoroutine(UseCanonsLeft(4f, true));
            //Maybe Also Right
        }
    }

    private IEnumerator FullFrontalLeft(float time, bool isCounted)
    {
        yield return new WaitForSeconds(time);
        if (isCounted) { MovesUsedInCycle++; }
        StageManagerMarionetteController.instance.StartCurtainCallLeft();

        if (MovesUsedInCycle == 4 && isCounted)
        {
            
            StartCoroutine(RollCallStart(3f, true));//RollCall
        }
    }

    private IEnumerator FullFrontalRight(float time, bool isCounted)
    {
        yield return new WaitForSeconds(time);
        if (isCounted) { MovesUsedInCycle++; }
        StageManagerMarionetteController.instance.StartCurtainCallRight();

        if (MovesUsedInCycle == 4 && isCounted)
        {

            StartCoroutine(RollCallStart(3f, true));//RollCall
        }
    }

    private IEnumerator RollCallStart(float time, bool isCounted)
    {
        StartCoroutine(animationForScan(1.4f));
        yield return new WaitForSeconds(time);

        if (isCounted) { MovesUsedInCycle++; }
        StageManagerMarionetteController.instance.StartRollCall();

        if (MovesUsedInCycle == 5 && isCounted)
        {
            MovesUsedInCycle = 0;
            StartCoroutine(UseCanonsLeft(6.5f, true));
        }
    }

    private IEnumerator animationForScan(float time)
    {
        yield return new WaitForSeconds(time);
        headObject.GetComponent<StageManagerHead>().lightThatFireUpInTheNight();
    }

    public void StopAllMoves()
    {
        StopAllCoroutines();
    }
}
