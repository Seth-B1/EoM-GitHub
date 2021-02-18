using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEvents : MonoBehaviour
{
    //public Shop openedShop;

    public void OpenShop(Shop openedShop )
    {
        
        Debug.Log("You opened up " + openedShop.name);
        foreach (Item item in openedShop.itemsInShop)
        {
            Debug.Log(item + " : " + item.value);
        }
    }
}
