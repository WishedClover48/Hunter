using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDamager
{
    [SerializeField] public ParticleSystem smoke;
    [SerializeField] public Rigidbody Rigidbody;

    public int damage = 1;

    private void OnCollisionEnter(Collision other)
    {
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();

        if(damageable != null)
        {
            DealDamage(damageable);
        }
        Disappear();
        //Destroy(gameObject);
    }
    public void DealDamage(IDamageable damageable)
    {
        damageable.TakeDamage(damage);
    }

    private void OnDestroy()
    {
        if (gameObject.scene.isLoaded)
        {
            Instantiate(smoke, transform.position, Quaternion.Euler(transform.rotation*transform.forward));
        }
    }
    private void Disappear()
    {
        if (gameObject.scene.isLoaded)
        {
            Instantiate(smoke, transform.position, Quaternion.Euler(transform.rotation * transform.forward));
        }
        ServiceLocator.Instance.GetService<ObjectPool<Rigidbody>>().ReturnToPool(Rigidbody);
    }
}
