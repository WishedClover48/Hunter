using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDamager
{
    public int damage = 1;

    private void OnCollisionEnter(Collision other)
    {
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

        if(damageable != null)
        {
            DealDamage(damageable);
        }
        Destroy(gameObject);
    }
    public void DealDamage(IDamageable damageable)
    {
        damageable.TakeDamage(damage);
    }
}
