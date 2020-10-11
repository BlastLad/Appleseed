using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnAnimationController : MonoBehaviour
{
    Animator pawnAnim;
    float rotation = 0;
    bool isMovement = false;
    bool isHunting = false;

    void Awake()
    {
        pawnAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rotation = GetComponentInParent<EnemyController>().gameObject.transform.rotation.eulerAngles.z;

        if (isHunting == false)
        {
            isMovement = GetComponentInParent<PawnMovementController>().movementType;
        }
        isHunting = GetComponentInParent<EnemyController>().gameObject.GetComponentInChildren<SightConeMaterialController>().GetIsRed();
        
        pawnAnim.SetBool("IsMovement", isMovement);
        pawnAnim.SetBool("IsHunting", isHunting);

        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (isHunting == true)
        {
            HuntingAnim();
            return;
        }
        else if (isMovement == true) { MovementAnim();  }
        else { StationaryAnim(); }
       
    }
    void HuntingAnim()
    {
        

        if (rotation > 25 && rotation < 115)
        {
            pawnAnim.SetFloat("Horizontal", 0);
            pawnAnim.SetFloat("Vertical", 1);
        }
        else if (rotation > 115 && rotation < 205)
        {
            pawnAnim.SetFloat("Horizontal", -1);
            pawnAnim.SetFloat("Vertical", 0);
        }
        else if (rotation > 205 && rotation < 295)
        {
            pawnAnim.SetFloat("Horizontal", 0);
            pawnAnim.SetFloat("Vertical", -1);
        }
        else
        {
            pawnAnim.SetFloat("Horizontal", 1);
            pawnAnim.SetFloat("Vertical", 0);
        }
    }

    void MovementAnim()
    {
        if (rotation > 25 && rotation < 115)
        {
            pawnAnim.SetFloat("Horizontal", 0);
            pawnAnim.SetFloat("Vertical", 1);
        }
        else if (rotation > 115 && rotation < 205)
        {
            pawnAnim.SetFloat("Horizontal", -1);
            pawnAnim.SetFloat("Vertical", 0);
        }
        else if (rotation > 205 && rotation < 295)
        {
            pawnAnim.SetFloat("Horizontal", 0);
            pawnAnim.SetFloat("Vertical", -1);
        }
        else
        {
            pawnAnim.SetFloat("Horizontal", 1);
            pawnAnim.SetFloat("Vertical", 0);
        }
    }

    void StationaryAnim()
    {
        if (rotation > 45 && rotation < 135)
        {
            pawnAnim.SetFloat("Horizontal", 0);
            pawnAnim.SetFloat("Vertical", 1);
        }
        else if (rotation > 135 && rotation < 225)
        {
            pawnAnim.SetFloat("Horizontal", -1);
            pawnAnim.SetFloat("Vertical", 0);
        }
        else if (rotation > 225 && rotation < 315)
        {
            pawnAnim.SetFloat("Horizontal", 0);
            pawnAnim.SetFloat("Vertical", -1);
        }
        else
        {
            pawnAnim.SetFloat("Horizontal", 1);
            pawnAnim.SetFloat("Vertical", 0);
        }
    }

    public void ArrestTrigger()
    {
        pawnAnim.SetTrigger("Arrested");
        SetArrest(true);
    }

    public void SetArrest(bool boolVal)
    {
        pawnAnim.SetBool("IsArresting", boolVal);
    }
}
