using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Database", menuName = "Assets/Databases/Shop Database")]
public class ShopDatabase : ScriptableObject
{
    public List<Shop> shops;
}
