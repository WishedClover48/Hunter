using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour, IDamageable
{
    [SerializeField] public Image[] numOfTanks;

    private ObjectLives _wrappedObject;
    public void Start()
    {
        _wrappedObject = gameObject.AddComponent<ObjectLives>();
        _wrappedObject.FullyHeal();
        if (numOfTanks.Length != _wrappedObject.GetMaxHealth())
        {
            Debug.LogWarning("Number of tank icons does not match max health.");
        }
        RefreshHealth();
    }

    public void TakeDamage(int damage)
    {
        _wrappedObject?.TakeDamage(damage);

        int currentHealth = _wrappedObject.GetCurrentHealth();

        if (currentHealth >= 0 && currentHealth < numOfTanks.Length)
        {
            numOfTanks[currentHealth].enabled = false;
        }
        if (currentHealth <= 0)
        {
            Kill();
        }
    }
    public void RefreshHealth()
    {
        int maxHealth = _wrappedObject.GetMaxHealth();

        _wrappedObject.FullyHeal();
        for (int i = 0; i < numOfTanks.Length; i++)
        {
            numOfTanks[i].enabled = true;
        }
    }

    public void Kill()
    {
        GameManager.Instance.PlayerKilled();
    }
}
