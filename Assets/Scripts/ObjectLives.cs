using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLives : MonoBehaviour, IDamageable
{
    [SerializeField] public int maxHealth;

    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }

    }

}
