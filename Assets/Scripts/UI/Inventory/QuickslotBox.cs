using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuickslotBox : MonoBehaviour
{
    public Item itemInQuickslot;
    public int stackSize = 0;
    public Sprite slotSprite;
    public Image image;
    public static Action<Item> onQuickslotUsed;

    //Private

    //private Image quickslotSprite;


    void Start()
    {
        //Subscriptions
        //InventoryUI.onUpdateSlotUI += UpdateQuickslotUI;
        

        //Shortcuts
        
    }

    public void UpdateQuickslotUI(Item itemFound)
    {
        transform.GetComponent<Image>().sprite = itemInQuickslot.sprite;
    }


    public void useItemInQuickslot()
    {
        //Sends the item to the player statistics to calculate effects
        if(itemInQuickslot.itemType == "Consumable")
        {       
        onQuickslotUsed(itemInQuickslot);
        }
        else if(itemInQuickslot.itemType == null)
        {
            return;
        }

        //Updates Quickslot to show the item was used
        if (stackSize != 1)
        {
            stackSize--;
        }
        else
        {
            ClearItemInSlot();
        } 
    }

    public void ClearItemInSlot()
    {
        stackSize--;
        itemInQuickslot = null;
        transform.GetComponent<Image>().sprite = null;
    }
}
