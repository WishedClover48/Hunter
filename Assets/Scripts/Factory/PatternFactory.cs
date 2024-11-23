using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternFactory
{
    public enum BulletType
    {
        StraightBullet,
        CurveBullet
    }
    public IShot CreatePattern(BulletType type)
    {
        switch (type)
        {
            case BulletType.StraightBullet:
                return new StraightBullet();
            case BulletType.CurveBullet:
                return new CurveBullet();
            default:
                throw new System.ArgumentException("Invalid pattern type");
        }
    }
}
