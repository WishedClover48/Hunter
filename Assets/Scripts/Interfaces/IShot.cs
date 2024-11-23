using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShot
{
    public void Shooting(Transform shooter, Rigidbody bullet);
}
