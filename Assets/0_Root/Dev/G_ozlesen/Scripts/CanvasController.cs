using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    public static CanvasController Instance { get; private set; }

    [Header("Panels")]
    public List<GameObject> Panels;
    public GameObject NamePanel;
    public GameObject StartPanel;
    public GameObject InGamePanel;
    public GameObject EndGamePanel;
    [Header("Best Score TMP List")]
    [Header("Total Number Of Enemies Killed")]
    public List<TextMeshProUGUI> NameListEnemiesKilled;
    public List<TextMeshProUGUI> ScoreListEnemiesKilled;
    [Header("Longest Survival Time")]
    public List<TextMeshProUGUI> NameListSurvivalTime;
    public List<TextMeshProUGUI> ScoreListSurvivalTime;
    [Header("Ability")]
    public List<GameObject> Ability;
    public Transform AbilityParent;
    [Header("Other")]
    public GameObject AlertMessage;
    public TMP_InputField NameInputField;
    public TextMeshProUGUI PlayerNameTMP;
    public TextMeshProUGUI IngamePlayerNameTMP;
    public TextMeshProUGUI TimerTMP;
    public TextMeshProUGUI KilledEnemyCount;


    [Header("End Game Panel")]
    public TextMeshProUGUI EndGameTotalEnemyCountTMP;
    public TextMeshProUGUI EndGameTotalSurvivalTMP;
    public TextMeshProUGUI EndGamePlayerNameTMP;
    [HideInInspector] public string PlayerName;

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
            IngamePlayerNameTMP.text = PlayerName;

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

    public void ActivateRandomThreeObjects()
    {
        List<GameObject> tempList = new List<GameObject>(Ability);
        List<GameObject> selectedObjects = new List<GameObject>();

        for (int i = 0; i < 3; i++)
        {
            int randomIndex = Random.Range(0, tempList.Count);
            selectedObjects.Add(tempList[randomIndex]);
            tempList.RemoveAt(randomIndex);
        }
        foreach (GameObject obj in selectedObjects)
        {
            obj.SetActive(true);
        }
    }
    public void ClearAbility()
    {
        foreach (Transform child in AbilityParent)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void MainMenuClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void EndGamePanelSetup()
    {
        EndGameTotalEnemyCountTMP.text = GameManager.Instance.EnemyKilledCount+ "";
        EndGameTotalSurvivalTMP.text = TimerTMP.text;
        EndGamePlayerNameTMP.text = PlayerName;


        for (int i = 0; i < 5; i++)
        {
            if(GameManager.Instance.EnemyKilledCount>= DataManager.Instance.Data.TotalNumberOfEnemiesKilledData.TotalNumberOfEnemiesKilled[i].Score)
            {
                TotalNumberOfEnemiesKilled tn = new TotalNumberOfEnemiesKilled();
                tn.Name = PlayerName;
                tn.Score = GameManager.Instance.EnemyKilledCount;
                DataManager.Instance.Data.TotalNumberOfEnemiesKilledData.TotalNumberOfEnemiesKilled.Insert(i, tn);
                break;
            }
        }

        for (int i = 0; i < 5; i++)
        {
            if (GameManager.Instance.TimeAmount >= DataManager.Instance.Data.LongestSurvivalTimeData.LongestSurvivalTime[i].Score)
            {
                LongestSurvivalTime ls = new LongestSurvivalTime();
                ls.Name = PlayerName;
                ls.Score = (int)GameManager.Instance.TimeAmount;
                DataManager.Instance.Data.LongestSurvivalTimeData.LongestSurvivalTime.Insert(i, ls);
                break;
            }
        }

        DataManager.Instance.SaveData();

    }




    public void DataSetup()
    {
        for (int i = 0; i < 5; i++)
        {
            NameListEnemiesKilled[i].text = DataManager.Instance.Data.TotalNumberOfEnemiesKilledData.TotalNumberOfEnemiesKilled[i].Name;
            ScoreListEnemiesKilled[i].text = DataManager.Instance.Data.TotalNumberOfEnemiesKilledData.TotalNumberOfEnemiesKilled[i].Score + "";
        }
        for (int i = 0; i < 5; i++)
        {
            NameListSurvivalTime[i].text = DataManager.Instance.Data.LongestSurvivalTimeData.LongestSurvivalTime[i].Name;

            string minutes = ((int)DataManager.Instance.Data.LongestSurvivalTimeData.LongestSurvivalTime[i].Score / 60).ToString("00");
            string seconds = (DataManager.Instance.Data.LongestSurvivalTimeData.LongestSurvivalTime[i].Score % 60).ToString("00");

            ScoreListSurvivalTime[i].text = minutes + ":" + seconds;
        }
    }
}
