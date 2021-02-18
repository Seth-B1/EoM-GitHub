using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class S_Player : MonoBehaviour
{

    public Inventory inventory; 
    public GameObject inventoryScreen;
    public GameObject ui; 
    public GameObject pickupTextList;
    public static Action<Item> onAddNewItem;





    
    void Start()
    {
        
        inventory = new Inventory(); 


        //Below may be obsolete now
        //Testing stuff
        /*inventory.AddToInventory("item_001");
        inventory.AddToInventory("weapon_001");
        Debug.Log("You selected " + inventory.inventoryList[1].name + " and it has a rarity of " + inventory.inventoryList[1].rarity);
        */


    }

    void Update()
    {
       /* if (Input.GetKeyDown("i") && inventoryScreen.activeSelf == false)
        {
            
            inventoryScreen.SetActive(true);
            //ui.transform.Find("Quickslots").gameObject.SetActive(false);
            ui.transform.Find("HealthManaBars").gameObject.SetActive(false);
            GameManager.gameManager.inventoryOpen = true;
            
            
        }
        else if (Input.GetKeyDown("i") && inventoryScreen.activeSelf == true)
        {
            inventoryScreen.transform.Find("ItemInfoPanel").gameObject.SetActive(false);
            inventoryScreen.SetActive(false);
            //ui.transform.Find("Quickslots").gameObject.SetActive(true);
            ui.transform.Find("HealthManaBars").gameObject.SetActive(true);
            GameManager.gameManager.inventoryOpen = false;
            
        }
    */
    }
    void OnTriggerEnter(Collider collision)
    {

    if (collision.gameObject.tag == "Item")
    {
        //Shortcuts
        Item itemFound = DatabaseMaster.GetItemByID(collision.gameObject.name.Substring(0,8));

        // Found an owned stackable Item
        if (inventory.inventoryList.Contains(itemFound) && itemFound.isStackable)
        {
            inventory.inventoryList.Add(itemFound);
            Debug.Log("Found a stackable item you already own");
            onAddNewItem(itemFound);
            Destroy(collision.gameObject);
        }
        // Found an item that is new or non-stackable
        else if (inventory.inventoryCount != 50)
        {
            inventory.inventoryList.Add(itemFound);
            inventory.inventoryCount++;
            Debug.Log("Found a new item");
            onAddNewItem(itemFound);
            Destroy(collision.gameObject);
        }
        // Inventory Full
        else
        {
            Debug.Log("Inventory full");
        }
    }




    }






    //ORIGINAL COLLISION FUNCTIONALITY
    /*void OnTriggerEnter(Collider collision)
        {
            //refactor to a switch as well
            if (collision.gameObject.tag == "Item")
            {
                if (quickslotUI.quickslotFull == true && newStackable() == true)
                {
                inventory.AddToInventory(collision.gameObject.GetComponent<Transform>().name.Substring(0, 8));
               quickslotUI.AddItemToSlot(DatabaseMaster.GetItemByID(collision.gameObject.GetComponent<Transform>().name.Substring(0,8)));
                Destroy(collision.gameObject);
                }
                else if (quickslotUI.quickslotFull == false)
                {
                //collision.gameObject.name = quickslotUI.pickedUpItem;
                inventory.AddToInventory(collision.gameObject.GetComponent<Transform>().name.Substring(0, 8));
               quickslotUI.AddItemToSlot(DatabaseMaster.GetItemByID(collision.gameObject.GetComponent<Transform>().name.Substring(0,8)));
                Destroy(collision.gameObject);
                }
                else
                {
                    Debug.Log("Inventory Full");
                }
            }

            bool newStackable()
            {
                //Debug.Log("checking newstackable");
                if (DatabaseMaster.GetItemByID(collision.gameObject.GetComponent<Transform>().name.Substring(0,8)).isStackable == true)
                {
                    foreach (KeyValuePair<ItemSlot, Item> entry in quickslotUI.quickslotDictionary)
                    {
                       // Debug.Log("Looping");
                        if (entry.Value.itemID == DatabaseMaster.GetItemByID(collision.gameObject.GetComponent<Transform>().name.Substring(0,8)).itemID)
                        {
                            return true;
                        }
                        else continue;
                        
                    }
                    return true;  
                }
                else return false;

            }

        }*/

}
