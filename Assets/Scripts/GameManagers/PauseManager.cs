using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{
    public static PauseManager Instance { get; private set; }
    private bool isPaused = false;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject quitMenu;
    GirlController playerController;
    public int currentAct = 0;
    public int currentScene = 0;
    public int currentBuildIndex = 0;

    [SerializeField]
    PlayerDataGameObject player;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("uh oh PauseManager");
        }
        else
        {

            Instance = this;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        playerController = GirlController.Instance;
    }


    public void PauseGame()
    {
        
        

    
        isPaused = true;
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
      
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    public void QuitGame()
    {
        player.SavePlayer(false);
        SceneManager.LoadScene("Title");
    }

    public void RestartScene()//Need to have a real function once all scenes are in build
    {
        if (player != null)
        {
            player.SetRestart(true);
            player.SavePlayer(true);
        }

        SceneManager.LoadScene(currentBuildIndex);
       
        ResumeGame();
    }

    public void GameOverMenu()
    {
        quitMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }
}
