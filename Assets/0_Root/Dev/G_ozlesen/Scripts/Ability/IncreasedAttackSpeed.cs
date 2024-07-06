using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasedAttackSpeed : AbilityBase
{
    public override void OnEnable()
    {
        base.OnEnable();
    }
    public override void ButtonClick()
    {
        base.ButtonClick();
        if (AttackManager.Instance.AttackSpeed >= .2f)
            AttackManager.Instance.AttackSpeed = AttackManager.Instance.AttackSpeed - .1f;
    }
}
