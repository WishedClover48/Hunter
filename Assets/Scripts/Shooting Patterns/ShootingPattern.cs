using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPattern: MonoBehaviour 
{
    private void OnEnable()
    {
        ServiceLocator.Instance.RegisterService(this);
    }
    public void UseShot( Transform shooter, IShot strategy)
    {
        strategy.Shooting(shooter);
    }
}
