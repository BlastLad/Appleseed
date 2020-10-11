using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToBossEvent : MonoBehaviour
{
    private GameObject appleseed;// Start is called before the first frame update
    public bool isMoving = false;
    private Vector3 targetPos = new Vector3(0.45f, 2.48f, 0);
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMoving == true)
        {
            appleseed.GetComponent<AppleseedController>().SetAnimation();
            if (Vector2.Distance(appleseed.transform.position, targetPos) < .84f)
            {
                isMoving = false;
                appleseed.GetComponent<Animator>().SetFloat("Vertical", 0f);
                appleseed.GetComponent<Animator>().SetBool("IsMoving", false);
                appleseed.GetComponent<AppleseedController>().SetCutScene(false);
            }
            else
            {
                appleseed.transform.position = Vector2.MoveTowards(appleseed.transform.position, targetPos, AppleseedController.instance.walkSpeed * Time.deltaTime);
            }
        }
    }


    public void BeginEvent()
    {
        appleseed = AppleseedController.instance.gameObject;
        appleseed.GetComponent<AppleseedController>().SetAnimation();
        isMoving = true;
    }
}
