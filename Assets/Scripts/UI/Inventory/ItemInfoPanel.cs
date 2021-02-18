using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class ItemInfoPanel : MonoBehaviour
{
    public Animator animator;
    public GraphicRaycaster raycaster;
    public GraphicRaycaster otherItems;
    public Sprite infoPanelSprite;
    public Item infoPanelItem;

}
/*
    void OnEnable()
    {
        //Shorty 40's
        animator = GetComponent<Animator>();
         
        

        //Event Subscribers
        InventoryUI.instance.onItemInfoPanelEnabled += SetItemData;
    }

    void SetItemData(InventorySlot slot, Item item)
    {
        if (item.itemName != "Empty")
        {
        Debug.Log("Something");
        infoPanelItem = item;
        transform.GetChild(0).GetComponent<Image>().sprite = infoPanelItem.sprite;
        }
        else return;
    }





    void Update()
    {
        //Touch touch = Input.touches[0];
        //Ray ray = Camera.main.ScreenPointToRay(touch.position);
        //Change to touch

    if (Input.GetMouseButtonDown(0))
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        List<RaycastResult> results = new List<RaycastResult>();

        pointerData.position = Input.mousePosition;
        this.raycaster.Raycast(pointerData, results);
        this.otherItems.Raycast(pointerData, results);

        if(results.Count == 0)
        {
            InventoryUI.instance.onItemInfoPanelEnabled -= SetItemData;
            this.gameObject.SetActive(false);

        }
    IEnumerator CloseAnimationCoroutine()
    {
        animator.SetBool("OnDisable", true);
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
    }


    }

    

}

*/