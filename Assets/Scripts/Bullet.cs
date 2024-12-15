using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour, IDamager
{
    [SerializeField] public Rigidbody thisRigidbody;
    [SerializeField] private BulletFlyweight_SO sharedData; 

    private void OnCollisionEnter(Collision other)
    {
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

        if(damageable != null)
        {
            DealDamage(damageable);
        }
        Disappear();
    }
    public void DealDamage(IDamageable damageable)
    {
        damageable.TakeDamage(sharedData.damage);
    }
    private void Disappear()
    {
        if (gameObject.scene.isLoaded)
        {
            Instantiate(sharedData.smoke, transform.position, Quaternion.Euler(transform.rotation * transform.forward));
        }
        ServiceLocator.Instance.GetService<ObjectPool<Rigidbody>>().ReturnToPool(thisRigidbody);
    }
}
