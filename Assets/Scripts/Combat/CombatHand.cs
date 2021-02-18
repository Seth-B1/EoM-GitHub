using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatHand : MonoBehaviour
{
    public Item weaponEquippedConfig;
    public GameObject weaponEquipped;
    public GameObject weaponHolder;
    public BoxCollider weaponCollider;
    public int damage;
    public int knockback;
    public Animator animator;
    public bool inCombo;



    void Start()
    {
        //Subscriptions
        ActionButton.onAttack += ExecuteAttack;
            //Add one to change weaponEquippedConfig to equal equip slot in inventory

            
        
        
        //Assigns the weaponHolder to this object
        Transform[] playerChildren = GetComponentsInChildren<Transform>();    
        for (int i = 0; i < playerChildren.Length; i++)
        {
            if(playerChildren[i].gameObject.name == "WeaponHolder")
            {
                weaponHolder = playerChildren[i].gameObject;
                break;
            }
            else continue;            
        }

        // I might re-use InitializeWeapon when equipping new gear. This would be a subscriber to the change gear event maybe?
        InitializeWeapon(weaponEquippedConfig);

        animator.SetBool("Attack_NextInputReady", true);
    }

    void InitializeWeapon(Item weaponEquippedConfig)
    {
            //Instantiates weapon and sets the rotation/position 
        weaponEquipped = Instantiate(weaponEquippedConfig.prefab, transform.localPosition, transform.rotation, weaponHolder.transform) as GameObject;
        weaponEquipped.transform.localPosition = weaponEquippedConfig.equipPosition;
        weaponEquipped.transform.Rotate(weaponEquippedConfig.equipRotation);
        
        damage = weaponEquippedConfig.damage;
            //finds and sets the weapons collider to false
        weaponCollider = weaponEquipped.GetComponent<BoxCollider>();
        weaponCollider.isTrigger = true;
        weaponCollider.enabled = false;

            //Will assign animation layer/parameters to that weapon type
        switch(weaponEquippedConfig.itemType)
        {
            case "Greatsword":
            Debug.Log("Loading Greatsword animations");
            break;
            //Replace debug with a method
        }
       
    }


        //Will perform the attack animations by sending to AnimationEventHandler
    void ExecuteAttack()
    {  
        if(weaponEquippedConfig.itemType == "Greatsword")
        {
            animator.SetTrigger("Attack_Tap");
        }
    }

    void DamageFrameBegin()
    {
        weaponCollider.enabled = true;

    }
    
    void DamageFrameEnd()
    {
        weaponCollider.enabled = false;
    }

    void DisableInput()
    {
        animator.SetBool("Attack_NextInputReady", false);
        animator.SetBool("GoToIdle", false);
    }

    void EnableInput()
    {
        animator.SetBool("Attack_NextInputReady", true);
    }
    void EnableIdle()
    {
        animator.SetBool("GoToIdle", true);
        animator.SetBool("Attack_NextInputReady", true);
    }

}
