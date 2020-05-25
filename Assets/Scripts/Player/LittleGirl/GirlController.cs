using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GirlController : MonoBehaviour
{
    private Vector2 inputVector = new Vector2(0, 0); // Start is called before the first frame update
    private Rigidbody2D rb;
    public float walkSpeed;
    private GirlInputActions girlActions;
    public bool isRoseMode = false;
    public bool isCaptured = false;
    public bool isUsingGadget = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        girlActions = new GirlInputActions();
        rb = GetComponent<Rigidbody2D>();
        girlActions.GirlMain.Enable();

        girlActions.GirlMain.EnterRose.started += ctx => EnterRose();
        girlActions.GirlMain.UseGadget.started += ctx => UseGadget();
        girlActions.GirlRose.EnterMain.started += ctx => EnterMain();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //rb.velocity = transform.forward * inputVector * walkSpeed;
        Vector2 position = rb.position;//Current Position of Player
        position = position + inputVector * walkSpeed * Time.fixedDeltaTime;//updated position area
        rb.MovePosition(position);
    }
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
    public void EnterRose()
    {
        Debug.Log("Entered Rose Mode");
        inputVector = new Vector2(0f, 0f);
        isRoseMode = true;
        girlActions.GirlMain.Disable();
        girlActions.GirlRose.Enable();
    }

    public void UseGadget()
    {
        Debug.Log("Gadget Activated");
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        if (isRoseMode == true) {
            inputVector = new Vector2(0f, 0f);//Resets the Input Vector so Player Object is stationary
            return; 
        }
        inputVector = context.ReadValue<Vector2>();
        //Debug.Log("X: " + inputVector.x.ToString() + " Y: " + inputVector.y.ToString());
    }
}
