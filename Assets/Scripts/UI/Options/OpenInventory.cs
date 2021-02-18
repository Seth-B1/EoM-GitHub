using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenInventory : MonoBehaviour
{
    public Button openInventoryButton;
    public GameObject inventoryScreen;


    public void OpenClosePlayerInventory()
    {
        if (inventoryScreen.activeSelf == false)
        {

            inventoryScreen.SetActive(true);
            //ui.transform.Find("Quickslots").gameObject.SetActive(false);
            //ui.transform.Find("HealthManaBars").gameObject.SetActive(false);
            //GameManager.gameManager.inventoryOpen = true;
        }
        else inventoryScreen.SetActive(false);


    }

}
