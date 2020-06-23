using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    public DialogueBase dialogue;


    public void TriggerDialogue()
    {
        DialogueManager.instance.StartEnQueueDialogue(dialogue);
        DialogueButtonController.instance.gameObject.SetActive(true);
        GirlController.Instance.EnterCutScene();
        AppleseedController.instance.EnterCaptured();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        TriggerDialogue();
        gameObject.SetActive(false);
    }
}
