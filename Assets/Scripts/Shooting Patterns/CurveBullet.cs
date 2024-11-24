using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveBullet : IShot
{
    private float bulletSpeed = 80;
    public void Shooting(Transform shooter)
    {
        Rigidbody bulletClone = ServiceLocator.Instance.GetService<BulletFactory>().CreateBullet();
        bulletClone.transform.position = shooter.position + (shooter.rotation * new Vector3(0, 2, 3));
        bulletClone.transform.rotation = shooter.rotation;
        bulletClone.useGravity = true;
        bulletClone.velocity = new Vector3(0, 15, 0) + (shooter.forward / 8) * bulletSpeed;
    }
}
