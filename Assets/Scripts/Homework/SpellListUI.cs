using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpellListUI : MonoBehaviour
{
    [SerializeField] private ServiceLocator serviceLocator;
    [SerializeField] private string spellServiceName = "SpellService";
    [SerializeField] private GameObject SpellList;
    [SerializeField] private GameObject SpellUI;
    [SerializeField] private Spell createSpell;

    TestSpellService service;
    GameObject MainContainer;
    TMP_Text Name;
    TMP_Text BaseDamage;
    TMP_Text ManaCost;
    TMP_Text Description;

    private void Awake()
    {
        service = serviceLocator.GetService(spellServiceName) as TestSpellService;
        AccessService();
    }
    private void AccessService()
    {
        if (service == null)
        {
            Debug.LogError($"{name}: {nameof(service)} is null!");
            return;
        }
        var spells = service.GetAllSpells();
        foreach(Transform child in SpellList.transform)
        {
            Destroy(child.gameObject);
        }
        foreach ( var spell in spells)
        {
            GameObject newSpell = Instantiate(SpellUI, SpellList.transform);

            MainContainer = newSpell.transform.GetChild(1).gameObject;
            Name = MainContainer.transform.GetChild(0).gameObject.GetComponentInChildren<TMP_Text>();
            ManaCost = MainContainer.transform.GetChild(1).gameObject.GetComponentInChildren<TMP_Text>();
            BaseDamage = MainContainer.transform.GetChild(2).gameObject.GetComponentInChildren<TMP_Text>();
            Description = newSpell.transform.GetChild(2).gameObject.GetComponent<TMP_Text>();

            Name.SetText(spell.name);
            BaseDamage.SetText(spell.damage.ToString());
            ManaCost.SetText(spell.manaCost.ToString());
            Description.SetText(spell.description);

        }
    }

    [ContextMenu("Add Spell")]
    private void AddSpell()
    {
        if (service == null)
        {
            Debug.LogError($"{name}: {nameof(service)} is null!");
            return;
        }
        Spell newSpell = new Spell();
        newSpell.name = createSpell.name;
        newSpell.damage = createSpell.damage;
        newSpell.manaCost = createSpell.manaCost;
        newSpell.description = createSpell.description;

        service.UnlockNewSpell(newSpell);
        AccessService();
    }



}
