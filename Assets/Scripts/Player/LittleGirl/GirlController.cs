using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GirlController : MonoBehaviour
{


    public static GirlController Instance { get; private set; }
    private Vector2 inputVector = new Vector2(0, 0); // Start is called before the first frame update
    private Rigidbody2D rb;
    public GameObject thornPrefab;
    public GameObject appleseedPrefab;
    public GameObject landingZonePrefab;
    public GameObject mountingBounds;
    public GameObject appleseedThrownSprite;
    public Transform roseTarget;
    public Transform throwTarget;
    private float throwTargetDistance = 2.3f;
    private float throwTargetMax = 6.0f;
    private float throwTargetMin = 1.5f;

    public float walkSpeed;
    public float thornSpeed;

    bool thornCooldown;
    public float cooldownTime;
    public float cooldownTimer;

    private GirlInputActions girlActions;
    private int currentState = 0; 
    private bool isMain = true;
    private bool isRoseMode = false;
    private bool isCaptured = false;
    private bool isUsingGadget = false;
    private bool isMounted = false;
    private bool isThrowing = false;
    private bool isThrowable = true;
    private bool isPaused = false;//Once again should put in GameManager


    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Awake occurs before start
    private void Awake()
    {
        girlActions = new GirlInputActions();
        rb = GetComponent<Rigidbody2D>();
        girlActions.GirlMain.Enable();
        girlActions.GirlMain.EnterRose.started += ctx => EnterRose();      
        girlActions.GirlMain.UseGadget.started += ctx => UseGadget();
        girlActions.GirlRose.EnterMain.started += ctx => EnterMain();
        girlActions.GirlRose.Fire.started += ctx => LaunchThorn(inputVector);
        girlActions.GirlAppleseedGadget.EnterMain.started += ctx => EnterMain();
        girlActions.GirlAppleseedGadget.Throw.started += ctx => ThrowAppleseed(inputVector);
        girlActions.GirlAppleseedGadget.ChangeThrowRange.started += ctx => MoveTarget();
        girlActions.GirlMain.Pause.started += ctx => PauseGame();//Temp Pause game should be in a GameManager Script
        girlActions.GirlAppleseedGadget.Pause.started += ctx => PauseGame();
        girlActions.GirlCaptured.Pause.started += ctx => PauseGame();
        girlActions.GirlRose.Pause.started += ctx => PauseGame();
        girlActions.GirlPaused.ResumeGame.started += ctx => PauseGame();

    }

    // Update is called once per frame
    void Update()
    {
        //To ensure that thorns are not spammed
        if (thornCooldown == true)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer < 0)
                thornCooldown = false;
        }

        
    }

    private void FixedUpdate()
    {
        //rb.velocity = transform.forward * inputVector * walkSpeed;
        if (isUsingGadget == true)//Needs to be improved
        {
            if (inputVector == new Vector2(0, 0))
            {
                MoveTarget();
                throwTarget.position = rb.position + (new Vector2(0, 1) * throwTargetDistance);
                CalculateRay(inputVector.normalized);
            }
            else
            {
                MoveTarget();
                throwTarget.position = rb.position + inputVector.normalized * throwTargetDistance;
                CalculateRay(inputVector.normalized);
            }//Debug.Log("X: " + inputVector.x.ToString() + " Y: " + inputVector.y.ToString());
        }
        else if (isMain == true) {
            Vector2 position = rb.position;//Current Position of Player
            position = position + inputVector * walkSpeed * Time.fixedDeltaTime;//updated position area
            rb.MovePosition(position);
        }
    }

    //A Function to instaniate a Thorn prefab in the castdirection as determined by the inputVector
    void LaunchThorn(Vector2 castDirection)
    {
        castDirection.Normalize();

        if (thornCooldown == true) { return; }      
            if (castDirection.x == 0 && castDirection.y == 0) { castDirection.y = 1.0f; }
            GameObject thorn = Instantiate(thornPrefab, transform.position, Quaternion.identity);
            thorn.GetComponent<Rigidbody2D>().velocity = castDirection * thornSpeed;
            Destroy(thorn, 5f);
            thornCooldown = true;
            cooldownTimer = cooldownTime;
        
    }
    //A funtion that enables the MainMode Input Action Maps and Disables all others
    public void EnterMain()
    {
        Debug.Log("Entered Main Mode");
        isRoseMode = false;
        isCaptured = false;
        isMain = true;
        currentState = 0;
        roseTarget.gameObject.SetActive(false);
        throwTarget.gameObject.SetActive(false);
        if (girlActions.GirlRose.enabled == true) { girlActions.GirlRose.Disable(); }
        if (girlActions.GirlAppleseedGadget.enabled == true) { 
            girlActions.GirlAppleseedGadget.Disable();
            isUsingGadget = false;
            if (isThrowing == false)
            {
                girlActions.GirlMounted.Enable();
            }
            isThrowing = false;
            //girlActions.GirlMounted.Demount.performed += Demount;
        }
        girlActions.GirlMain.Enable();
        
    }
    //A Function that disables Main Mode and enters Rose Mode
    public void EnterRose()
    {
        Debug.Log("Entered Rose Mode");
        inputVector = new Vector2(0f, 0f);//Resets input vector
        isMain = false;
        isRoseMode = true;
        currentState = 1;
        thornCooldown = true;//Ensures that no thorn is fired upon entry
        roseTarget.gameObject.SetActive(true);
        roseTarget.position = rb.position + new Vector2(0, 1);
        cooldownTimer = cooldownTime - 0.3f;
        girlActions.GirlMain.Disable();
        girlActions.GirlRose.Enable();
        /*if (isMounted)
        {
            girlActions.GirlMain.Demount.Enable();
        }*/
    }

    //A Function called by Appleseed that enables the Demount Function
    public void Mount()
    {
        Debug.Log("mounted");
        isMounted = true;
        girlActions.GirlMounted.Enable();
        girlActions.GirlMounted.Demount.performed += Demount;
        //Add appleseed gadget to UI
    }
    //A function that can only be called while mounted that spawns in a Appleseed GameObject at Girl's current position
    public void Demount(InputAction.CallbackContext context)
    {
        if (isMounted == false || isUsingGadget == true) { return; }
        isMounted = false;
        girlActions.GirlMounted.Demount.performed -= Demount;
        girlActions.GirlMounted.Demount.Disable();
        Instantiate(appleseedPrefab, transform.position, Quaternion.identity);
    }
    private void Demount()
    {
        if (isMounted == false || isUsingGadget == true) { return; }
        isMounted = false;
        girlActions.GirlMounted.Demount.performed -= Demount;
        girlActions.GirlMounted.Demount.Disable();
        Instantiate(appleseedPrefab, transform.position, Quaternion.identity);
    }

    public void UseGadget()
    {
        if (isMounted)//Also that current selected gadget is Appleseed
        {
            Debug.Log("Gadget Activated");
            inputVector = new Vector2(0f, 0f);
            isUsingGadget = true;
            currentState = 2;
            isMain = false;
            throwTarget.gameObject.SetActive(true);
            throwTargetDistance = 2.3f;
            throwTarget.position = rb.position + (new Vector2(0, 1) * throwTargetDistance);
            CalculateRay(new Vector2(0, 1));
            girlActions.GirlMain.Disable();
            girlActions.GirlMounted.Disable();//To ensure that the button press is not accidently eaten while Using AppleseedGadget
            girlActions.GirlAppleseedGadget.Enable();
        }
    }

    public void ThrowAppleseed(Vector2 castDirection)
    {
        if (isThrowable == false) { return; }
        else
        {
            castDirection.Normalize();
            //GameObject appleseedThrow = Instantiate(appleseedPrefab, throwTarget.position, Quaternion.identity);
            if (castDirection.x == 0 && castDirection.y == 0) { castDirection.y = 1.0f; }
            GameObject throwSprite = Instantiate(appleseedThrownSprite, transform.position, Quaternion.identity);
            Instantiate(landingZonePrefab, throwTarget.position, Quaternion.identity);
            throwSprite.GetComponent<Rigidbody2D>().velocity = castDirection * thornSpeed;
            isThrowing = true;
            isMounted = false;
            EnterMain();
        }
    }

    //A function that reads the Left Joy Sticks  current direction
    public void OnMovement(InputAction.CallbackContext context)
    {
        /*if (isRoseMode == true) {
            inputVector = new Vector2(0f, 0f);//Resets the Input Vector so Player Object is stationary
            return; 
        }*/      
        inputVector = context.ReadValue<Vector2>();
        if (isRoseMode == true)
        {
            if (inputVector == new Vector2(0, 0))
            {
                roseTarget.position = rb.position + new Vector2(0, 1);
            }
            else
            {
                roseTarget.position = rb.position + inputVector.normalized;
            }
        }
        else if (isUsingGadget == true)
        {
            if (inputVector == new Vector2(0,0))
            {
                
                throwTarget.position = rb.position + (new Vector2(0, 1) * throwTargetDistance);
                CalculateRay(inputVector.normalized);
            }
            else
            {
                throwTarget.position = rb.position + inputVector.normalized * throwTargetDistance;
                CalculateRay(inputVector.normalized);
            }
        }
        //Debug.Log("X: " + inputVector.x.ToString() + " Y: " + inputVector.y.ToString());
    }

    public void CalculateRay(Vector2 castDirection)
    {
        int layerMask = LayerMask.GetMask("Walls", "ThrowMarker", "Objects");
        float a = ((throwTarget.position.x - transform.position.x) * (throwTarget.position.x - transform.position.x));
        float b = ((throwTarget.position.y - transform.position.y) * (throwTarget.position.y - transform.position.y));
        float distance = Mathf.Sqrt(a + b);
        //Debug.Log(distance);
        if (castDirection.x == 0 && castDirection.y == 0) { castDirection.y = 1; }         
        RaycastHit2D hit = Physics2D.Raycast(transform.position, castDirection, distance, layerMask);
        //if (hit) { Debug.Log(hit.collider.name); }
        if (hit)
        {
            if (hit.collider.gameObject.tag == "ThrowMarker")
            {
                isThrowable = true;
            }
            else
            {
                isThrowable = false;
            }
        }
    }

    private void MoveTarget()
    {
        Debug.Log("Successfully Called");

        Vector2 targetMovementInput = girlActions.GirlAppleseedGadget.ChangeThrowRange.ReadValue<Vector2>();

        Vector2 movement = new Vector2(targetMovementInput.x, targetMovementInput.y);
        
        movement.Normalize();
        Debug.Log(movement.y);
        if (movement.y < -0.1) { throwTargetDistance = throwTargetDistance - 0.04f; }
        if (movement.y > 0.1) { throwTargetDistance = throwTargetDistance + 0.04f; }

        if (throwTargetDistance > throwTargetMax) { throwTargetDistance = throwTargetMax; }
        else if (throwTargetDistance < throwTargetMin) { throwTargetDistance = throwTargetMin; }
    }
    public void EnterCaptured()
    {
        Debug.Log("Entered Capture Mode");
        isCaptured = true;
        EnterMain();
        isMain = false;
        if (isMounted == true) { Demount(); }
        girlActions.GirlMain.Disable();
        girlActions.GirlMain.Pause.Enable();
    }
    private void PauseGame()
    {
        int pauseState = GetState();
        if (isPaused == false)
        {
            
            Debug.Log("Game Paused");
            isPaused = true;
            Time.timeScale = 0.0f;         
            if(pauseState == 0)//0 is main
            {
                girlActions.GirlMain.Disable();
                girlActions.GirlMounted.Disable();
                mountingBounds.gameObject.SetActive(false);
                
            }
            else if(pauseState == 1)//is Rose
            {
                girlActions.GirlRose.Disable();
                girlActions.GirlMounted.Disable();
                roseTarget.gameObject.SetActive(false);
                mountingBounds.gameObject.SetActive(false);
            }
            else if (pauseState == 2)//0 is AppleseedGadget
            {
                girlActions.GirlAppleseedGadget.Disable();
                throwTarget.gameObject.SetActive(false);
            }
            girlActions.GirlPaused.Enable();
        }
        else
        {
            Debug.Log("Game Resumed");
            isPaused = false;       
            Time.timeScale = 1.0f;
            if (pauseState == 0)//0 is main
            {
                girlActions.GirlMain.Enable();
                girlActions.GirlMounted.Enable();
                mountingBounds.gameObject.SetActive(true);
            }
            else if (pauseState == 1)//0 is Rose
            {
                girlActions.GirlRose.Enable();
                girlActions.GirlMounted.Enable();
                roseTarget.gameObject.SetActive(true);
                mountingBounds.gameObject.SetActive(true);
            }
            else if (pauseState == 2)//0 is AppleseedGadget
            {
                girlActions.GirlAppleseedGadget.Enable();
                throwTarget.gameObject.SetActive(true);
            }
            girlActions.GirlPaused.Disable();
        }
    }

    public void SetThrowable(bool b)
    {
        isThrowable = b;
    } 

    public int GetState()
    {
        return currentState;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
