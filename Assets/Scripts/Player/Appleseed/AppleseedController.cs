using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class AppleseedController : MonoBehaviour
{
    private Vector2 inputVector = new Vector2(0, 0); // Start is called before the first frame update
    private Rigidbody2D rb;
    public float walkSpeed;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
   

    public void OnMovement(InputAction.CallbackContext context)
    {        
        inputVector = context.ReadValue<Vector2>();
        Debug.Log("X: " + inputVector.x.ToString() + " Y: " + inputVector.y.ToString());
    }

    private void FixedUpdate()
    {
        //rb.velocity = transform.forward * inputVector * walkSpeed;
        Vector2 position = rb.position;//Current Position of Player
        position = position + inputVector * walkSpeed * Time.fixedDeltaTime;//updated position area
        rb.MovePosition(position);
    }
}
