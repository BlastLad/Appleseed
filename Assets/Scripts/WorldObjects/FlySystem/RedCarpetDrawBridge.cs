﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCarpetDrawBridge : MonoBehaviour
{
    [SerializeField]
    GameObject[] flySystems;
    private int sentValue = 0;

    public void Update()
    {
        foreach(GameObject holder in flySystems)
        {
            if (holder.GetComponent<RopeBaseController>().isCut == true)
            {
                sentValue++;
                if (sentValue == flySystems.Length)
                {
                    DropCarpet();
                }
            }
        }
        sentValue = 0;
    }
    public void DropCarpet()
    {
        gameObject.SetActive(false);
    }
}
