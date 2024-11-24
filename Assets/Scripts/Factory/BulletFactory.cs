using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory: MonoBehaviour
{
    [SerializeField] Rigidbody bullet;
    private void OnEnable()
    {
        ServiceLocator.Instance.RegisterService(this);
    }
    public Rigidbody CreateBullet()
    {
        Rigidbody newBullet = Instantiate(bullet);
        return newBullet;
        
    }
}
