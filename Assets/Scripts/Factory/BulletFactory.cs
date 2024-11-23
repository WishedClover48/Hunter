using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory
{
    public enum BulletType
    {
        StraightBullet,
        CurveBullet
    }
    public IShot CreateBullet(BulletType type)
    {
        switch (type)
        {
            case BulletType.StraightBullet:
                return new StraightBullet();
            case BulletType.CurveBullet:
                return new CurveBullet();
            default:
                throw new System.ArgumentException("Invalid bullet type");
        }
    }
}
