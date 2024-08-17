using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightBullet : IShot
{
    private float bulletSpeed = 50;
    public void Shooting(GameObject shooter, Rigidbody bullet)
    {
        Rigidbody bulletClone = GameObject.Instantiate(bullet, shooter.transform.position + (shooter.transform.rotation * new Vector3(0, 2, 3)), shooter.transform.rotation);
        bulletClone.velocity = shooter.transform.forward * bulletSpeed;
    }
}
