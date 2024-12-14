using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolInitiator : MonoBehaviour
{
    ObjectPool<Rigidbody> bulletPool;
    private void Start()
    {
        bulletPool = new ObjectPool<Rigidbody>(ServiceLocator.Instance.GetService<BulletFactory>(), 10);
    }
}
