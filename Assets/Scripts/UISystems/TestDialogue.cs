using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    public DialogueBase dialogue;
    public DialogueEvent[] events;
    public bool hasEvents;

    public void TriggerDialogue()
    {
        DialogueManager.instance.StartEnQueueDialogue(dialogue);
        DialogueButtonController.instance.gameObject.SetActive(true);
        GirlController.Instance.EnterCutScene();
        AppleseedController.instance.EnterCaptured();
        if (hasEvents)
        {    
            foreach(DialogueEvent dialogueEvent in events)
            {
                dialogueEvent.Interact();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Girl" || other.gameObject.tag == "Appleseed") 
        {
            TriggerDialogue();
            gameObject.SetActive(false);
        }
    }
}
