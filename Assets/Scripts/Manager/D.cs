using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class RankData
{
    public string name;
    public int score;
}

[System.Serializable]
public class RankInfo
{
    public List<RankData> scores = new List<RankData>();

    public List<RankData> GetRank(int count) => scores.OrderByDescending(x => x.score).ToList().GetRange(0, count);
}

public static class D
{
    public static bool Persent(float persent)
    {
        return Random.Range(0, 99) < persent;
    }
}
