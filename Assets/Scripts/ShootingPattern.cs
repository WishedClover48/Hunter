using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPattern
{
    public enum Shot { Straight, Parabolic }
    StraightBullet StraightBullet = new StraightBullet();
    CurveBullet CurveBullet = new CurveBullet();
    public Shot shoot = Shot.Straight;
    public void UseShot( GameObject shooter, Rigidbody bullet)
    {
        switch (shoot)
        {
            case Shot.Straight:
                StraightBullet.Shooting(shooter, bullet);
                break;
            case Shot.Parabolic:
                CurveBullet.Shooting(shooter, bullet);
                break;
            default:
                break;
        }
    }
}
