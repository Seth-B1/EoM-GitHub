using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability Database", menuName = "Assets/Databases/Ability Database")]
public class AbilityDatabase : ScriptableObject
{
    public List<Ability> allAbilities; 

}
