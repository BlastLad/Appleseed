using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWall : MonoBehaviour
{
    [SerializeField]
    GameObject[] flySystems;
    private int sentValue = 0;
    public bool isLeftWall = true;
    public void Update()
    {
        foreach (GameObject holder in flySystems)
        {
            if (holder.GetComponent<RopeBaseController>().isCut == true)
            {
                sentValue++;
                if (sentValue == flySystems.Length)
                {
                    DropWall();
                }
            }
        }
        sentValue = 0;
    }
    public void DropWall()
    {
        if (isLeftWall == true)
        {
            LeftArmScreenController.instance.TheWallsFall();
        }
        else if (isLeftWall == false)
        {
            RightArmScreenController.instance.TheWallsFall();
        }
        Destroy(gameObject);
    }
}
