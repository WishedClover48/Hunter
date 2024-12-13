using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBullet : IShot
{
    private float bulletSpeed = 50;
    private BulletPool bulletPool;
    public void Initialize()
    {
        bulletPool = ServiceLocator.Instance.GetService<BulletPool>();
    }
        public void Shooting(Transform shooter)
    {
        Rigidbody bulletClone = ServiceLocator.Instance.GetService<BulletFactory>().CreateBullet();
        bulletClone.transform.position = shooter.position + (shooter.rotation * new Vector3(0, 2, 3));
        bulletClone.transform.rotation = shooter.rotation;
        bulletClone.velocity = shooter.forward * bulletSpeed;
    }
}
