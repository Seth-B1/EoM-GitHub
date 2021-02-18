using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "New Item Effect", menuName = "Assets/Item Effect/Item Effect")]
public class ItemEffects : ScriptableObject
{
    public int healHealthValue;
    public int healManaValue;
    public int physicalArmorIncrease;
    public float duration;
}
