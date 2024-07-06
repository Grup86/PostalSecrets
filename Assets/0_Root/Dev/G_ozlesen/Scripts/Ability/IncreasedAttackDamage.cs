using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasedAttackDamage : AbilityBase
{
    public override void OnEnable()
    {
        base.OnEnable();
    }
    public override void ButtonClick()
    {
        base.ButtonClick();
        AttackManager.Instance.Damage = AttackManager.Instance.Damage + 5;
    }
}
