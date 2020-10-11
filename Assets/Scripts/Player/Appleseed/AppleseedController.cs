using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class AppleseedController : MonoBehaviour
{
    public static AppleseedController instance { get; private set; }
    private Vector2 inputVector = new Vector2(0, 0); 
    private Rigidbody2D rb;
    public float walkSpeed;
    private AppleseedInputActions appleseedActions;
    public bool isPlayDead = false;
    public Transform hitArea;

    private bool isInCutScene = false;
    private bool isTimerCalled = false;
    private bool isBehind = true;
    private bool isCaptured = false;
    private bool isAttacking = false;
    public GameObject girl;
    public GirlController girlController;
    private Animator appleAnim;
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
        appleAnim = GetComponent<Animator>();

        appleseedActions.AppleseedMain.Attack.started += ctx => PunchAttack();
        appleseedActions.AppleseedMain.PlayDead.started += ctx => EnterPlayDead();
        
    }

    private void Update()
    {
        if (isBehind == false && isTimerCalled == false)
        {
            StartCoroutine(ResetBehind(2f));
        }
        if (isAttacking == false && isInCutScene == false)
        {
            appleAnim.SetFloat("Horizontal", inputVector.x);
            appleAnim.SetFloat("Vertical", inputVector.y);
        }

        if (inputVector != new Vector2(0, 0) && isPlayDead == false && isCaptured == false)
        {
            appleAnim.SetBool("IsMoving", true);

        }
        else
        {
            if (isInCutScene == false)
            {
                appleAnim.SetBool("IsMoving", false);
                if (isAttacking == false)
                {
                    appleAnim.SetFloat("Vertical", -1);
                }
            }
            
        }

    }
    // Update is called once per frame
    private void FixedUpdate()
    {
       
        if (isPlayDead == true || isCaptured == true) { appleAnim.SetBool("IsMoving", false); return; }
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
        appleAnim.SetBool("IsMoving", true);
        inputVector = context.ReadValue<Vector2>();
       
    }

    private void PunchAttack()
    {
        if (isPlayDead == true || isCaptured == true) { return; }
        
        isAttacking = false;
        appleAnim.SetTrigger("Attack");
        isAttacking = true;
        if (inputVector == new Vector2(0, 0))
        {
            isAttacking = true;
            hitArea.position = rb.position;
            hitArea.gameObject.SetActive(true);
            hitArea.position = rb.position + new Vector2(0, -1);
            StartCoroutine(DeactivateHitArea(0.4f));
        }
        else
        {
            isAttacking = true;
            hitArea.gameObject.SetActive(true);
            hitArea.position = rb.position + inputVector.normalized;
            StartCoroutine(DeactivateHitArea(0.4f));
        }
    }

    private IEnumerator DeactivateHitArea(float timeToWait)
    {
        StopCoroutine(DoneAttacking());
        yield return new WaitForSeconds(timeToWait);
        hitArea.gameObject.SetActive(false);
        StartCoroutine(DoneAttacking());
    }

    private IEnumerator DoneAttacking()
    {
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;
    }
    public void EnterCaptured()
    {
        isCaptured = !isCaptured;
        isPlayDead = false;
        appleAnim.SetBool("IsPlayDead", false);
        appleAnim.SetBool("IsCaptured", isCaptured);
        if (isCaptured)
        {
            appleAnim.SetTrigger("Captured");
        }
        rb.velocity = new Vector2(0,0);

    }

    public void EnterCutScene()
    {
        isCaptured = !isCaptured;
        appleAnim.SetBool("IsPlayDead", false);
        isPlayDead = false;
        rb.velocity = new Vector2(0, 0);
    }

    private void EnterPlayDead()
    {
        isPlayDead = !isPlayDead;
        rb.velocity = Vector3.zero;
        appleAnim.SetBool("IsPlayDead", isPlayDead);
        if (isPlayDead == true)
        {
            appleAnim.SetTrigger("PlayDead");
        }
       
    }

    private void EnterMount(InputAction.CallbackContext context)
    {      
        if (isCaptured == false)
        {
           
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
       
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "MountingBounds")
        {
            appleseedActions.AppleseedMain.Mount.started -= EnterMount;
            appleseedActions.AppleseedMain.Mount.Disable();
        }
        
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

    public void SetAnimation()
    {
        appleAnim.SetBool("IsMoving", true);
        appleAnim.SetFloat("Vertical", 1f);
        isInCutScene = true;
            
    }
    
    public void SetCutScene(bool val)
    {
        isInCutScene = val;
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
