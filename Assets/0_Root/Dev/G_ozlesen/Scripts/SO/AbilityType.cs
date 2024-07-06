using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Ability Type",menuName ="Ability Type")]
public class AbilityType : ScriptableObject
{
    public Sprite AbilityIcon;
    public string AbilityHeader;
    public string AbilityContext;
}
