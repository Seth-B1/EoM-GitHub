using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ItemPickedUpText : MonoBehaviour
{
    public int counter = 0;
    public Item item;
    public TMP_Text counterText;
    public TMP_Text itemPickupText;
    public Animator animator;
    //public Transform player;

    void Start()
    {
        //Subscriptions 
        ItemPickupTextList.onUpdatePickupWindow += UpdateWindow;

        itemPickupText.text = item.itemName;
        counter++;
        counterText.text = " ";
        

    }

    void NewItemWindow(Item itemFound)
    {
        //Debug.Log("HEREE");
    }

    void UpdateWindow(Item itemFound)
    {


    }
}
