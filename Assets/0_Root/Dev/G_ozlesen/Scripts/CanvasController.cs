using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{
    public static CanvasController Instance { get; private set; }

    [Header("Panels")]
    public List<GameObject> Panels;
    public GameObject NamePanel;
    public GameObject StartPanel;
    public GameObject InGamePanel;
    [Header("Best Score TMP List")]
    [Header("Total Number Of Enemies Killed")]
    public List<TextMeshProUGUI> NameListEnemiesKilled;
    public List<TextMeshProUGUI> ScoreListEnemiesKilled;
    [Header("Longest Survival Time")]
    public List<TextMeshProUGUI> NameListSurvivalTime;
    public List<TextMeshProUGUI> ScoreListSurvivalTime;
    [Header("Other")]
    public GameObject AlertMessage;
    public TMP_InputField NameInputField;
    public TextMeshProUGUI PlayerNameTMP;
    public TextMeshProUGUI TimerTMP;
    public string PlayerName;

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
        TogglePanel(NamePanel);
        DataSetup();
    }


    public void StartGameButtonClick()
    {
        TogglePanel(InGamePanel);
        GameManager.Instance.StartTimer();
    }
    public void GoButtonClick()
    {
        if (NameInputField.text.Length > 0)
        {
            TogglePanel(StartPanel);
            PlayerName = NameInputField.text;
            PlayerNameTMP.text = "Welcome " + PlayerName;

        }
        else
        {
            AlertMessage.SetActive(true);
            StartCoroutine(AlertMessageClose());
        }
    }
    IEnumerator AlertMessageClose()
    {
        yield return BetterWaitForSeconds.Wait(2f);
        AlertMessage.SetActive(false);
    }
    public void TogglePanel(GameObject panel)
    {
        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i].SetActive(Panels[i] == panel);
        }
    }

    public void DataSetup()
    {
        for (int i = 0; i < DataManager.Instance.Data.TotalNumberOfEnemiesKilledData.TotalNumberOfEnemiesKilled.Count; i++)
        {
            NameListEnemiesKilled[i].text = DataManager.Instance.Data.TotalNumberOfEnemiesKilledData.TotalNumberOfEnemiesKilled[i].Name;
            ScoreListEnemiesKilled[i].text = DataManager.Instance.Data.TotalNumberOfEnemiesKilledData.TotalNumberOfEnemiesKilled[i].Score + "";
        }
        for (int i = 0; i < DataManager.Instance.Data.LongestSurvivalTimeData.LongestSurvivalTime.Count; i++)
        {
            NameListSurvivalTime[i].text = DataManager.Instance.Data.LongestSurvivalTimeData.LongestSurvivalTime[i].Name;
            ScoreListSurvivalTime[i].text = DataManager.Instance.Data.LongestSurvivalTimeData.LongestSurvivalTime[i].Score + "";
        }
    }
}
