using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueWindow;
    public GameObject decisionWindow;
    public TextMeshProUGUI sentenceText;
    public TextMeshProUGUI nameWindowText;
    //public GameObject continueWindow;
    private Queue<string> sentences;
    private bool queueHasQuestion;
    private int decisionValue = 0;
    public string postQuestionSentence;
    public static Action onEndDialogueEvent;
    

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);
        //Determine if queue is a question
        queueHasQuestion = dialogue.isQuestion;
        postQuestionSentence = dialogue.postQuestionSentence;
        
        //Setting up the dialogue window  
        dialogueWindow.SetActive(true);
        nameWindowText.text = dialogue.name;
        
        //Clearing queue in case it has something (shouldn't)
        sentences.Clear();

        //Adding each sentence in the NPC's dialogue to the Queue
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
        {
            //Dialogue is not over
            if (sentences.Count != 0)
            {
                string sentence = sentences.Dequeue();
                sentenceText.text = sentence;
                return;

            }
            //Dialogue over and is NOT a question
            else if (sentences.Count == 0 && queueHasQuestion == false)
            {
                EndDialogue();
                return;
            }
            //Dialogue over and is a question
            else if (sentences.Count == 0 && queueHasQuestion == true)
            {
                playerDecisionProposal();
                return;

            }

        }

    void playerDecisionProposal()
    {
        decisionValue = 0;


        decisionWindow.SetActive(true);
        StartCoroutine(waitForPlayerDecision());


    }
    IEnumerator waitForPlayerDecision()
        {
            while(decisionValue == 0)
            {
                yield return null;
            }
            //Player Chose Yes
            if (decisionValue == 1)
            {
                Debug.Log("Player chose yes");
                EndDialogueEvent();

                
                
            }

            //Player Chose no
            else if (decisionValue == 2)
            {
                Debug.Log("Player chose no");
                EndDialogue();
            }

        


    }

    void EndDialogue()
    {   dialogueWindow.SetActive(false);
        decisionWindow.SetActive(false);

        Debug.Log("Ending Dialogue");
    }

    void EndDialogueEvent()
    {
        sentenceText.text = postQuestionSentence;
        decisionWindow.SetActive(false);
        //Replace this for when window is touched again it opens the event
        //yield WaitForSeconds(3);
        dialogueWindow.SetActive(false);
        onEndDialogueEvent();

    }


    public void choseYes()
    {
        decisionValue = 1;
    }
    public void choseNo()
    {
        decisionValue = 2;
    }
    
}
