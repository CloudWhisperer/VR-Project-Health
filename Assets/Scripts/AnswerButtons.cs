using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButtons : MonoBehaviour
{
    public TextMeshProUGUI anxietytext;
    public TextMeshProUGUI depressiontext;
    public TextMeshProUGUI stresstext;

    public GameObject answerAbutton;
    public GameObject answerBbutton;
    public GameObject answerCbutton;

    public void AnswerA()
    {
        if(QuestionGenerator.Answer_Increase_Stress_score == "A")
        {
            Debug.Log("answer is a");
            QuizManager.Stresslevel += 1;
            stresstext.text = "Stresslevel = " + QuizManager.Stresslevel.ToString();
        }
        else
        {
            Debug.Log("answer is not A");
        }

        answerAbutton.GetComponent<Button>().enabled = false;
        answerBbutton.GetComponent<Button>().enabled = false;
        answerCbutton.GetComponent<Button>().enabled = false;
        StartCoroutine(Nextquestion());
    }

    public void AnswerB()
    {
        if (QuestionGenerator.Answer_Increase_Stress_score == "B")
        {
            Debug.Log("answer is B");
            QuizManager.Stresslevel += 1;
            stresstext.text = "Stresslevel = " + QuizManager.Stresslevel.ToString();
        }

        else
        {
            Debug.Log("answer is not B");
        }

        answerAbutton.GetComponent<Button>().enabled = false;
        answerBbutton.GetComponent<Button>().enabled = false;
        answerCbutton.GetComponent<Button>().enabled = false;
        StartCoroutine(Nextquestion());
    }

    public void AnswerC()
    {
        if (QuestionGenerator.Answer_Increase_Stress_score == "C")
        {
            Debug.Log("answer is C");
            QuizManager.Stresslevel += 1;
            stresstext.text = "Stresslevel = " + QuizManager.Stresslevel.ToString();
        }

        else
        {
            Debug.Log("answer is not C");
        }

        answerAbutton.GetComponent<Button>().enabled = false;
        answerBbutton.GetComponent<Button>().enabled = false;
        answerCbutton.GetComponent<Button>().enabled = false;
        StartCoroutine(Nextquestion());
    }

    IEnumerator Nextquestion()
    {

        yield return new WaitForSeconds(0.3f);

        QuestionGenerator.questionnumber += 1;
        QuestionGenerator.Displaying_Question = false;
        answerAbutton.GetComponent<Button>().enabled = true;
        answerBbutton.GetComponent<Button>().enabled = true;
        answerCbutton.GetComponent<Button>().enabled = true;


    }
}
