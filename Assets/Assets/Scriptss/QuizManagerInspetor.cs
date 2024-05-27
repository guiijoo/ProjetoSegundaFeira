
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class QuizManagerInspetor : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;

    int limite;

    public TextMeshProUGUI QuestionText;

    public GameObject inspetor;

    void Start()
    {
        GenerateQuestion();
        Debug.Log(QnA.Count);
        limite = QnA.Count;
    }

    public void Correct()
    {
        currentQuestion++;
        if(currentQuestion<=limite)
        {
            Debug.Log(currentQuestion);
            Debug.Log(limite);
            GenerateQuestion();
        }else{
            Debug.Log("passou do limite");
            Debug.Log(currentQuestion);
            Debug.Log(limite);
            inspetor.GetComponent<Interact>().CancelInvoke();  
            inspetor.GetComponent<Interact>().EndInspetorInteract();    
        }
    }

    void SetAnswer()
    {
       
        for(int i=0; i<options.Length;i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            options[i].GetComponent<Button>().interactable = true;

            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }

        
    }

    void GenerateQuestion()
    {
        QuestionText.text = QnA[currentQuestion].Question;
        SetAnswer();
    }
}
