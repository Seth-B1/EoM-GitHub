using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
    public class Effect
    {
        public float duration;
        public int manaValue;
        public int healValue;
    }

[CreateAssetMenu(fileName = "New Item", menuName = "Assets/Item")]
//Allows you to right click > Create and access the menu item path to create a new ASSET of this script
public class Item : ScriptableObject
{
    public string itemName;
    public string itemType;
    public string itemID;
    //public enum Rarity {common, uncommon, rare, legendary};
    public bool isQuestItem;
    public bool isStackable;
    
    //public Rarity rarity;
    public int rarity;
    public int value; 
    public Sprite sprite;
    public GameObject prefab;

    [Header("Weapons")]
    public int damage;
    public float knockback;
    public Vector3 equipPosition;
    public Vector3 equipRotation;


    public Effect[] effects;


    //public bool isConsumable;
    
}
