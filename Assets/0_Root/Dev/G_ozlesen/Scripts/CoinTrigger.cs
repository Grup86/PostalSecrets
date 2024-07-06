using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class CoinTrigger : MonoBehaviour
{
    public static CoinTrigger Instance { get; private set; }

    public Image XPFilledImage;
    public float XPAmount;
    public TextMeshProUGUI LevelText;
    [HideInInspector] public int Level;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Level = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coins Coin))
        {
            if (Coin.isTrigger) return;
            Coin.Force(transform.up);
            Coin.transform.SetParent(transform);
            Coin.transform.DOLocalMove(Vector3.zero, 0.2f).OnComplete(() =>
            {
                Coin.SetIsTrigger(false);
                GetCoin();
                Coin.transform.SetParent(GameManager.Instance.CoinPooler.spawnTransform);
                Coin.gameObject.SetActive(false);

            }).SetDelay(.5f);
        }
    }
    public void GetCoin()
    {
        XPFilledImage.fillAmount += XPAmount;
        if (XPFilledImage.fillAmount >= 1)
        {
            Level++;
            LevelText.text = "Level " + Level;
            XPFilledImage.fillAmount = 0;
            XPAmount = XPAmount - XPAmount * .1f;
            CanvasController.Instance.ActivateRandomThreeObjects();
            Time.timeScale = 0;
        }
    }


}
