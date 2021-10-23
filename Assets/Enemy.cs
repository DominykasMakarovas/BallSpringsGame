using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] HealthBarController healthBarController;

    private void Start()
    {
        healthBarController.SetMaxHealth(health);
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        
        healthBarController.SetHealth(health);
    }

    public void dealDamage(int damage)
    {
        health -= damage;
    }
}
