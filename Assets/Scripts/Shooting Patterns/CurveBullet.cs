using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveBullet : IShot
{
    private float bulletSpeed = 50;
    public void Shooting(GameObject shooter, Rigidbody bullet)
    {
        Rigidbody bulletClone = GameObject.Instantiate(bullet, shooter.transform.position + (shooter.transform.rotation * new Vector3(0, 2, 3)), shooter.transform.rotation);
        bulletClone.useGravity = true;
        bulletClone.velocity = new Vector3(0, 15, 0) + (shooter.transform.forward / 8) * bulletSpeed;
    }
}
