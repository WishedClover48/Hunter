using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpellService : MonoBehaviour
{
    [SerializeField] ServiceLocator serviceLocator;
    [SerializeField] List<Spell> spells;
    [SerializeField] string serviceName = "SpellService";

    private void OnEnable()
    {
        serviceLocator.SetService(serviceName, this);
    }
    public List<Spell> GetAllSpells()
    {
        return spells;
    }
    public void UnlockNewSpell(Spell newSpell)
    {
        spells.Add(newSpell);
    }
}
