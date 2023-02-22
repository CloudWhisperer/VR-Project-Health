using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionGenerator : MonoBehaviour
{
    public static string Answer_Increase_Stress_score;
    public static bool Displaying_Question = false;

    //bools to check which type of question user is on
    public static bool stressquestion = false;
    public static bool depressionquestion = false;
    public static bool anxietyquestion = false;
    public static bool personalquestion = false;

    //int to check what question number use is on
    public static int questionnumber;

    private void Start()
    {
        //gotta start at 1 right?
        questionnumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Displaying_Question == false)
        {
            Displaying_Question = true;
            //questionnumber = Random.Range(1, 8);

            if (questionnumber == 1)
            {
                personalquestion = true;
                QuizManager.NewQuestion = "Which colour is your favourite?";

                QuizManager.NewA = "1";
                QuizManager.NewB = "2";
                QuizManager.NewC = "3";
                Answer_Increase_Stress_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_Increase_Stress_score);
            }

            if (questionnumber == 2)
            {
                personalquestion = true;
                QuizManager.NewQuestion = "Right or left handed?";

                QuizManager.NewA = "Right";
                QuizManager.NewB = "Left";
                QuizManager.NewC = "Both";
                Answer_Increase_Stress_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_Increase_Stress_score);
            }

            if (questionnumber == 3)
            {
                personalquestion = true;
                QuizManager.NewQuestion = "What is your favourite weather?";

                QuizManager.NewA = "rain";
                QuizManager.NewB = "fog";
                QuizManager.NewC = "sun";
                Answer_Increase_Stress_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_Increase_Stress_score);
            }

            if (questionnumber == 4)
            {
                stressquestion = true;
                QuizManager.NewQuestion = "You are trying to focus on your task in a library," +
                                           " and you can hear someone chewing from somewhere" +
                                           " across the library, how irritated would you be?";

                QuizManager.NewA = "I wouldnt mind";
                QuizManager.NewB = "A little";
                QuizManager.NewC = "Very irritated";
                Answer_Increase_Stress_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_Increase_Stress_score);
            }

            if (questionnumber == 5)
            {
                stressquestion = true;
                QuizManager.NewQuestion = "You seem to be stuck in a semi long queue, around" +
                                          " 6 people in front of you, And the progress of the" +
                                          " queue seems to be moving slowly, how tempted are" +
                                          " you to leave the queue?";

                QuizManager.NewA = "Its taking too long, i cant be bothered";
                QuizManager.NewB = "I can stay just for a little longer";
                QuizManager.NewC = "I can stay, i have time";
                Answer_Increase_Stress_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_Increase_Stress_score);
            }

            if (questionnumber == 6)
            {
                stressquestion = true;

                QuizManager.NewQuestion = "someone or something has made you upset," +
                                          " how long would it take you to calm down?";

                QuizManager.NewA = "Not That long";
                QuizManager.NewB = "Just a bit of time";
                QuizManager.NewC = "It takes a while for me to relax";
                Answer_Increase_Stress_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_Increase_Stress_score);
            }

            if (questionnumber == 7)
            {
                stressquestion = true;

                QuizManager.NewQuestion = "You are trying to study in your room, but" +
                                          " someone keeps texting you on your phone every" +
                                          " few minutes, how annoyed would you be in this situation?";

                QuizManager.NewA = "A little";
                QuizManager.NewB = "Very, Just let me study already...";
                QuizManager.NewC = "I wouldn't mind";
                Answer_Increase_Stress_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_Increase_Stress_score);
            }

            if (questionnumber == 8)
            {
                stressquestion = true;
                QuizManager.NewQuestion = "Do you think that you overeact to situations a lot?";

                QuizManager.NewA = "Somewhat, i guess";
                QuizManager.NewB = "i think so";
                QuizManager.NewC = "Nope :)";
                Answer_Increase_Stress_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_Increase_Stress_score);
            }

            if (questionnumber == 9)
            {
                stressquestion = true;
                QuizManager.NewQuestion = "How 'on edge' do you normally feel?";

                QuizManager.NewA = "Not that often";
                QuizManager.NewB = "Sometimes, when it gets really busy";
                QuizManager.NewC = "A lot, its like i can never relax";
                Answer_Increase_Stress_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_Increase_Stress_score);
            }

            if (questionnumber == 10)
            {
                stressquestion = true;
                QuizManager.NewQuestion = "How often do you receive Headaches?";

                QuizManager.NewA = "Almost Everyday";
                QuizManager.NewB = "Rarely";
                QuizManager.NewC = "Never";
                Answer_Increase_Stress_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_Increase_Stress_score);
            }

            if (questionnumber == 11)
            {
                stressquestion = true;
                QuizManager.NewQuestion = "Do you get Chest pains?";

                QuizManager.NewA = "Sometimes";
                QuizManager.NewB = "Almost Everyday";
                QuizManager.NewC = "Nope";
                Answer_Increase_Stress_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_Increase_Stress_score);
            }

            //all questions above this line

            QuizManager.UpdateQuestion = false;

        }
    }

}
