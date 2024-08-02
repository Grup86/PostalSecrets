using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool StartGame;
    public Transform Player;
    public List<Transform> Enemies = new List<Transform>();

    [Header("Pooler")]
    public ObjectPooler EnemyPooler;
    public ObjectPooler FirePooler;
    public ObjectPooler DamageTMPPooler;
    public ObjectPooler CoinPooler;

    [Header("Other")]

    private float _elapsedTime = 0f;
    private float _lastStartTime;

    public AudioSource AudioSource;
    public AudioClip MenuClip;
    public AudioClip IngameClip;
    public int EnemyKilledCount;
    public float TimeAmount;




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
        EnemyKilledCount = 0;
        CanvasController.Instance.KilledEnemyCount.text = "SCORE: " + EnemyKilledCount;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (StartGame)
        {
            float currentTime = Time.time - _lastStartTime + _elapsedTime;
            TimeAmount = currentTime;
            string minutes = ((int)currentTime / 60).ToString("00");
            string seconds = (currentTime % 60).ToString("00");

            CanvasController.Instance.TimerTMP.text = minutes + ":" + seconds;
        }
    }
    [ContextMenu("StartTimer")]
    public void StartTimer()
    {
        if (!StartGame)
        {
            _lastStartTime = Time.time;
            StartGame = true;
        }
    }
    [ContextMenu("StopTimer")]

    public void StopTimer()
    {
        if (StartGame)
        {
            _elapsedTime += Time.time - _lastStartTime;
            StartGame = false;
        }
    }
    [ContextMenu("ResetTimer")]

    public void ResetTimer()
    {
        _elapsedTime = 0f;
        if (StartGame)
        {
            _lastStartTime = Time.time;
        }
        UpdateTimerText();
    }
    [ContextMenu("UpdateTimerText")]

    private void UpdateTimerText()
    {
        float currentTime = _elapsedTime;

        string minutes = ((int)currentTime / 60).ToString("00");
        string seconds = (currentTime % 60).ToString("00");

        CanvasController.Instance.TimerTMP.text = minutes + ":" + seconds;

    }

    public void SetKilledEnemyCount()
    {
        EnemyKilledCount++;
        CanvasController.Instance.KilledEnemyCount.text = "SCORE: " + EnemyKilledCount;
    }
}
