using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SceneText : MonoBehaviour
{
    [SerializeField]
    private Text sceneText;
    public int currentAct = 0;
    public int currentScene = 0;
    
   
    void Awake()
    {
        currentAct = PauseManager.Instance.currentAct;
        currentScene = PauseManager.Instance.currentScene;
        sceneText.text = "Act: " + currentAct + " Scene: " + currentScene;
    }

   
}
