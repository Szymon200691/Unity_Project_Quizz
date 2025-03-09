using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


[System.Serializable]
public class ScoreEntry
{
    public string nickname;
    public int score;

    public ScoreEntry(string nickname, int score)
    {
        this.nickname = nickname;
        this.score = score;
    }
}

[System.Serializable]
public class Scoreboard
{
    public List<ScoreEntry> scores = new List<ScoreEntry>();
}

public class ScoreManager : MonoBehaviour
{
    private string path;
    private Scoreboard scoreboard = new Scoreboard();

    private void Start()
    {
        path = Application.persistentDataPath + "/scores.json";

        LoadScores();
    }

    public void AddScore(string nickname, int score)
    {
        scoreboard.scores.Add(new ScoreEntry(nickname, score));
        scoreboard.scores.Sort((a, b) => b.score.CompareTo(a.score));
        SaveScores();
    }

    private void SaveScores()
    {
        string json = JsonUtility.ToJson(scoreboard);
        File.WriteAllText(path, json);
    }

    private void LoadScores()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            scoreboard = JsonUtility.FromJson<Scoreboard>(json);
        }
    }

    public List<ScoreEntry> GetScores()
    {
        return scoreboard.scores;
    }
}
