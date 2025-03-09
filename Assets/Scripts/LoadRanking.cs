using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadRanking : MonoBehaviour
{
    public ScoreManager scoreManager;

    public Transform contentPanel;
    public GameObject recordTemplate;

    private void Start()
    {
        //OpóŸnienie by dane zd¹¿y³y siê wczytaæ z json
        Invoke("ShowScores", 0.1f);
    }

    //Wypis i kolor wyników
    private void ShowScores()
    {
        List<ScoreEntry> scores = scoreManager.GetScores();

        foreach (ScoreEntry record in scores)
        {
            GameObject newRecord = Instantiate(recordTemplate, contentPanel);
            TMP_Text textComponent = newRecord.GetComponent<TMP_Text>();

            textComponent.text = record.nickname + " : " + record.score;

            if (record.score == 5)
            {
                textComponent.color = Color.green;
            }
            else if (record.score == 0)
            {
                textComponent.color = Color.red;
            }
        }
    }
}
