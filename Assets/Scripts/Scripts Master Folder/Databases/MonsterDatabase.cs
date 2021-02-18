using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster Database", menuName = "Assets/Databases/Monster Database")]
public class MonsterDatabase : ScriptableObject
{
    public List<MonsterData> monsters;
}
