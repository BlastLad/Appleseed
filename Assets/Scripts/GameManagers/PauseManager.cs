using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] GameObject girlPlayer;
    GirlController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = girlPlayer.GetComponent<GirlController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        
        Debug.Log("Game Paused");

        int currentState = playerController.GetState();
        isPaused = true;
        Time.timeScale = 0.0f;

        if (currentState == 0)
        {
            //GirlInputActions girlActions = playerController.girlActions;
            //girlActions.GirlMain.Disable();
            //girlActions.GirlPaused.Enable();
        }
    }
}
