using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class AddQuestion : MonoBehaviour
{
    public TMP_InputField questionField;
    public TMP_InputField answer1Field;
    public TMP_InputField answer2Field;
    public TMP_InputField answer3Field;
    public TMP_InputField answer4Field;
    public TMP_InputField correctAnswerField;
    public TMP_InputField rewardField;
    public Button submitButton;
    public Canvas addQuestioinCanvas;
    public Canvas readQuestionCanvas;
    private string apiUrl = "https://myuchannel.com/app_tik_like/test_add_question.php";

    void Start()
    {
        submitButton.onClick.AddListener(AddQuestionToDatabase);
    }

    void AddQuestionToDatabase()
    {
        addQuestioinCanvas.enabled = false;
        readQuestionCanvas.gameObject.SetActive(true) ;

        StartCoroutine(SendAddQuestionRequest());
    }

    IEnumerator SendAddQuestionRequest()
    {
        string question = questionField.text;
        string answer1 = answer1Field.text;
        string answer2 = answer2Field.text;
        string answer3 = answer3Field.text;
        string answer4 = answer4Field.text;
        string correctAnswer = correctAnswerField.text;
        string reward = rewardField.text;

        string url = $"{apiUrl}?ACTION_TYPE=ADD_QUESTION&question={UnityWebRequest.EscapeURL(question)}&answer1={UnityWebRequest.EscapeURL(answer1)}&answer2={UnityWebRequest.EscapeURL(answer2)}&answer3={UnityWebRequest.EscapeURL(answer3)}&answer4={UnityWebRequest.EscapeURL(answer4)}&correct_answer={UnityWebRequest.EscapeURL(correctAnswer)}&question_reward={UnityWebRequest.EscapeURL(reward)}";

        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error: " + www.error);
        }
        else
        {
            Debug.Log("Question added successfully!");
            // You can add further UI feedback here (e.g., clear the input fields or show a success message).
        }
    }
    
    public string GetQuestion()
    {
         string question = questionField.text;
        return question;
    }
    public string GetFirstAnswer()
    {
        string answer1 = answer1Field.text;
        return answer1;
    }
    public string GetSecondAnswer()
    {
        string answer1 = answer2Field.text;
        return answer1;
    }
    public string GetThirdAnswer()
    {
        string answer1 = answer3Field.text;
        return answer1;
    }
    public string GetFourthAnswer()
    {
        string answer1 = answer4Field.text;
        return answer1;
    }
    public string GetCorrectAnswer()
    
    {
        string answer1 = correctAnswerField.text;
        return answer1;
    }
    public string GetRewardQuestion()

    {
        string answer1 = rewardField.text;
        return answer1;
    }
    public void ClearData()
    {
          questionField.text="";
         answer1Field.text = "";
         answer2Field.text = "";
        answer3Field.text = "";
         answer4Field.text = "";
         correctAnswerField.text = "";
         rewardField.text = "";
    }
}
