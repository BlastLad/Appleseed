using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private void Awake()
    {
        if(instance != null) 
        {
            Debug.LogWarning("Fix the dact that there is an instcane" + gameObject.name);
        }
        else
        {
            instance = this;
        }
    }

    public GameObject dialogueBox;
    public Queue<DialogueBase.Info> dialogueInfo;

    public Text dialogueName;
    public Text dialogueText;
    public Image dialoguePortrait;
    public Image dialoguePortraitRight;
    public bool isProtraitLeft;
    public float delay = 0.01f;

    

    private bool isCurrentlyTyping;
    private string completeText;

    public delegate void OnDialogueLineCallBack(int dialogueLine);
    public OnDialogueLineCallBack onDialogueLineCall;
    private int totalLineCount;
    private void Start()
    {
       dialogueInfo = new Queue<DialogueBase.Info>(); //A FIFO collection first in first out
    }
    
    public void StartEnQueueDialogue(DialogueBase db)//Gets the information from dialogue base
    {
        dialogueBox.SetActive(true);
        //Also disable player movement here
        dialogueInfo.Clear();//the queue is cleared when started

        foreach (DialogueBase.Info info in db.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }

        totalLineCount = dialogueInfo.Count;

        EndDeQueueDialogue();
    }

    public void EndDeQueueDialogue()//Dequeues the next one inf the FIFO collection
    {
        if (isCurrentlyTyping == true)
        {
            CompleteText();
            StopAllCoroutines();
            isCurrentlyTyping = false;
            return;
        }


        if (dialogueInfo.Count == 0)
        {
            EndOfDialogue();
            return;
        }
     

        DialogueBase.Info info = dialogueInfo.Dequeue();


        if (onDialogueLineCall != null)
        {
            onDialogueLineCall.Invoke(totalLineCount - dialogueInfo.Count);
        }

        completeText = info.frameText;
        //Sets out stuff equal to whats needed
        dialogueName.text = info.characterName;
        dialogueText.text = info.frameText;  
        isProtraitLeft = info.isLeft;

        if (isProtraitLeft) 
        {
            dialoguePortrait.enabled = true;
            dialoguePortrait.sprite = info.characterPortrait;
            dialoguePortraitRight.enabled = false;
        }
        else 
        {
            dialoguePortraitRight.enabled = true;
            dialoguePortraitRight.sprite = info.characterPortrait;
            dialoguePortrait.enabled = false;
        }

        dialogueText.text = "";
        StartCoroutine(TypeText(info));
    }

    IEnumerator TypeText(DialogueBase.Info info)
    {

        isCurrentlyTyping = true;
       
        foreach(char c in info.frameText.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            dialogueText.text += c;
           // yield return null;
        }
        isCurrentlyTyping = false;
    }

    private void CompleteText()
    {
        dialogueText.text = completeText;
    }

    public void EndOfDialogue()
    {
        dialogueBox.SetActive(false);
        DialogueButtonController.instance.gameObject.SetActive(false);
        AppleseedController.instance.EnterCutScene();
        GirlController.Instance.EnterMain();
        
        
    }



}
