using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[Serializable]
public class Question
{
    public string question;
    public string correctAnswer;
    public string uncorrectAnswer1;
    public string uncorrectAnswer2;
}

public class Quizz : MonoBehaviour
{
    [SerializeField] private List<Question> questions;
    [SerializeField] private List<TMP_Text> answersText;
    [SerializeField] private TMP_Text questionText;

    [SerializeField] private ScoreManager scoreManager;

    [SerializeField] private MeshRenderer cube;
    [SerializeField] private Material badAnswer;
    [SerializeField] private Material goodAnswer;

    private int correctBtnID = 0;
    private int questionID = 0;
    private int score = 0;

    private string nickname;


    private void Start()
    {
        RandomNick();
        NextQuestion();
    }

    //Losowanie nazwy u¿ytkownika
    private void RandomNick()
    {
        string letters = "abcdefghijklmnoprstuwxyz1234567890";

        for (int i = 0; i < 10; i++)
        {
            int letterID = Random.Range(0, letters.Length);

            nickname += letters[letterID].ToString();
        }
    }

    private void NextQuestion()
    {
        if (questionID == questions.Count)
        {
            EndQuizz();
        }
        else
        {
            //Tworzenie nastêpnego pytania

            List<TMP_Text> answersTextCopy = new List<TMP_Text>(answersText);

            correctBtnID = Random.Range(0, 3);

            answersTextCopy[correctBtnID].text = questions[questionID].correctAnswer;
            answersTextCopy.RemoveAt(correctBtnID);

            answersTextCopy[0].text = questions[questionID].uncorrectAnswer1;
            answersTextCopy[1].text = questions[questionID].uncorrectAnswer2;

            questionText.text = questions[questionID].question;

            questionID++;
        }
    }

    public void Answer(int btnID)
    {
        if (correctBtnID == btnID)
        {
            cube.material = goodAnswer;

            score++;
        }
        else
        {
            cube.material = badAnswer;
        }

        NextQuestion();
    }

    private void EndQuizz()
    {
        scoreManager.AddScore(nickname, score);

        SceneManager.LoadScene("Ranking_View", LoadSceneMode.Single);
    }
}
