using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionGenerator : MonoBehaviour
{
    public static string Answer_Increase_Stress_score;
    public static bool displayedquestion = false;


    // Update is called once per frame
    void Update()
    {
        if(displayedquestion == false)
        {
            displayedquestion = true;
            QuizManager.NewQuestion = "Do you get annoyed easily?";
            QuizManager.NewA = "Yes";
            QuizManager.NewB = "A little";
            QuizManager.NewC = "No";
            Answer_Increase_Stress_score = "A";
        }
    }
}
