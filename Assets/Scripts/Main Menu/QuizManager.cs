using System.Collections;
using TMPro;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    [Header("-Question text & answer text-")]
    [SerializeField]
    private GameObject Question_text;
    [SerializeField]
    private GameObject Answer_A_text,
                       Answer_B_text,
                       Answer_C_text;

    //track scores of the player with these
    public static int Anxiety_level = 0;
    public static int Depression_level = 0;
    public static int Stress_level = 0;

    //the strings for the new question and answer buttons
    public static string New_question_text;
    public static string New_answer_A;
    public static string New_answer_B;
    public static string New_answer_C;

    public static bool Update_Question = false;

    void Update()
    {
        //this triggers after the question is answered in the question generator
        if (Update_Question == false)
        {
            Update_Question = true;
            StartCoroutine(Show_text_on_screen());
        }
    }

    //replaces the text with the new question and answer
    IEnumerator Show_text_on_screen()
    {
        yield return new WaitForSeconds(0.1f);
        Question_text.GetComponent<TextMeshProUGUI>().text = New_question_text;
        Answer_A_text.GetComponent<TextMeshProUGUI>().text = New_answer_A;
        Answer_B_text.GetComponent<TextMeshProUGUI>().text = New_answer_B;
        Answer_C_text.GetComponent<TextMeshProUGUI>().text = New_answer_C;
    }
}
