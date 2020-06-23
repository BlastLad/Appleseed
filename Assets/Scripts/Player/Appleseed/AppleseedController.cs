using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class AppleseedController : MonoBehaviour
{
    public static AppleseedController instance { get; private set; }
    private Vector2 inputVector = new Vector2(0, 0); // Start is called before the first frame update
    private Rigidbody2D rb;
    public float walkSpeed;
    private AppleseedInputActions appleseedActions;
    public bool isPlayDead = false;
    public Transform hitArea;


    private bool isTimerCalled = false;
    private bool isBehind = true;
    private bool isCaptured = false;
    public GameObject girl;
    public GirlController girlController;
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Fix the dact that there is an instcane" + gameObject.name);
        }
        else
        {
            instance = this;
        }

        appleseedActions = new AppleseedInputActions();
        rb = GetComponent<Rigidbody2D>();
        girl = GameObject.Find("PlayerGirlTemp");
        girlController = girl.GetComponent<GirlController>();

        appleseedActions.AppleseedMain.Attack.started += ctx => PunchAttack();
        appleseedActions.AppleseedMain.PlayDead.started += ctx => EnterPlayDead();
        
    }

    private void Update()
    {
        if (isBehind == false && isTimerCalled == false)
        {
            StartCoroutine(ResetBehind(2f));
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        //rb.velocity = transform.forward * inputVector * walkSpeed;
        if (isPlayDead == true || isCaptured == true) { return; }
        Vector2 position = rb.position;//Current Position of Player
        position = position + inputVector * walkSpeed * Time.fixedDeltaTime;//updated position area
        rb.MovePosition(position);
        if (isBehind == false && isTimerCalled == false)
        {
            StartCoroutine(ResetBehind(2f));
        }

    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
        //Debug.Log("X: " + inputVector.x.ToString() + " Y: " + inputVector.y.ToString());
    }

    private void PunchAttack()
    {
        if (isPlayDead == true || isCaptured == true) { return; }
        //Debug.Log("X: " + inputVector.x.ToString() + " Y: " + inputVector.y.ToString());
        if (inputVector == new Vector2(0, 0))
        {
            hitArea.position = rb.position;
            hitArea.gameObject.SetActive(true);
            hitArea.position = rb.position + new Vector2(0, -1);
            StartCoroutine(DeactivateHitArea(0.4f));
        }
        else
        {
            hitArea.gameObject.SetActive(true);
            hitArea.position = rb.position + inputVector.normalized;
            StartCoroutine(DeactivateHitArea(0.4f));
        }
    }

    private IEnumerator DeactivateHitArea(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        hitArea.gameObject.SetActive(false);
    }

    public void EnterCaptured()
    {
        isCaptured = !isCaptured;
    }

    private void EnterPlayDead()
    {
        isPlayDead = !isPlayDead;
        Debug.Log("Success Appleseed is now Playing Dead");
    }

    private void EnterMount(InputAction.CallbackContext context)
    {      
        if (isCaptured == false)
        {
            Debug.Log("Successfully Mounted");
            girlController.Mount();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "MountingBounds")
        {
            appleseedActions.AppleseedMain.Mount.Enable();
            appleseedActions.AppleseedMain.Mount.started += EnterMount;
        }
        /*if (other.gameObject.tag == "BlindSpot")//may need to change
        {
            Debug.Log("Behind");
            isBehind = true;
        }*/
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "MountingBounds")
        {
            appleseedActions.AppleseedMain.Mount.started -= EnterMount;
            appleseedActions.AppleseedMain.Mount.Disable();
        }
        /*if (other.gameObject.tag == "BlindSpot")// may need to change
        {
            isBehind = false;
        }*/
    }

    private IEnumerator ResetBehind(float time)
    {
        isTimerCalled = true;
        yield return new WaitForSeconds(time);
        isTimerCalled = false;
        isBehind = true;
       
    } 

    public bool GetPlayDeadState()
    {
        return isPlayDead;
    }

    public void SetBehindState(bool behind)
    {
        isBehind = behind;
    }

    public bool GetBehindState()
    {
        return isBehind;
    }

    private void OnEnable()
    {
        appleseedActions.AppleseedMain.Enable();
    }

    private void OnDisable()
    {
        appleseedActions.AppleseedMain.Disable();
    }

    
}
