using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleAttack : AbilityBase
{
    public override void OnEnable()
    {
        base.OnEnable();
    }
    public override void ButtonClick()
    {
        base.ButtonClick();
        if (AttackManager.Instance.MultipleAttackCount < 10)
            AttackManager.Instance.MultipleAttackCount++;

    }
}
