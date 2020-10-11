using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevelScript : MonoBehaviour
{
    private bool eliseIn = false;
    private bool appleseedIn = false;
    public int currentBuildIndex = 1;
    [SerializeField]
    PlayerDataGameObject player;
        
        
        

    // Update is called once per frame
    void Update()
    {
        if (eliseIn == true && appleseedIn == true)
        {
            LoadNextScene();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Girl")
        {
            eliseIn = true;
            bool isMounted = GirlController.Instance.GetMountState();
            if (isMounted)
            {
                appleseedIn = true;
            }
        }

        if (other.gameObject.tag == "Appleseed")//Wont work if appleseedd mounts after she enters
        {
            appleseedIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Girl")
        {
            eliseIn = false;
            bool isMounted = GirlController.Instance.GetMountState();
            if (isMounted)
            {
                appleseedIn = false;
            }
        }

        if (other.gameObject.tag == "Appleseed")
        {
            appleseedIn = false;
        }
    }

    private void LoadNextScene()
    {
        player.SavePlayer(true);
        SceneManager.LoadScene(currentBuildIndex + 1);
    }

    public void StartGame()
    {
        player.OnGameStart();
        player.SavePlayer(false);
        

        SceneManager.LoadScene(1);
    }

    public void LoadFinale()
    {
        SceneManager.LoadScene("Finale");
        
    }
}
