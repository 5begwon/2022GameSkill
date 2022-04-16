using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

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

public class RankManager : Singleton<RankManager>
{
    public InputField rankInput;
    public GameObject obj;
    public Text text;
    public Button titleButton;

    protected override void Awake()
    {
        base.Awake();
    }

    public void RankIn()
    {
        RankData data = new RankData();
        data.name = rankInput.textComponent.text;
        data.score = D.scoreList[0];
        rankInput.gameObject.SetActive(false);

        obj.SetActive(true);
        text.text = data.name + " : " + data.score.ToString() + "!";
        text.gameObject.SetActive(true);

        JsonLoader.Instance.saveData.score = data.score;
        JsonLoader.Instance.saveData.name = data.name;
        JsonLoader.Instance.Write("ScoreRank", JsonLoader.Instance.saveData);

        titleButton.gameObject.SetActive(true);
    }
}
