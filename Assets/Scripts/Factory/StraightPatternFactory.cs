using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightPatternFactory : MonoBehaviour, IAbstractFactory<IShot>
{
    private void OnEnable()
    {
        ServiceLocator.Instance.RegisterService(this);
    }
    public IShot Create()
    {
            return new StraightBullet();
    }
}
