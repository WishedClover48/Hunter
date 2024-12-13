using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int initialPoolSize = 10;

    private ObjectPool<Bullet> _bulletPool;

    private void Awake()
    {
        // Register the BulletPool instance with the Service Locator
        ServiceLocator.Instance.RegisterService<BulletPool>(this);
    }

    private void Start()
    {
        _bulletPool = new ObjectPool<Bullet>(bulletPrefab, initialPoolSize, transform);
    }

    private void OnDestroy()
    {
        // Unregister the BulletPool from the Service Locator when destroyed
        ServiceLocator.Instance.UnregisterService<BulletPool>();
    }

    public Bullet GetFromPool()
    {
        return _bulletPool.GetFromPool();
    }

    public void ReturnToPool(Bullet bullet)
    {
        _bulletPool.ReturnToPool(bullet);
    }
}
