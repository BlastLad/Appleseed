using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class AppleseedController : MonoBehaviour
{
    private Vector2 inputVector = new Vector2(0, 0); // Start is called before the first frame update
    private Rigidbody2D rb;
    public float walkSpeed;
    private AppleseedInputActions appleseedActions;
    public bool isPlayDead = false;
    public Transform hitArea;

    public GameObject girl;
    public GirlController girlController;
    void Awake()
    {
        appleseedActions = new AppleseedInputActions();
        rb = GetComponent<Rigidbody2D>();
        girl = GameObject.Find("PlayerGirlTemp");
        girlController = girl.GetComponent<GirlController>();

        appleseedActions.AppleseedMain.Attack.started += ctx => PunchAttack();
        appleseedActions.AppleseedMain.PlayDead.started += ctx => EnterPlayDead();
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //rb.velocity = transform.forward * inputVector * walkSpeed;
        if (isPlayDead == true) { return; }
        Vector2 position = rb.position;//Current Position of Player
        position = position + inputVector * walkSpeed * Time.fixedDeltaTime;//updated position area
        rb.MovePosition(position);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
        //Debug.Log("X: " + inputVector.x.ToString() + " Y: " + inputVector.y.ToString());
    }

    private void PunchAttack()
    {
        if (isPlayDead == true) { return; }
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

    private void EnterPlayDead()
    {
        isPlayDead = !isPlayDead;
        Debug.Log("Success Appleseed is now Playing Dead");
    }

    private void EnterMount(InputAction.CallbackContext context)
    {
        Debug.Log("Successfully Mounted");
        girlController.Mount();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "MountingBounds")
        {
            appleseedActions.AppleseedMain.Mount.Enable();
            appleseedActions.AppleseedMain.Mount.started += EnterMount;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "MountingBounds")
        {
            appleseedActions.AppleseedMain.Mount.started -= EnterMount;
            appleseedActions.AppleseedMain.Mount.Disable();
        }
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
