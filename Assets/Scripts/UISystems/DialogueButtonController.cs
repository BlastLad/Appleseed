using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class DialogueButtonController : MonoBehaviour
{

    public static DialogueButtonController instance;

    public DialogueControls actions; // Start is called before the first frame update
   
 
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Fix the dact that there is an instcane" + gameObject.name);
        }
        else
        {
            instance = this;
        }
        actions = new DialogueControls();

        actions.Dialogue.Enable();
        actions.Dialogue.Next.started += ctx => GetNextLine();
        gameObject.SetActive(false);
    }

    public void GetNextLine()
    {
        Debug.Log("Called");
        DialogueManager.instance.EndDeQueueDialogue();
    }

    public void StartActionMap()
    {
        actions.Dialogue.Enable();
    }
    

    private void OnEnable()
    {
        actions.Dialogue.Enable();
    }

    private void OnDisable()
    {
        actions.Dialogue.Disable();
    }
}
