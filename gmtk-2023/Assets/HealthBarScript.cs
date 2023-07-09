using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    //public EntityStats playerHealth;

    private void Start()
    {
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<EntityStats>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = 1000000;
        healthBar.value = 1000000;
    }

    public void SetHealth(int hp)
    {
        healthBar.value = hp;
    }
}