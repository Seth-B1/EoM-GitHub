using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//this is a badass namespace, lets you easily go through lists without foreach statements

public class DatabaseMaster : MonoBehaviour
{
    public ItemDatabase items;
    public MonsterDatabase monsters;
    public AbilityDatabase abilities;
    public ShopDatabase shops;
    public ItemEffectsDatabase itemEffects;
    private static DatabaseMaster instance;
    public GameObject player;
    // The reason why its static is because it makes this a SINGLETON. Meaning only 1 object of this class exists and we can use it anywhere and everywhere.

    void Awake(){
        if (instance == null)
        {
            instance = this;
             //This simply sets the singleton DatabaseMaster named instance to equal this specific class... Which is obviously itself. Ask me if you wanna talk about this It took an adderall binge day to understand it
        }
        else
        {
            Destroy(gameObject);
        }
            //This is a very weird if statement. Its saying on load, if there is no DB master, set this class to it. but if DB master ISNT null, we destroy it. It seems sort of uneeded but its because everytime we change scenes and this script is loaded, it will basically KEEP the DB Master = instance without making a 2nd one. 
            // though we should test without it because i dont think we would lose anything because this is just a DB master, it only has methods for accessing all the databases

        
        //Debug.Log(GetItemByID("item_001"));
        //Instantiate(GetItemByID("item_001").prefab);


    }

    public static Item GetItemByID(string ID)
    {
        return instance.items.allItems.FirstOrDefault(i => i.itemID == ID);
        //the => is a lambda expression. I dont understand these yet.

    }

    public static Ability GetAbilityByID(string ID)
    {
        return instance.abilities.allAbilities.FirstOrDefault(i => i.abilityID == ID);
        //the => is a lambda expression. I dont understand these yet.

    }



}
