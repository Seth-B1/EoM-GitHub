using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterStats : MonoBehaviour
{

    public int health;
    public int poise = 100;
    public bool isAlive;

    public MonsterStats(MonsterData monsterData)
    {
        health = monsterData.health;
        poise = monsterData.poise;

        isAlive = true;
    }
    

/*
    private void OnTriggerEnter(Collider collider)
    {
        CombatHand hitByWeapon = FindObjectOfType<CombatHand>();        

        if(hitByWeapon.weaponCollider == collider && isAlive)
        {
            
            //Debug.Log("Something was hit by " + collider.gameObject.name);
            
            Vector3 direction = (transform.position - collider.gameObject.transform.position).normalized;
            rb.AddForce(direction, ForceMode.Impulse);
            TakeDamage(hitByWeapon);
            
            
        }
    }

    void TakeDamage(CombatHand hitByWeapon)
    {
        monsterPoise -= hitByWeapon.knockback;
        monsterHealth -= hitByWeapon.damage;
        //if poise <= 0 call knockedBack()
        //check if any elemental bonus damage/reduction applies
        if (monsterHealth <= 0)
        {
            monsterDied();
            
        }
    
    }

    
    void monsterDied()
    {
        Debug.Log("Slime slayed");
        isAlive = false;
        //animator(death, true) > Fade away > delete instance
        
        //Instantiate random loot drop, play effect of item shooting out when fade ends
         
    }


*/


}
