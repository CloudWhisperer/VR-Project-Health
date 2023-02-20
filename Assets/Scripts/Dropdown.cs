using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dropdown : MonoBehaviour
{
    public TextMeshProUGUI outputtext;
    private QuizManager Quizmanagerscript;

    public void Inputdata(int val)
    {
        if(val == 0)
        {
            outputtext.text = "0";
            Quizmanagerscript.Anxietylevel += 1;
            Debug.Log(Quizmanagerscript.Anxietylevel);
        }
        if (val == 1)
        {
            outputtext.text = "1";
            Quizmanagerscript.Depressionlevel += 1;
            Debug.Log(Quizmanagerscript.Depressionlevel);
        }
        if (val == 2)
        {
            outputtext.text = "2";
            Quizmanagerscript.Stresslevel += 1;
            Debug.Log (Quizmanagerscript.Stresslevel);
        }
    }

}
