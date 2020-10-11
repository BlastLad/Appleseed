using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnableStar : MonoBehaviour
{
    public int StarNum;// Start is called before the first frame update
    [SerializeField]
    PlayerDataGameObject player;
    void Update()
    {
        isStarEnabled();
    }



    public void isStarEnabled()
    {
        
        if (StarNum == 1)
        {
            if(player.bossDead == true)
            {
                gameObject.GetComponent<Image>().enabled = true;
            }
        }
        else if (StarNum == 2)
        {
            if (player.ticketsCollected == true)
            {
                gameObject.GetComponent<Image>().enabled = true;
            }
        }
        else if (StarNum == 3)
        {
            if (player.noRestarts == true)
            {
                gameObject.GetComponent<Image>().enabled = true;
            }
        }
        else if (StarNum == 4)
        {
            if (player.noDamage == true)
            {
                gameObject.GetComponent<Image>().enabled = true;
            }
        }
        else if (StarNum == 5)
        {
            if(player.underTwenty == true)
            {
                gameObject.GetComponent<Image>().enabled = true;
            }
        }

        
    }
}
