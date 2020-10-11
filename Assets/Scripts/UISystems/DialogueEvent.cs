using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TestDialogue))]
public class DialogueEvent : MonoBehaviour
{
    public int targetLine;

    public UnityEvent unityEvent;


    private TestDialogue testDialogue;

    private bool hasAdded;
    // Start is called before the first frame update
    void Start()
    {
        testDialogue = GetComponent<TestDialogue>();
    }

  


    public void GenericEvent(int line)
    {
        if (line == targetLine)
        {
            unityEvent.Invoke();
            DialogueManager.instance.onDialogueLineCall -= GenericEvent;
           
        }
    }

    public void Interact()
    {
        if (hasAdded == true) { return;  }
        
        DialogueManager.instance.onDialogueLineCall += GenericEvent;
        hasAdded = true;
    }
}
