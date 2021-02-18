using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Effects Database", menuName = "Assets/Databases/Item Effects Database")]
public class ItemEffectsDatabase : ScriptableObject
{
    public List<ItemEffects> itemEffects; 

}
