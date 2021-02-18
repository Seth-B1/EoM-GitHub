using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class ItemPickupTextList : MonoBehaviour
{
    [SerializeField]private Transform itemPickupWindow;
    private GameObject itemPickupWindowInstance;
    public Transform player;
    public Camera playerView;
    public static Action<Item> onNewPickupWindow;
    public static Action<Item> onUpdatePickupWindow;

    public List<ItemPickedUpText> windows;

    

    void Start()
    {

        windows = new List<ItemPickedUpText>();
        S_Player.onAddNewItem += PrintObtainedItemText;
        


        
    }

    void PrintObtainedItemText(Item itemFound)
    {
        if (windows.Count == 0)
        {
            GameObject itemPickupWindowInstance = Instantiate(itemPickupWindow.gameObject);
            itemPickupWindowInstance.GetComponent<ItemPickedUpText>().item = itemFound;
            itemPickupWindowInstance.transform.rotation = Quaternion.Euler(playerView.transform.rotation.eulerAngles.x, playerView.transform.rotation.eulerAngles.y , 0f);
            itemPickupWindowInstance.transform.position = new Vector3(player.position.x, player.localScale.y + 2, player.position.z);
            windows.Add(itemPickupWindowInstance.GetComponent<ItemPickedUpText>());
        }
        else
        {
            foreach (ItemPickedUpText window in windows)
            {
                if (window.item == itemFound)
                {
                    window.animator.Play("ItemPickup_Float", -1, 0f);

                    window.counter++;
                    window.counterText.text = ("x" + window.counter.ToString());
                    window.transform.position = FindObjectOfType<ItemPickupTextList>().player.position;

                    //onUpdatePickupWindow(itemFound);
                    return;
                }
                else continue;
            }
            GameObject itemPickupWindowInstance = Instantiate(itemPickupWindow.gameObject);
            itemPickupWindowInstance.GetComponent<ItemPickedUpText>().item = itemFound;
            itemPickupWindowInstance.transform.rotation = Quaternion.Euler(playerView.transform.rotation.eulerAngles.x, playerView.transform.rotation.eulerAngles.y , 0f);
            itemPickupWindowInstance.transform.position = new Vector3(player.position.x, player.localScale.y + 2, player.position.z);
            windows.Add(itemPickupWindowInstance.GetComponent<ItemPickedUpText>());


        }
    }        
}
