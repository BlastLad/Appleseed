using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public bool bossDead;
    public bool ticketsCollected;
    public bool noRestarts;
    public bool noDamage;
    public bool underTwenty;
    public int ticketNumMax;
    public int ticketNum = 0;
    public float timeToClear = 1;

    private bool isHit;
    private bool hasRestarted;
    private bool isBossDead;
    public PlayerData(PlayerDataGameObject player)
    {
        bossDead = player.bossDead;
        ticketsCollected = player.ticketsCollected;
        noDamage = player.noDamage;
        noRestarts = player.noRestarts;
        ticketNum = player.ticketNum;
        underTwenty = player.underTwenty;
        timeToClear = player.timeToClear;

    }


    public void BossDefeated(bool val)
    {
        bossDead = val;
    }

    public void ticketCollected()
    {
        ticketNum++;
        if (ticketNum > ticketNumMax)
        {
            ticketNumMax = ticketNum;
        }

        if (ticketNumMax >= 4)
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
        if (isHit == false)
        {
            noDamage = true;
        }
        else if (noDamage == false)
        {
            noDamage = false;
        }
    }

    public void CheckRestart()
    {
        if (hasRestarted == false)
        {
            noRestarts = true;
        }
        else if (noRestarts == false)
        {
            noRestarts = false;
        }
    }

    public void OnGameStart()
    {
        ticketNum = 0;
        isHit = false;
        hasRestarted = false;
    }

    public void SetDamage(bool val)
    {
        isHit = val;
    }

    public void SetRestart(bool val)
    {
        hasRestarted = val;
    }

}
