using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attack
{
    public string attackName;
    public float maximumDistanceNeededToAttack;
    public float minimumDistanceNeededToAttack;

    public float maximumAttackAngle;
    public float minimumAttackAngle;

    public int damage;


}


[CreateAssetMenu(fileName = "New Monster", menuName = "Assets/Monster")]
public class MonsterData : ScriptableObject
{
    public string monsterName;
    public string monsterID;
    public Item[] potentialLoot;
    public int health;
    public int poise;
    
    [Header("Eyesight and Detection")]
    public int detectionRadius;
    public int minimumDetectionRange;
    public int maximumDetectionRange;

    public Attack[] possibleAttacks;

    [Space]
    public string[] elementalWeakness;
    public string[] elementalStrength;
    public GameObject monsterPrefab;

}
