using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GirlController : MonoBehaviour
{
    private Vector2 inputVector = new Vector2(0, 0); // Start is called before the first frame update
    private Rigidbody2D rb;
    public GameObject thornPrefab;
    public GameObject appleseedPrefab;

    public float walkSpeed;
    public float thornSpeed;

    bool thornCooldown;
    public float cooldownTime;
    public float cooldownTimer;

    private GirlInputActions girlActions;
    public bool isRoseMode = false;
    public bool isCaptured = false;
    public bool isUsingGadget = false;
    public bool isMounted = false;

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
        girlActions.GirlMain.Demount.Disable();

        girlActions.GirlMain.EnterRose.started += ctx => EnterRose();
        
        girlActions.GirlMain.UseGadget.started += ctx => UseGadget();
        girlActions.GirlRose.EnterMain.started += ctx => EnterMain();
        girlActions.GirlRose.Fire.started += ctx => LaunchThorn(inputVector);
        
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
        if (isRoseMode == true)
        {
            Debug.Log("X: " + inputVector.x.ToString() + " Y: " + inputVector.y.ToString());
        }
        else {
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
        isUsingGadget = false;
        isCaptured = false;
        if (girlActions.GirlRose.enabled == true) { girlActions.GirlRose.Disable(); }
        if (girlActions.GirlAppleseedGadget.enabled == true) { girlActions.GirlAppleseedGadget.Disable(); }
        girlActions.GirlMain.Enable();
        
    }
    //A Function that disables Main Mode and enters Rose Mode
    public void EnterRose()
    {
        Debug.Log("Entered Rose Mode");
        inputVector = new Vector2(0f, 0f);//Resets input vector
        isRoseMode = true;
        thornCooldown = true;//Ensures that no thorn is fired upon entry
        cooldownTimer = cooldownTime - 0.3f;
        girlActions.GirlMain.Disable();
        girlActions.GirlRose.Enable();
    }

    //A Function called by Appleseed that enables the Demount Function
    public void Mount()
    {
        Debug.Log("mounted");
        isMounted = true;
        girlActions.GirlMain.Demount.Enable();
        girlActions.GirlMain.Demount.performed += Demount;
    }
    //A function that can only be called while mounted that spawns in a Appleseed GameObject at Girl's current position
    public void Demount(InputAction.CallbackContext context)
    {
        if (isMounted == false) { return; }
        isMounted = false;
        girlActions.GirlMain.Demount.performed -= Demount;
        girlActions.GirlMain.Demount.Disable();
        Instantiate(appleseedPrefab, transform.position, Quaternion.identity);
    }

    public void UseGadget()
    {
        Debug.Log("Gadget Activated");
    }

    //A function that reads the Left Joy Sticks  current direction
    public void OnMovement(InputAction.CallbackContext context)
    {
        /*if (isRoseMode == true) {
            inputVector = new Vector2(0f, 0f);//Resets the Input Vector so Player Object is stationary
            return; 
        }*/
        inputVector = context.ReadValue<Vector2>();
        //Debug.Log("X: " + inputVector.x.ToString() + " Y: " + inputVector.y.ToString());
    }
}
