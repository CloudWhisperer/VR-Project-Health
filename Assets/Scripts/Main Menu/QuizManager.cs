using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    //These 4 are for the question and button texts
    public GameObject ScreenQuestion;
    public GameObject AnswerA;
    public GameObject AnswerB;
    public GameObject AnswerC;

    //track scores of the player with these
    public static int Anxietylevel = 0;
    public static int Depressionlevel = 0;
    public static int Stresslevel = 0;

    //the strings for the new question and answer buttons
    public static string NewQuestion;
    public static string NewA;
    public static string NewB;
    public static string NewC;

    //a bool to check of the question needs an update or not
    public static bool UpdateQuestion = false;

    // Update is called once per frame
    void Update()
    {
        //this triggers after the question is answered in the question generator
        if (UpdateQuestion == false)
        {
            UpdateQuestion = true;
            StartCoroutine(TextonScreen());
        }
    }

    //a function that replaces the text with the new question and answer
    IEnumerator TextonScreen()
    {
        yield return new WaitForSeconds(0.1f);
        ScreenQuestion.GetComponent<TextMeshProUGUI>().text = NewQuestion;
        AnswerA.GetComponent<TextMeshProUGUI>().text = NewA;
        AnswerB.GetComponent<TextMeshProUGUI>().text = NewB;
        AnswerC.GetComponent<TextMeshProUGUI>().text = NewC;

    }
}
