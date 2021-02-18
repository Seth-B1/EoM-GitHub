using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class MenuItems : MonoBehaviour
{
        //move the bottom MenuItem to a new script named MenuItemManager or something... lets make a lot of these.
    [MenuItem("Tools/Monsters/Kill All Monsters")]
    public static void KillAllMonsters()
    {
        Debug.Log("Monsters killed");

    }
}
