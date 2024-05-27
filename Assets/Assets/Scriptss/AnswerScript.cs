using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{

    public bool isCorrect = false;
    public QuizManagerInspetor quizManagerInspetor;


    public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("Correct");
            quizManagerInspetor.Correct();
        }else{
            Debug.Log("Wrong");
            gameObject.GetComponent<Button>().interactable = false;
        }

    }
}
