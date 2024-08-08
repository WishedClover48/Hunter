using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamager
{
    //public int damage {get; set;}; 
    public void DealDamage(IDamageable other);
}
