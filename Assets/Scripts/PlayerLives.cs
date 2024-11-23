using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour, IDamageable
{
    [SerializeField] public int maxHealth;
    [SerializeField] public Image[] numOfTanks;
    public Sprite tank;

    int currentHealth;
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

}
