using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrestController : MonoBehaviour
{
    bool isBarActive = false;
    public float BarTime;
    public float BarTimer;// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBarActive == true)
        {
            BarTimer -= Time.deltaTime;
            if (BarTimer < 0)
            {
                isBarActive = false;
                GameOver();
            }
        }
    }

    public void ActivateGameOverTimer()
    {
        isBarActive = true;
        BarTimer = BarTime;
    }

    public void DeacivateGameOverTimer()
    {
        isBarActive = false;
        BarTimer = 0;
    }

    private void GameOver()
    {
        Debug.Log("GameOver");
    }
}
