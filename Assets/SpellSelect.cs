using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSelect : MonoBehaviour
{
    public string righthand;
    public string lefthand;
    Spell spell;

    private void Start()
    {
        spell = this.gameObject.GetComponent<Spell>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            spell.Cast(righthand, 0);
        }
        else if (Input.GetMouseButton(1))
        {
            spell.Cast(lefthand, 1);
        }
    }
}