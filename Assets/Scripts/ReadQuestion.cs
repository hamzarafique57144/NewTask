using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using TMPro;  // If using TextMeshPro

public class ReadQuestion : MonoBehaviour
{
    public Button fetchButton;
    public TextMeshProUGUI questionsText;  // Or use a standard Text component
    private string apiUrl = "https://myuchannel.com/app_tik_like/test_read_question.php";

    void Start()
    {
        fetchButton.onClick.AddListener(FetchQuestionsFromDatabase);
    }

    void FetchQuestionsFromDatabase()
    {
        StartCoroutine(SendReadQuestionsRequest());
    }

    IEnumerator SendReadQuestionsRequest()
    {
        string url = $"{apiUrl}?ACTION_TYPE=READ_QUESTIONS";
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error: " + www.error);
        }
        else
        {
            string responseText = www.downloadHandler.text;
            Debug.Log("API Response: " + responseText);

            List<Question> questionsList = ParseQuestions(responseText);
            PopulateTextField(questionsList);
        }
    }

    List<Question> ParseQuestions(string responseText)
    {
        // Parse a JSON array of questions directly into a List<Question>
        QuestionArrayWrapper questionArray = JsonUtility.FromJson<QuestionArrayWrapper>("{\"questions\":" + responseText + "}");
        return new List<Question>(questionArray.questions);
    }

    void PopulateTextField(List<Question> questionsList)
    {
        questionsText.text = "";  // Clear the current text
        foreach (Question q in questionsList)
        {
            questionsText.text += $"ID: {q.id}, Question: {q.question}\n";  // Append each question
        }
    }

    [System.Serializable]
    public class Question
    {
        public string question;
        public int id;
    }

    [System.Serializable]
    public class QuestionArrayWrapper
    {
        public Question[] questions;
    }
}
