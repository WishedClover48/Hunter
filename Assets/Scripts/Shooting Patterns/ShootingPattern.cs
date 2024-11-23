using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPattern: MonoBehaviour 
{
    private void OnEnable()
    {
        ServiceLocator.Instance.RegisterService(this);
    }
    public void UseShot( Transform shooter, Rigidbody bullet, IShot strategy)
    {
        strategy.Shooting(shooter, bullet);
    }
}
