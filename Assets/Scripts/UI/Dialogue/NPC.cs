using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class NPC : MonoBehaviour
{

public Dialogue dialogue;
public UnityEvent playerDecisionResults;

    void Start()
    {
        //ActionButton.onInitiateConversation += this.TriggerDialogue;
        //DialogueManager.onEndDialogueEvent += executeEndDialogueEvent;
    }


public void TriggerDialogue()
{
    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    if (dialogue.isQuestion)
    {
        DialogueManager.onEndDialogueEvent += executeEndDialogueEvent;   
    }
}

public void executeEndDialogueEvent()
{
    playerDecisionResults.Invoke();
    DialogueManager.onEndDialogueEvent -= executeEndDialogueEvent;
}


}

