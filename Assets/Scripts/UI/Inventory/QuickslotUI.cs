using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickslotUI : MonoBehaviour
{

    private static QuickslotUI quickslotUIInstance;
    public bool quickslotFull = false;
    public int quickslotSpace = 5;
    public S_Player player;
    //public List<Transform> quickslotSpace; 
    //public ItemSlot itemSlot;
    //public List<Transform> slots; 
    //public string pickedUpItem = null;
   //private List<ItemSlot> itemSlots;
   //public Dictionary<ItemSlot, Item> quickslotDictionary;

   public delegate void SendItemToQuickslotHandler();
   public delegate void QuickslotFullHandler(Item item);
   //public event SendItemToQuickslotHandler onUpdateQuickslot;
   //public event QuickslotFullHandler onQuickslotFull; 
   
    
}
/*
    void Start()
    {
        if (quickslotUIInstance == null)
        {
            quickslotUIInstance = this;
             
        }
        else
        {
            Destroy(gameObject);
        }

        //Events
        player.onItemPickupToQuickslot +=  AddItemToQuickslot;

        //Initialization
        InitializeQuickslot();
        
    }
    public void InitializeQuickslot()
    {
        //Setting this inventory to players inventory
        //this.inventory = inventory;
        //Creating Dictionary for each quickslot
        quickslotDictionary = new Dictionary<ItemSlot, Item>();

        //slots = new List<Transform>();
        //For each quickslot existing, add it to the dictionary
        foreach (Transform slot in transform)
        {
            quickslotDictionary.Add(slot.GetComponent<ItemSlot>(), DatabaseMaster.GetItemByID("null_000")); 
        }
        foreach (KeyValuePair<ItemSlot, Item> entry in quickslotDictionary)
        {
            entry.Key.itemInSlot = entry.Value;
            entry.Key.GetComponent<Image>().sprite = entry.Value.sprite;
        }



    }
    public void AddItemToQuickslot(Item item)
    {
    
    
             
        foreach (KeyValuePair<ItemSlot, Item> entry in quickslotDictionary)
        { 
            Debug.Log(entry.Value.itemName);       
            if (entry.Value.itemName == item.itemName && item.isStackable == true)
            {
                Debug.Log("Item exists in your quickslot and is stackable");
                entry.Key.totalStack++;
                updateQuickslot();
                break;
            }           
            
            if (quickslotSpace != 0)
            {
                if(entry.Value.itemName == "Empty" && quickslotFull == false)
                {
                Debug.Log("You found a new " + item + "... added to slot " + entry.Key);
                PutItemInThisKey();
                updateQuickslot();
                break;
                }  
            }
            else if (quickslotFull == true && item.isStackable == false)
            {
                Debug.Log("Quickslots full, sending to inventory");
                sendToInventory(item);
                break;
            }
            else continue;
            

        void PutItemInThisKey()
        {
        entry.Key.itemInSlot = item;
        entry.Key.itemInventoryIcon = item.sprite;
        entry.Key.totalStack++;
        quickslotDictionary[entry.Key] = item;
        quickslotSpace --;
        if (quickslotSpace == 0) { quickslotFull = true;}
        }        

        }
    }
    public void updateQuickslot()
    {
        onUpdateQuickslot?.Invoke();
    }
    public void sendToInventory(Item item)
    {
        onQuickslotFull?.Invoke(item);
    }

        
        
    }

*/


