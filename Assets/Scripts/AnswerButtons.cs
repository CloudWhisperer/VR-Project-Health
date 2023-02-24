using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButtons : MonoBehaviour
{
    //the DEBUG text tracker of the 3 scores
    public TextMeshProUGUI anxietytext;
    public TextMeshProUGUI depressiontext;
    public TextMeshProUGUI stresstext;

    //the answer buttons
    public GameObject answerAbutton;
    public GameObject answerBbutton;
    public GameObject answerCbutton;

    public void AnswerA()
    {
        //if the user picks a...
        if(QuestionGenerator.Answer_that_increases_score == "A")
        {
            //and its a stressquestion...
            if (QuestionGenerator.stressquestion == true)
            {
                //do this!
                QuizManager.Stresslevel += 1;
                stresstext.text = "Stresslevel = " + QuizManager.Stresslevel.ToString();
            }

            //and its a depressionquestion...
            if (QuestionGenerator.depressionquestion == true)
            {
                //do this!
                QuizManager.Depressionlevel += 1;
                depressiontext.text = "Depressionlevel = " + QuizManager.Depressionlevel.ToString();
            }

            //and its a anxietyquestion...
            if (QuestionGenerator.anxietyquestion == true)
            {
                //do this!
                QuizManager.Anxietylevel += 1;
                anxietytext.text = "Anxietylevel = " + QuizManager.Anxietylevel.ToString();
            }

            //and its a personalquestion...
            if (QuestionGenerator.personalquestion == true)
            {
                //do personal code here
            }
        }

        //if user gets another choice, there isnt a wrong is there? ;p
        else
        {
            Debug.Log("answer is not A");
        }

        //disables the button until the function turns it on

        answerAbutton.GetComponent<Button>().enabled = false;
        answerBbutton.GetComponent<Button>().enabled = false;
        answerCbutton.GetComponent<Button>().enabled = false;
        StartCoroutine(Nextquestion());

    }

    //same thing as A
    public void AnswerB()
    {
        if (QuestionGenerator.Answer_that_increases_score == "B")
        {
            if (QuestionGenerator.stressquestion == true)
            {
                QuizManager.Stresslevel += 1;
                stresstext.text = "Stresslevel = " + QuizManager.Stresslevel.ToString();
            }

            if (QuestionGenerator.depressionquestion == true)
            {
                QuizManager.Depressionlevel += 1;
                depressiontext.text = "Depressionlevel = " + QuizManager.Depressionlevel.ToString();
            }

            if (QuestionGenerator.anxietyquestion == true)
            {
                QuizManager.Anxietylevel += 1;
                anxietytext.text = "Anxietylevel = " + QuizManager.Anxietylevel.ToString();
            }

            if (QuestionGenerator.personalquestion == true)
            {
                //do personal code here
            }
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
        if (QuestionGenerator.Answer_that_increases_score == "C")
        {
            if(QuestionGenerator.stressquestion == true)
            {
                QuizManager.Stresslevel += 1;
                stresstext.text = "Stresslevel = " + QuizManager.Stresslevel.ToString();
            }

            if (QuestionGenerator.depressionquestion == true)
            {
                QuizManager.Depressionlevel += 1;
                depressiontext.text = "Depressionlevel = " + QuizManager.Depressionlevel.ToString();
            }

            if (QuestionGenerator.anxietyquestion == true)
            {
                QuizManager.Anxietylevel += 1;
                anxietytext.text = "Anxietylevel = " + QuizManager.Anxietylevel.ToString();
            }

            if (QuestionGenerator.personalquestion == true)
            {
                //do personal code here
            }
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

    //goes to next question
    IEnumerator Nextquestion()
    {
        //sets the bools to false to reset them before question loads
        QuestionGenerator.stressquestion = false;
        QuestionGenerator.depressionquestion = false;
        QuestionGenerator.anxietyquestion = false;

        //wait 0.3 seconds, stoppppp
        yield return new WaitForSeconds(0.3f);

        //checks if the quiz is done or not CHANGE THE NUMBER EQUAL TO HOW MNAY QUESTIONS THERE ARE + 1.
        if(QuestionGenerator.questionnumber == 37)
        {
            Debug.Log("DONE WITH QUIZZZZZZZZZ");
        }

        else
        {
            QuestionGenerator.questionnumber += 1;
            QuestionGenerator.Displaying_Question = false;
            answerAbutton.GetComponent<Button>().enabled = true;
            answerBbutton.GetComponent<Button>().enabled = true;
            answerCbutton.GetComponent<Button>().enabled = true;
        }
    }
}
