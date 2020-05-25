using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GirlController : MonoBehaviour
{
    private Vector2 inputVector = new Vector2(0, 0); // Start is called before the first frame update
    private Rigidbody2D rb;
    public float walkSpeed;
    private GirlInputActions girlInputActions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        girlInputActions = new GirlInputActions();
        rb = GetComponent<Rigidbody2D>();
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

    public void OnMovement(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
        Debug.Log("X: " + inputVector.x.ToString() + " Y: " + inputVector.y.ToString());
    }
}
