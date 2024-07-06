using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class AbilityBase : MonoBehaviour
{
    public AbilityType AbilityType;
    public Image AbilityIcon;
    public TextMeshProUGUI HeaderTMP;
    public TextMeshProUGUI ContextTMP;
    public TextMeshProUGUI LevelTMP;
    public int AbilityLevel;

    public virtual void OnEnable()
    {
        AbilityIcon.sprite = AbilityType.AbilityIcon;
        HeaderTMP.text = AbilityType.AbilityHeader;
        ContextTMP.text = AbilityType.AbilityContext;
        LevelTMP.text = "Level " + AbilityLevel;
    }
    public virtual void ButtonClick()
    {
        Time.timeScale = 1;
        AbilityLevel++;
        CanvasController.Instance.ClearAbility();
    }
}
