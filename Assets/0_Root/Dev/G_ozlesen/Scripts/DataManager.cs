using System.IO;
using UnityEngine;
[DefaultExecutionOrder(-10)]
public class DataManager : MonoBehaviour
{
    public static DataManager Instance { get; private set; }
    private Data _data;
    private string _path;

    public Data Data
    {
        get { return _data; }
        set { _data = value; }
    }

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

        DontDestroyOnLoad(this);
        _path = Path.Combine(Application.persistentDataPath, "oua2024_Grup86.json");
        _data = new Data();
        if (LoadData() == null)
        {
            _data.TotalNumberOfEnemiesKilledData = new TotalNumberOfEnemiesKilledData();
            for (int i = 0; i < 5; i++)
            {
                TotalNumberOfEnemiesKilled tn = new TotalNumberOfEnemiesKilled();
                tn.Name = "Null";
                tn.Score = 0;
                _data.TotalNumberOfEnemiesKilledData.TotalNumberOfEnemiesKilled.Add(tn);
            }

            _data.LongestSurvivalTimeData = new LongestSurvivalTimeData();
            for (int i = 0; i < 5; i++)
            {
                LongestSurvivalTime lst = new LongestSurvivalTime();
                lst.Name = "Null";
                lst.Score = 0;
                _data.LongestSurvivalTimeData.LongestSurvivalTime.Add(lst);
            }


            SaveData();
        }
    }

    private Data LoadData()
    {
        if (!File.Exists(_path)) return null;
        string json = File.ReadAllText(_path);
        _data = JsonUtility.FromJson<Data>(json);
        return _data;
    }
    public void SaveData()
    {
        string json = JsonUtility.ToJson(_data);
        File.WriteAllText(_path, json);
    }

}
