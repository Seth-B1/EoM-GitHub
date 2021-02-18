using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class InventoryUI : MonoBehaviour
{
    public GameObject quickslotUI;
    public GameObject inventorySlotUI;
    public GameObject UI;
    public GameObject player;

    public Inventory inventory;
    public static Action<Item> onUpdateSlotUI;



    void Start()
    {
        inventory = player.GetComponent<S_Player>().inventory;
        S_Player.onAddNewItem += UpdateInventoryUI;

    }

    void UpdateInventoryUI(Item itemFound)
    {
        //Check Quickslots
        
        foreach (Transform slot in quickslotUI.transform)
        {
            QuickslotBox quickslotBox = slot.GetComponent<QuickslotBox>();
            // If quickslot is empty add item
            if (quickslotBox.itemInQuickslot == null)
            {
                quickslotBox.itemInQuickslot = itemFound;
                quickslotBox.stackSize++;
                quickslotBox.UpdateQuickslotUI(itemFound);    
                return;             
            }
            // If quickslot has the new Item and item is stackable
            else if (quickslotBox.itemInQuickslot == itemFound && itemFound.isStackable)
            {
                quickslotBox.stackSize++;
                quickslotBox.UpdateQuickslotUI(itemFound);
                return;
            }
            // If Quickslots are full
            else
            {
                Debug.Log("Quickslots full moving to inventory");
            }
        }

        //Check Inventory

        foreach (Transform slot in inventorySlotUI.transform)
        {
            InventorySlot inventorySlot = slot.GetComponent<InventorySlot>();
            // If Inventory slot is empty add item
            if (inventorySlot.itemInInventorySlot == null)
            {
                inventorySlot.itemInInventorySlot = itemFound;
                inventorySlot.stackSize++;
                inventorySlot.UpdateInventoryslotUI(itemFound);
                return;
            }
            // If Inventory slot has the new Item and item is stackable
            else if(inventorySlot.itemInInventorySlot == itemFound && itemFound.isStackable)
            {
                inventorySlot.stackSize++;
                inventorySlot.UpdateInventoryslotUI(itemFound);
                return;
            }
            // If Quickslots are full
            else if (inventory.inventoryCount == 50)
            {
                Debug.Log("Inventory full, no can do");

            }

        }


    }






}









































/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;
    public Inventory inventory;
    public Dictionary<InventorySlot, Item> inventoryDictionary;
    public int inventorySpace = 50;
    public S_Player player;
    public bool inventoryFull = false;
    public QuickslotUI quickslotUI;
    public GameObject itemInfoPanel;
    public delegate void ItemInfoPanelHandler(InventorySlot slot, Item item);
    public event ItemInfoPanelHandler onItemInfoPanelEnabled;
    public InventorySlot selectedSlot;
    public Item selectedItem;
    


    void Start()
    {
        // Setting inventoryUI to singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //Event Subscriptions
        player.onItemPickupToInventory +=  AddToInventory;
        player.onInventoryOpen += InventoryOpened;
        quickslotUI.onQuickslotFull += AddToInventory;

        
        //Shorty 40s
        Transform inventorySlotsParent = transform.Find("InventoryScreen").GetChild(1).GetChild(0).GetComponent<Transform>();
        
        //Begin Start Method
        inventoryDictionary = new Dictionary<InventorySlot, Item>();

        foreach (Transform entry in inventorySlotsParent)
        {
        inventoryDictionary.Add(entry.GetComponent<InventorySlot>(), DatabaseMaster.GetItemByID("null_000"));
        //Debug.Log("Initialized inventory slot");
        }
        foreach (KeyValuePair<InventorySlot, Item> entry in inventoryDictionary)
        {
            entry.Key.itemInSlot = entry.Value;
        }

    }

    public void InitializeInventory(Inventory inventory)
    {
        this.inventory = inventory; 
        //Debug.Log("Inventory initialized, not quickslots");
    }

    void AddToInventory(Item item)
    {
        Debug.Log("Adding item to inventory");
        foreach (KeyValuePair<InventorySlot, Item> entry in inventoryDictionary)
        {
            if(entry.Value.itemName == item.itemName && item.isStackable)
            {
                Debug.Log("You already have a " + item + ", adding to stack");
                entry.Key.totalStack++;
                return;
            }

            else if (inventoryFull == false && entry.Value.itemName == "Empty")
            {
                
                Debug.Log("You found a new " + item + "... added to inventory slot " + entry.Key);
                PutItemInThisKey();
                break;
                
            }
            else if (inventoryFull == true)
            {
                Debug.Log("Inventory full");
            }
            else continue;
        
    void PutItemInThisKey()
            {
            entry.Key.itemInSlot = item;
            entry.Key.totalStack++;
            inventoryDictionary[entry.Key] = item;
            inventorySpace --;
            if (inventorySpace <= 0) { inventoryFull = true;}
            } 
        }          
    }


    public void InventorySlotShortTouched(InventorySlot slot, Item item)
    {
        if (item.itemName != "Empty")
        {
        this.selectedSlot = slot;
        this.selectedItem = item;
        itemInfoPanel.SetActive(true);
        SendDataToInfoPanel(slot, item);
        }
        else return;
    }


//Event shooting
    void SendDataToInfoPanel(InventorySlot slot, Item item)
    {
        
        
        Debug.Log("sending");
        onItemInfoPanelEnabled?.Invoke(slot, item);
    }


void InventoryOpened()
{


}


}
*/