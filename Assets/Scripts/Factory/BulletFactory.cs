using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory: MonoBehaviour, IAbstractFactory<Rigidbody>
{
    [SerializeField] Rigidbody bullet;
    private void OnEnable()
    {
        ServiceLocator.Instance.RegisterService(this);
    }
    public Rigidbody Create()
    {
        Rigidbody newBullet = Instantiate(bullet);
        return newBullet;
        
    }
}
