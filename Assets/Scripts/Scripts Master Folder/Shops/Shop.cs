using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop", menuName = "Assets/Shops/Shop")]
public class Shop : ScriptableObject
{
    public List<Item> itemsInShop;
}
