using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour, IDamageable
{
    [SerializeField] public int maxHealth;
    [SerializeField] public Image[] numOfTanks;

    private int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        numOfTanks[currentHealth].enabled = false;
        if (currentHealth <= 0)
        {
            GameManager.Instance.PlayerKilled();
        }
    }
    public void RefreshHealth()
    {
        currentHealth = maxHealth;
        for (int i = 0; i < numOfTanks.Length; i++)
        {
            numOfTanks[i].enabled = true;
        }
    }
}
