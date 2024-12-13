using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLives : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth = 3;

    int currentHealth;

    public void Start()
    {
        FullyHeal();
    }

    public void FullyHeal() 
    { 
        currentHealth = maxHealth;
    }

    public int GetCurrentHealth() => currentHealth;

    public int GetMaxHealth() => maxHealth;

    public void TakeDamage(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);
        Debug.Log($"{gameObject.name} took {damage} damage. Current Health: {currentHealth}/{maxHealth}");
        if (currentHealth <= 0)
            {
            Debug.Log($"{gameObject.name} is destroyed.");
            Destroy(gameObject);
            }
    }
}
