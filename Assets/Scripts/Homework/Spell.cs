using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Spell
{
    [SerializeField] public string name;
    [SerializeField] public string description;
    [SerializeField] public int manaCost;
    [SerializeField] public int damage;
}
