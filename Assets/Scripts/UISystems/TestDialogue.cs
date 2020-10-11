using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    public DialogueBase dialogue;
    public DialogueEvent[] events;
    public bool hasEvents;
    public bool differentActivation = false;

    public void TriggerDialogue()
    {
        DialogueManager.instance.StartEnQueueDialogue(dialogue);
        DialogueButtonController.instance.gameObject.SetActive(true);
        GirlController.Instance.EnterCutScene();
        AppleseedController.instance.EnterCutScene();
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
            if (differentActivation == false)
            {
                StartCoroutine(SafteyMeasure(0.1f));
               
            }
        }
    }

    public void DifferentActivation()
    {
        if (differentActivation)
        {
            TriggerDialogue();
            gameObject.SetActive(false);
        }
    }

    public IEnumerator SafteyMeasure(float time)
    {
        yield return new WaitForSeconds(time);
        TriggerDialogue();
        gameObject.SetActive(false);
    }
}
