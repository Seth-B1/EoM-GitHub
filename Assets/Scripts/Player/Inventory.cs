using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public List<Item> inventoryList;
    public int inventoryCount = 0;



    public Inventory()
    {
        inventoryList = new List<Item>();
        //AddToInventory("null_000");
        //Debug.Log(inventory[0]);

        //inventory.Add(DatabaseMaster.GetItemByID("item_001"));

    }


    public void AddToInventory(string itemID)
    {
        inventoryList.Add(DatabaseMaster.GetItemByID(itemID));  //Returns item data type
        //AddItemToSlot(inventoryList.Add(DatabaseMaster.GetItemByID(itemID)));
        //Simple method to shorthand this line.  Im shook it works because it returns void I thought anything with params needed to return something?
        
    }

    /*public void AddToUI()
    {
        

    }*/

}
