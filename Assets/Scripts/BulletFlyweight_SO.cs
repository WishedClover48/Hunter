using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "BulletFlyweight", menuName = "Flyweight/Bullet")]
public class BulletFlyweight_SO : ScriptableObject
{
    [SerializeField] public ParticleSystem smoke;
    [SerializeField] public int damage;
}
