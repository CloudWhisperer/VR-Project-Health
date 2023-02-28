using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    //material colour to change
    public Material worldmat;

    //destroy these
    public GameObject destroy_this_button;
    public GameObject destroy_this_canvas;

    private int highestvalue;
    private int randomnumber;

    public void AnswerA()
    {
        //if the user picks a...
        if (QuestionGenerator.Answer_that_increases_score == "A")
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
                switch (QuestionGenerator.questionnumber)
                {
                    case 1:
                        Debug.Log("RED selected");
                        worldmat.SetColor("_BaseColor", Color.red);
                        break;

                    case 2:
                        Debug.Log("BLUE selected");
                        worldmat.SetColor("_BaseColor", Color.blue);
                        break;

                    case 3:
                        Debug.Log("YELLOW selected");
                        worldmat.SetColor("_BaseColor", Color.yellow);
                        break;

                    case 4:
                        Debug.Log("PINK selected");
                        Color Pink = new Color32(227, 61, 148, 1);
                        worldmat.SetColor("_BaseColor", Pink);
                        break;

                    case 5:
                        Debug.Log("ORANGE selected");
                        Color Orange = new Color32(211, 84, 0, 1);
                        worldmat.SetColor("_BaseColor", Orange);
                        break;

                    case 6:
                        Debug.Log("GREEN selected");
                        worldmat.SetColor("_BaseColor", Color.green);
                        break;

                    case 7:
                        Debug.Log("BROWN selected");
                        Color Brown = new Color32(139, 69, 19, 1);
                        worldmat.SetColor("_BaseColor", Brown);
                        break;

                    case 8:
                        Debug.Log("RAIN selected");
                        break;

                    case 9:
                        Debug.Log("SUNNY selected");
                        break;

                    case 10:
                        Debug.Log("SNOWY selected");
                        break;

                    case 11:
                        Debug.Log("FOGGY selected");
                        break;

                    case 12:
                        Debug.Log("CLOUDY selected");
                        break;

                    case 13:
                        Debug.Log("skipped quiz");
                        SceneManager.LoadScene("Depressionworld2");
                        break;
                }
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
                Debug.Log("NO SELECTED");
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
                Debug.Log("NEXTTTTTT SELECTED");
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
        if (QuestionGenerator.questionnumber >= 47)
        {
            Debug.Log("DONE WITH QUIZZZZZZZZZ");
            StartCoroutine("FinishQuiz");


            highestvalue = Mathf.Max(QuizManager.Anxietylevel, QuizManager.Depressionlevel, QuizManager.Stresslevel);
            Debug.Log(highestvalue);

            if(highestvalue == QuizManager.Stresslevel)
            {
                Debug.Log("stresswon");
            }
            if (highestvalue == QuizManager.Anxietylevel)
            {
                Debug.Log("anxietywon");
            }
            if (highestvalue == QuizManager.Depressionlevel)
            {
                Debug.Log("depressionwon");
                SceneManager.LoadScene("Depressionworld");
            }
            else
            {
                Debug.Log("even,picking random");
                randomnumber = Random.Range(1, 4);
                switch(randomnumber)
                {
                    case 1:
                        Debug.Log("1");
                        break;

                    case 2:
                        Debug.Log("2");
                        break;

                    case 3:
                        Debug.Log("3");
                        break;
                }
            }



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

    IEnumerator FinishQuiz()
    {
        //enables the animation for the removing of objects
        ButtonAnim.buttonanim.enabled = true;
        CanvasAnim.canvasanim.enabled = true;

        //turns off objects to prevent mashing
        answerAbutton.GetComponent<Button>().enabled = false;
        answerBbutton.GetComponent<Button>().enabled = false;
        answerCbutton.GetComponent<Button>().enabled = false;

        //waits for a second or 2 and destroys it to save memory
        yield return new WaitForSeconds(1.1f);
        Destroy(destroy_this_button);
        Destroy(destroy_this_canvas);


    }

}
