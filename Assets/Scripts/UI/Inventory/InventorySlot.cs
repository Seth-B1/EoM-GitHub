using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public string itemName;
  
    public int stackSize; 

    public Item itemInInventorySlot; 

    public Sprite itemInventoryIcon;
    public int rarityLevel;
    public bool removeItem;

    public string itemType;
    //private Text stackText;
    public Button slotButton;

    //Private
    private Image inventorySlotImage;


    void Start()
    {
        //Subscriptions
        //InventoryUI.onUpdateSlotUI += UpdateInventoryslotUI;

        //Shortcuts
        inventorySlotImage = transform.GetComponent<Image>();
    }

        public void UpdateInventoryslotUI(Item itemFound)
    {
        
        inventorySlotImage.sprite = itemInInventorySlot.sprite;
    }

}









































/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public string itemName;
  
    public int totalStack; 

    public Item itemInSlot; 

    public Sprite itemInventoryIcon;
    public int rarityLevel;
    public bool removeItem;

    public string itemType;
    //private Text stackText;
    public Button slotButton;

    
    void OnEnable()
    {
        // Event Subscriptions
        //inventoryUI.onCollidedItemToInvSlot += AddCollidedItemToSlot;

        //Shorty 40's
        slotButton = transform.GetComponent<Button>();

        //ItemInSlot setting to match this Object
        itemInventoryIcon = itemInSlot.sprite;
        rarityLevel = itemInSlot.rarity;
        itemType = itemInSlot.itemType;
        itemName = itemInSlot.itemName;

        //Setting Image to pannel and stack text
        transform.GetComponent<Image>().sprite = itemInventoryIcon;


        //Button functionality
        slotButton.onClick.AddListener(buttonClicked);
        
        void buttonClicked()
        {
            InventoryUI.instance.InventorySlotShortTouched(this, itemInSlot);
        }
       

        
        




    }
*/










