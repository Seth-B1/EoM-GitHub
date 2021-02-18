/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public string itemName;
    public int totalStack; 

    public Item itemInSlot; 

    public Sprite itemInventoryIcon;
    public int rarityLevel;
    public bool removeItem;
    public Button slotButton;
    private string itemType;
    private Text stackText;
    public bool slotInitialized = false;
    public QuickslotUI quickslotUI;
    public RectTransform quickslotRectTransform;
    public float x,y;

    void Start()
    {
        quickslotRectTransform = GetComponent<RectTransform>();
        //Event Subscriptions
        quickslotUI.onUpdateQuickslot += matchItemToQuickslot;

        //Shorty 40's
        slotButton = transform.GetComponent<Button>();


    }

    void matchItemToQuickslot()
    {
        //Debug.Log("HERE!");
        //Set Quickslot data to match item in slot
        itemInventoryIcon = itemInSlot.sprite;
        rarityLevel = itemInSlot.rarity;
        itemType = itemInSlot.GetType().ToString();
        itemName = itemInSlot.itemName;
        //Setting Item objects sprite to the slots image
        transform.GetComponent<Image>().sprite = itemInventoryIcon;

    }



    void Update()
    {
        //Refactor all of this with events please god
        
        /*if (itemInSlot != null && slotInitialized == false)
        {
        UpdateSlot();
        slotInitialized = true;
        }*/
        //UpdateSlot();

        /*if (itemInSlot == null || )
        {

        }*/
        /*
        x = transform.GetComponent<RectTransform>().anchoredPosition.x;
        y = transform.GetComponent<RectTransform>().anchoredPosition.y;

    }
    
    void OnClick_Consumable()
    {
        Debug.Log("you ate " + itemInSlot.name);
        // Add effects to player
        
        /*if (totalStack > 0)
        {
            totalStack --;
            stackText.text = totalStack.ToString();
            return;
        }
        else itemInSlot = null; 
    
    }

    

}
*/