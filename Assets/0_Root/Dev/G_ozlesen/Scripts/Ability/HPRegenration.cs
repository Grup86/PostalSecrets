using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPRegenration : AbilityBase
{
    public override void OnEnable()
    {
        base.OnEnable();
    }
    public override void ButtonClick()
    {
        base.ButtonClick();
        AttackManager.Instance.SetHealt();
    }
}
