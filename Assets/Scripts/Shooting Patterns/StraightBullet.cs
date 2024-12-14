using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBullet : IShot
{
    private float bulletSpeed = 50;
    public void Initialize(){}
    public void Shooting(Transform shooter)
    {
        Rigidbody bulletClone = ServiceLocator.Instance.GetService<ObjectPool<Rigidbody>>().GetFromPool();
        bulletClone.transform.position = shooter.position + (shooter.rotation * new Vector3(0, 2, 3));
        bulletClone.transform.rotation = shooter.rotation;
        bulletClone.useGravity = false;
        bulletClone.velocity = shooter.forward * bulletSpeed;
    }
}
