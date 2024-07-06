using System.Collections.Generic;

[System.Serializable]
public class Data
{
    public TotalNumberOfEnemiesKilledData TotalNumberOfEnemiesKilledData;
    public LongestSurvivalTimeData LongestSurvivalTimeData;

}

[System.Serializable]
public class TotalNumberOfEnemiesKilledData
{
    public List<TotalNumberOfEnemiesKilled> TotalNumberOfEnemiesKilled = new List<TotalNumberOfEnemiesKilled>();
}
[System.Serializable]
public struct TotalNumberOfEnemiesKilled
{
    public string Name;
    public int Score;
}
[System.Serializable]
public class LongestSurvivalTimeData
{
    public List<LongestSurvivalTime> LongestSurvivalTime = new List<LongestSurvivalTime>();
}
[System.Serializable]
public struct LongestSurvivalTime
{
    public string Name;
    public int Score;
}
