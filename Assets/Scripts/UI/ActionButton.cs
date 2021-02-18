using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class ActionButton : MonoBehaviour
{

    public Button actionButton;

    public Item weaponEquipped;
    
    [Header("Button Sprites")]
    public Sprite npcTalkSprite;
    public Sprite attackSprite;

    [Header("Events")]
    public static Action onInitiateConversation;
    public static Action onAttack;
    // Start is called before the first frame update
    void Start()
    {
        PlayerActionButtonDetection.onNPCInRange += npcActionSet;
        PlayerActionButtonDetection.onExitRange += attackActionSet;
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void npcActionSet(GameObject closestNPC)
    {
        transform.GetComponent<Image>().sprite = npcTalkSprite;
        actionButton.onClick.AddListener(() => {npcAction(closestNPC);}); 
    }
    void npcAction(GameObject closestNPC)
    {
        Debug.Log(closestNPC);
        closestNPC.GetComponent<NPC>().TriggerDialogue();
        //onInitiateConversation();
    }



    void attackActionSet()
    {
        actionButton.onClick.RemoveAllListeners();
        transform.GetComponent<Image>().sprite = attackSprite;

    }

    public void attack()
    {
        if (transform.GetComponent<Image>().sprite == attackSprite)
        {
            onAttack();
        }
    }
}
