using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public GameObject ScreenQuestion;
    public GameObject AnswerA;
    public GameObject AnswerB;
    public GameObject AnswerC;

    public static int Anxietylevel = 0;
    public static int Depressionlevel = 0;
    public static int Stresslevel = 0;

    public static string NewQuestion;
    public static string NewA;
    public static string NewB;
    public static string NewC;

    public static bool UpdateQuestion = false;

    // Update is called once per frame
    void Update()
    {
        if (UpdateQuestion == false)
        {
            UpdateQuestion = true;
            StartCoroutine(TextonScreen());
        }
    }

    IEnumerator TextonScreen()
    {
        yield return new WaitForSeconds(0.1f);
        ScreenQuestion.GetComponent<TextMeshProUGUI>().text = NewQuestion;
        AnswerA.GetComponent<TextMeshProUGUI>().text = NewA;
        AnswerB.GetComponent<TextMeshProUGUI>().text = NewB;
        AnswerC.GetComponent<TextMeshProUGUI>().text = NewC;
    }
}
