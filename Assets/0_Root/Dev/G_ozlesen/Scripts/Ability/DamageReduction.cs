using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReduction : AbilityBase
{
    public override void OnEnable()
    {
        base.OnEnable();
    }
    public override void ButtonClick()
    {
        base.ButtonClick();
        AttackManager.Instance.Armor++;
    }
}
