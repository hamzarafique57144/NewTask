using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetData : MonoBehaviour
{
    public TextMeshProUGUI[] textInputs;
    public AddQuestion addQuestion;
    public Button dataFetchButton;
    public Button nextQuestion;
    public Canvas addQuestionCanvas;
    public GameObject PANEL;

    
    private void Awake()
    {
        dataFetchButton.onClick.AddListener(() =>
        {
            Invoke(nameof(EnableAllTexts), 2.3f);
            
        });
        nextQuestion.onClick.AddListener(() =>
        {
            foreach (TextMeshProUGUI text in textInputs)
            {
                text.enabled = false;
                //text.text = " ";
                this.gameObject.SetActive(false);
                addQuestion.ClearData();
                addQuestionCanvas.enabled = true;

            }
        });
    }
    private void Start()
    {
        PANEL.transform.position = new Vector3(0, -6.103516f, 0);
        foreach (TextMeshProUGUI text in textInputs)
        {
            text.enabled = false;
        }
        textInputs[0].text ="Question: " + addQuestion.GetQuestion();
        textInputs[1].text = "Answer 1: "+ addQuestion.GetFirstAnswer();
        textInputs[2].text = "Answer 2: "+addQuestion.GetSecondAnswer();
        textInputs[3].text = "Answer 3: "+addQuestion.GetThirdAnswer();
        textInputs[4].text = "Answer 4: " + addQuestion.GetFourthAnswer();
        textInputs[5].text = "Correct Answer: " + addQuestion.GetCorrectAnswer();
        textInputs[6].text = "Reward Question: " + addQuestion.GetRewardQuestion();

    }
     
    void EnableAllTexts()
    {
        foreach (TextMeshProUGUI text in textInputs)
        {
            text.enabled = true;
        }
    }
}
