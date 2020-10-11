using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ArrestController : MonoBehaviour
{
    [SerializeField]
    GameObject timerBar;
    [SerializeField]
    Image skull;
    bool isBarActive = false;
    public float BarTime;
    public float BarTimer;


    // Update is called once per frame
    void Update()
    {
        if (isBarActive == true)
        {
            BarTimer -= Time.deltaTime;
            timerBar.GetComponent<TimerScript>().SetTimer(BarTimer); 
            if (BarTimer < 3)
            {
                skull.enabled = false;
            }
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
        timerBar.gameObject.SetActive(true);
        timerBar.transform.position = new Vector2(transform.position.x - 1f, transform.position.y);
        timerBar.GetComponent<TimerScript>().SetMax(BarTime);
    }

    public void DeacivateGameOverTimer()
    {
        isBarActive = false;
        BarTimer = 0;
        timerBar.gameObject.SetActive(false);
    }

    private void GameOver()
    {
        PauseManager.Instance.PauseGame();
        PauseManager.Instance.GameOverMenu();
    }
}
