using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDataGameObject : MonoBehaviour
{
    public bool bossDead;
    public bool ticketsCollected;
    public bool noRestarts;
    public bool noDamage;
    public bool underTwenty;


    public int ticketNum = 0;
    private int ticketNumMax;
    private bool isHit = false;
    private bool hasRestarted = false;
    private bool isBossDead;
    public int restartNum;
    public float timeToClear;
    // Start is called before the first frame update
    public void Start()
    {
        LoadPlayer();
    }
    public void BossDefeated(bool val)
    {
        if (bossDead == false)
        {
            bossDead = val;
        }
    }

    private void Update()
    {
        if (underTwenty == true)
        {
            timeToClear -= Time.deltaTime;
            if (timeToClear < 0)
            {
                underTwenty = false;
            }
            else
            {
                underTwenty = true;
            }
        }
    }

    public void ticketCollected()
    {
        ticketNum++;

        if (ticketNum >= 4)
        {
            ticketsCollected = true;
        }
        else
        {
            ticketsCollected = false;
        }
    }

    public void CheckDamage()
    {
        if (isHit == true)
        {
            noDamage = false;
        }
        
    }

    public void CheckRestart()
    {
        if (hasRestarted == true)
        {
            noRestarts = false;
        }
    }

    public void OnGameStart()
    {
        ticketNum = 0;
        restartNum = 0;
        bossDead = false;
        ticketsCollected = false;
        noDamage = true;
        noRestarts = true;
        timeToClear = 840;
        underTwenty = true;
    }

    public void SetDamage(bool val)
    {
        isHit = val;//IF THISBI IS CALLED YOU HAVE TAKEN DAMAGE WILL BE SET EQUAL TO TRUE
    }

    public void SetRestart(bool val)
    {
        hasRestarted = val;//IF THIS IS CALLED THE GAME HAS BEEN RESTARTED IT WILL BE TRUE
    }



    public void SavePlayer(bool shouldCheck)
    {
        if (shouldCheck == true)
        {
            CheckRestart();
            CheckDamage();
        }


        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        

        bossDead = data.bossDead;
        ticketsCollected = data.ticketsCollected;
        noRestarts = data.noRestarts;
        noDamage = data.noDamage;
        ticketNum = data.ticketNum;
        underTwenty = data.underTwenty;
        timeToClear = data.timeToClear;
        //Debug.Log(timeToClear + "Time To Clear");

    }
}
