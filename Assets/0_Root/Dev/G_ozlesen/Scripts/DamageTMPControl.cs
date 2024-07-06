using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DamageTMPControl : MonoBehaviour
{
    public CanvasGroup CanvasGroup;
    public TextMeshProUGUI DamageTMP;

    private void OnEnable()
    {
        CanvasGroup.alpha = 1;
        CanvasGroupChangeAlpha();
    }
    public void SetText(Vector3 pos,int damage)
    {
        transform.localEulerAngles = Vector3.zero;
        transform.position = pos;
        DamageTMP.text = damage + "";
    }
    public void CanvasGroupChangeAlpha()
    {
        DOVirtual.Float(1, 0, 1f, v =>
        {
            CanvasGroup.alpha = v;
        }).SetEase(Ease.Linear).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
}
