using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerStatistics : MonoBehaviour
{
    public static Action<float> onHealthChanged;
    private float _health = 90;
    [SerializeField]public float health {
        get {return _health;}
        set {_health = Mathf.Clamp(value, 0, 100);}
    }
    


    void Start()
    {
        
        QuickslotBox.onQuickslotUsed += itemUsed;
    }

    public void itemUsed(Item itemUsed)
    {
        Debug.Log("You used an " + itemUsed);
        
        foreach (Effect effect in itemUsed.effects)
        {
            health = health + effect.healValue;
        }
        onHealthChanged(health);
    }




    


}
