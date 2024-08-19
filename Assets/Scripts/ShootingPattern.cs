using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPattern
{
    public void UseShot( GameObject shooter, Rigidbody bullet, IShot strategy)
    {
        strategy.Shooting(shooter, bullet);
    }
}
