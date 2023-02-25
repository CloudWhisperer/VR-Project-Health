using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestionGenerator : MonoBehaviour
{
    public static string Answer_that_increases_score;
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

            //Switch cases wont work here because i need it to keep checking
            //when it switches to the next question so the player can take thier time

            //--start of personal questions--
            if (questionnumber == 1)
            {
                personalquestion = true;
                QuizManager.NewQuestion = "Would you like your world to be Red?";

                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Next Colour";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 2)
            {
                personalquestion = true;
                QuizManager.NewQuestion = "Would you like your world to be Blue?";

                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Next Colour";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 3)
            {
                personalquestion = true;
                QuizManager.NewQuestion = "Would you like your world to be Yellow?";

                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Next Colour";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 4)
            {
                personalquestion = true;
                QuizManager.NewQuestion = "Would you like your world to be Pink?";

                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Next Colour";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 5)
            {
                personalquestion = true;
                QuizManager.NewQuestion = "Would you like your world to be Orange?";

                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Next Colour";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 6)
            {
                personalquestion = true;
                QuizManager.NewQuestion = "Would you like your world to be Green?";

                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Next Colour";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 7)
            {
                personalquestion = true;
                QuizManager.NewQuestion = "Last one for colours, Would you like your world to be Brown?" +
                                          " Picking no or skipping will use the default white colour";

                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Next question";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            //--end of colours--

            if (questionnumber == 8)
            {
                personalquestion = true;
                QuizManager.NewQuestion = "Would you like your world to be Rainy?";

                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Next Weather";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 9)
            {
                personalquestion = true;
                QuizManager.NewQuestion = "Would you like your world to be Sunny?";

                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Next Weather";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 10)
            {
                personalquestion = true;
                QuizManager.NewQuestion = "Would you like your world to be Snowy?";

                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Next Weather";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 11)
            {
                personalquestion = true;
                QuizManager.NewQuestion = "Would you like your world to be Foggy?";

                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Next Weather";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 12)
            {
                personalquestion = true;
                QuizManager.NewQuestion = "Last one for Weather, Would you like your world to be Cloudy?";

                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Next Question";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            //--end of personal questions--

            //--start of stress questions--

            if (questionnumber == 13)
            {
                stressquestion = true;
                QuizManager.NewQuestion = "You are trying to focus on your task in a library," +
                                           " and you can hear someone chewing from somewhere" +
                                           " across the library, how irritated would you be?";

                QuizManager.NewA = "I wouldnt mind";
                QuizManager.NewB = "A little";
                QuizManager.NewC = "Very irritated";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 14)
            {
                stressquestion = true;
                QuizManager.NewQuestion = "You seem to be stuck in a semi long queue, around" +
                                          " 6 people in front of you, And the progress of the" +
                                          " queue seems to be moving slowly, how tempted are" +
                                          " you to leave the queue?";

                QuizManager.NewA = "Its taking too long, i cant be bothered";
                QuizManager.NewB = "I can stay just for a little longer";
                QuizManager.NewC = "I can stay, i have time";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 15)
            {
                stressquestion = true;

                QuizManager.NewQuestion = "someone or something has made you upset," +
                                          " how long would it take you to calm down?";

                QuizManager.NewA = "Not That long";
                QuizManager.NewB = "Just a bit of time";
                QuizManager.NewC = "It takes a while for me to relax";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 16)
            {
                stressquestion = true;

                QuizManager.NewQuestion = "You are trying to study in your room, but" +
                                          " someone keeps texting you on your phone every" +
                                          " few minutes, how annoyed would you be in this situation?";

                QuizManager.NewA = "A little";
                QuizManager.NewB = "Very, Just let me study already...";
                QuizManager.NewC = "I wouldn't mind";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 17)
            {
                stressquestion = true;
                QuizManager.NewQuestion = "Do you think that you overeact to situations a lot?";

                QuizManager.NewA = "Somewhat, i guess";
                QuizManager.NewB = "i think so";
                QuizManager.NewC = "Nope :)";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 18)
            {
                stressquestion = true;
                QuizManager.NewQuestion = "How 'on edge' do you normally feel?";

                QuizManager.NewA = "Not that often";
                QuizManager.NewB = "Sometimes, when it gets really busy";
                QuizManager.NewC = "A lot, its like i can never relax";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 19)
            {
                stressquestion = true;
                QuizManager.NewQuestion = "How often do you receive Headaches or become dizzy?";

                QuizManager.NewA = "Almost Everyday";
                QuizManager.NewB = "Rarely";
                QuizManager.NewC = "Never";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 20)
            {
                stressquestion = true;
                QuizManager.NewQuestion = "Do you often get Chest pains?";

                QuizManager.NewA = "Sometimes";
                QuizManager.NewB = "Almost Everyday";
                QuizManager.NewC = "Nope";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 21)
            {
                stressquestion = true;
                QuizManager.NewQuestion = "Have you ever felt your heart racing faster recently?";

                QuizManager.NewA = "Yes, wierdly";
                QuizManager.NewB = "Rarely";
                QuizManager.NewC = "Not at all";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 22)
            {
                stressquestion = true;
                QuizManager.NewQuestion = "How often do you worry about things in your life?";

                QuizManager.NewA = "All.The.Time";
                QuizManager.NewB = "Sometimes";
                QuizManager.NewC = "Not that much";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            //--end of stress questions--

            //--start of depression questions--

            if (questionnumber == 23)
            {
                depressionquestion = true;
                QuizManager.NewQuestion = "Are you happy with the way things are going in your life right now?";

                QuizManager.NewA = "Very happy";
                QuizManager.NewB = "Could be worse";
                QuizManager.NewC = "Not happy at all";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 24)
            {
                depressionquestion = true;
                QuizManager.NewQuestion = "Would you say that you have the strength to keep going on in life?";

                QuizManager.NewA = "Nope";
                QuizManager.NewB = "Maybe a little bit of strength";
                QuizManager.NewC = "I can keep going";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 25)
            {
                depressionquestion = true;
                QuizManager.NewQuestion = "And how much Determination would you say you have to push yourself" +
                                          " forward and become stronger?";

                QuizManager.NewA = "A little bit";
                QuizManager.NewB = "None at all";
                QuizManager.NewC = "A lot, I am very determined";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 26)
            {
                depressionquestion = true;
                QuizManager.NewQuestion = "Do you blame all bad things that happen in your life on yourself?";

                QuizManager.NewA = "Yes, because it is all my fault";
                QuizManager.NewB = "Only if it actually is my fault";
                QuizManager.NewC = "Sometimes";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 27)
            {
                depressionquestion = true;
                QuizManager.NewQuestion = "How quick are you to get angry at something very small?" +
                                          "(After saying quick so much, the word sounds wierd)";

                QuizManager.NewA = "Not quick at all";
                QuizManager.NewB = "Not that quick";
                QuizManager.NewC = "Very quick";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 28)
            {
                depressionquestion = true;
                QuizManager.NewQuestion = "Have you invested yourself into any hobbies recently?";

                QuizManager.NewA = "A few";
                QuizManager.NewB = "Nope";
                QuizManager.NewC = "Yes, quite a lot";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 29)
            {
                depressionquestion = true;
                QuizManager.NewQuestion = "have you noticed yourself speaking slower or moving slower than usual?";

                QuizManager.NewA = "I am not sure";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Yes";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 30)
            {
                depressionquestion = true;
                QuizManager.NewQuestion = "have you noticed yourself speaking slower or moving slower than usual?";

                QuizManager.NewA = "I am not sure";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Yes";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 31)
            {
                depressionquestion = true;
                QuizManager.NewQuestion = "Is your appetite suddenly very low or very high?";

                QuizManager.NewA = "Yes";
                QuizManager.NewB = "I dont know";
                QuizManager.NewC = "No";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 32)
            {
                depressionquestion = true;
                QuizManager.NewQuestion = "Do you have difficulty trying to sleep?";

                QuizManager.NewA = "No";
                QuizManager.NewB = "Yes";
                QuizManager.NewC = "Kind of";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 33)
            {
                depressionquestion = true;
                QuizManager.NewQuestion = "Do you suddenly not have any energy to do any tasks?";

                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Sometimes";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 34)
            {
                depressionquestion = true;
                QuizManager.NewQuestion = "Have you been avoiding your friends and family" +
                                          " or withholding from social events?";

                QuizManager.NewA = "No, i love talking to people";
                QuizManager.NewB = "Yes, I dont feel like interacting with anyone";
                QuizManager.NewC = "Sometimes, when im not in the mood";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 35)
            {
                depressionquestion = true;
                QuizManager.NewQuestion = "Have you stopped doing the hobbies you used to love?";

                QuizManager.NewA = "Yes, i dont feel like doing it anymore";
                QuizManager.NewB = "Yes, because I physically cant do it anymore";
                QuizManager.NewC = "No";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            //--end of depression questions--

            //--start of anxiety questions--

            if (questionnumber == 36)
            {
                anxietyquestion = true;
                QuizManager.NewQuestion = "Do you struggle with taking a break and just resting?";

                QuizManager.NewA = "Yes, i feel unproductive";
                QuizManager.NewB = "Sometimes, it depends how much work i have";
                QuizManager.NewC = "No, i want more breaks";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 37)
            {
                anxietyquestion = true;
                QuizManager.NewQuestion = "Were you in a state of fear or dread before playing" +
                                          " this game?";

                QuizManager.NewA = "A tiny bit";
                QuizManager.NewB = "Yes";
                QuizManager.NewC = "No";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 38)
            {
                anxietyquestion = true;
                QuizManager.NewQuestion = "Are you always worried about bad things happening any second?";

                QuizManager.NewA = "No";
                QuizManager.NewB = "A little bit";
                QuizManager.NewC = "Yes, always";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 39)
            {
                anxietyquestion = true;
                QuizManager.NewQuestion = "How difficult is it to focus on a task because you are scared" +
                                          " about the result or the future";

                QuizManager.NewA = "Very diffucult";
                QuizManager.NewB = "Slightly difficult";
                QuizManager.NewC = "Not difficult, i can focus";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 40)
            {
                anxietyquestion = true;
                QuizManager.NewQuestion = "Have you been avoiding people and objects," +
                                          " in case they bring in more things to be worried about?";

                QuizManager.NewA = "Sometimes";
                QuizManager.NewB = "Yes, I don't need more things on my plate";
                QuizManager.NewC = "No, I like talking with people";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 41)
            {
                anxietyquestion = true;
                QuizManager.NewQuestion = "Do you take time off work or studying because it" +
                                          "Has become much more difficult and scary?";

                QuizManager.NewA = "Yes, i need a lot of breaks";
                QuizManager.NewB = "A little bit";
                QuizManager.NewC = "No, I can manage";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 42)
            {
                anxietyquestion = true;
                QuizManager.NewQuestion = "How often do you get pins and needles?";

                QuizManager.NewA = "I am not sure";
                QuizManager.NewB = "Quite often";
                QuizManager.NewC = "Not that often";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 43)
            {
                anxietyquestion = true;
                QuizManager.NewQuestion = "Have you noticed yourself with a very dry mouth?";

                QuizManager.NewA = "No, when would that happen?";
                QuizManager.NewB = "Sometimes";
                QuizManager.NewC = "Yes, its very wierd";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 44)
            {
                anxietyquestion = true;
                QuizManager.NewQuestion = "Do you sweat very excessively?";

                QuizManager.NewA = "Nope";
                QuizManager.NewB = "When i do physical exersise";
                QuizManager.NewC = "Yes, for no reason";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 45)
            {
                anxietyquestion = true;
                QuizManager.NewQuestion = "Do you struggle to sleep because you are scared" +
                                          " about something coming the next day or down the line?";

                QuizManager.NewA = "Yes, I can't stop thinking about it";
                QuizManager.NewB = "A little, but I can sleep after a while";
                QuizManager.NewC = "Not at all";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            //--end of anxiety questions--


            //!!!all questions go above this line!!!

            QuizManager.UpdateQuestion = false;

        }
    }

}
