using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveBullet : IShot
{
    private float bulletSpeed = 50;
    public void Shooting(Transform shooter, Rigidbody bullet)
    {
        Rigidbody bulletClone = GameObject.Instantiate(bullet, shooter.position + (shooter.rotation * new Vector3(0, 2, 3)), shooter.rotation);
        bulletClone.useGravity = true;
        bulletClone.velocity = new Vector3(0, 15, 0) + (shooter.forward / 8) * bulletSpeed;
    }
}
