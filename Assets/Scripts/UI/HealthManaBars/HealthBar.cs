using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public GameObject player;

    void Start()
    {
        PlayerStatistics.onHealthChanged += SetHealth;
        slider.value = player.GetComponent<PlayerStatistics>().health;
    }


    
    public void SetHealth(float health)
    {
        slider.value = health;
       
    }

    public void MatchPlayerHealth()
    {
        player.GetComponent<PlayerStatistics>().health = slider.value;
    }
    public void SetHealthMax(int health)
    {
        slider.maxValue = health;
    }


}


