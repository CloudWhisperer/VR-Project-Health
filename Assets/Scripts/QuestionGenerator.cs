using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionGenerator : MonoBehaviour
{
    public Animator questionanim;
    public Animator answer1;
    public Animator answer2;
    public Animator answer3;

    public static string Answer_that_increases_score;
    public static bool Displaying_Question = false;

    //bools to check which type of question user is on
    public static bool stressquestion = false;
    public static bool depressionquestion = false;
    public static bool anxietyquestion = false;


    public static bool personalquestion = false;

    public static bool levelselectquestion = true;

    //int to check what question number use is on
    public static int questionnumber;

    public Image CBTImage, Coingameimage, anxietylevelimage;
    public Animator CBTimageanim, Coinimageanim, Anxietyimageanim;

    public GameObject balls, cubes, pingpong,pingpongball, whiteboard,marker, paperplane;

    public TextMeshProUGUI unlocktext;
    public Animator unlocktextanim;

    public void Allenable()
    {
        balls.SetActive(true);
        cubes.SetActive(true);
        pingpong.SetActive(true);
        pingpongball.SetActive(true);
        whiteboard.SetActive(true);
        marker.SetActive(true);
        paperplane.SetActive(true);
    }

    private void Start()
    {
        //gotta start at 1 right?
        questionnumber = 1;
    }

    IEnumerator Questionanim()
    {
        questionanim.SetBool("isshow", true);
        yield return new WaitForSeconds(0.4f);
        questionanim.SetBool("isshow", false);
    }

    IEnumerator Answeranim()
    {
        answer1.SetBool("show", true);
        answer2.SetBool("show", true);
        answer3.SetBool("show", true);

        yield return new WaitForSeconds(0.4f);

        if(answer1 != null)
        {
            answer1.SetBool("show", false);
        }

        yield return new WaitForSeconds(0.4f);

        if(answer2 != null)
        {
            answer2.SetBool("show", false);
        }

        yield return new WaitForSeconds(0.4f);

        if(answer3 != null)
        {
            answer3.SetBool("show", false);
        }

    }

    IEnumerator Unlockcube()
    {
        cubes.SetActive(true);
        unlocktext.text = "You have unlocked the cubes, try to stack them!";
        unlocktextanim.SetBool("zoom", true);
        yield return new WaitForSeconds(4f);
        unlocktextanim.SetBool("zoom", false);

    }

    IEnumerator Unlockballs()
    {
        balls.SetActive(true);
        unlocktext.text = "You have unlocked the balls, try rolling them around!";
        unlocktextanim.SetBool("zoom", true);
        yield return new WaitForSeconds(4f);
        unlocktextanim.SetBool("zoom", false);

    }

    IEnumerator UnlockPingpong()
    {
        pingpong.SetActive(true);
        pingpongball.SetActive(true);
        unlocktext.text = "You have unlocked the Ping Pong paddle and ball, try to get a good hit!";
        unlocktextanim.SetBool("zoom", true);
        yield return new WaitForSeconds(4f);
        unlocktextanim.SetBool("zoom", false);

    }

    IEnumerator UnlockWhiteboard()
    {
        whiteboard.SetActive(true);
        WhiteboardUnlock.isUnlocked = true;
        marker.SetActive(true);
        unlocktext.text = "You have unlocked the Whiteboard and marker, try to draw a star!";
        unlocktextanim.SetBool("zoom", true);
        yield return new WaitForSeconds(4f);
        unlocktextanim.SetBool("zoom", false);

    }

    IEnumerator UnlockPaperplane()
    {
        paperplane.SetActive(true);
        unlocktext.text = "You have unlocked the Paper Airplanes, try to throw them far!";
        unlocktextanim.SetBool("zoom", true);
        yield return new WaitForSeconds(4f);
        unlocktextanim.SetBool("zoom", false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Displaying_Question == false)
        {
            Displaying_Question = true;

            //Switch cases wont work here because i need it to keep checking
            //when it switches to the next question so the player can take thier time

            //--start of hidden questions--
            if (questionnumber == -2)
            {
                levelselectquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like to go to the CBT level?";

                CBTImage.enabled = true;
                Coingameimage.enabled = false;
                anxietylevelimage.enabled = false;

                CBTimageanim.SetBool("isshow", true);
                Coinimageanim.SetBool("isshow", false);
                Anxietyimageanim.SetBool("isshow", false);

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Next Level";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a levelselect question");

                Allenable();
            }

            if (questionnumber == -1)
            {
                levelselectquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like to go to the coin game level?";

                CBTImage.enabled = false;
                Coingameimage.enabled = true;
                anxietylevelimage.enabled = false;

                CBTimageanim.SetBool("isshow", false);
                Coinimageanim.SetBool("isshow", true);
                Anxietyimageanim.SetBool("isshow", false);

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Next Level";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a levelselect question");
            }

            if (questionnumber == 0)
            {
                levelselectquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like to go to the 'nOt fOuNd' level?";

                CBTImage.enabled = false;
                Coingameimage.enabled = false;
                anxietylevelimage.enabled = true;

                CBTimageanim.SetBool("isshow", false);
                Coinimageanim.SetBool("isshow", false);
                Anxietyimageanim.SetBool("isshow", true);

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Next Level";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a levelselect question");
            }

            //--end of hidden questions--

            //--start of personal questions--
            if (questionnumber == 1)
            {
                CBTImage.enabled = false;
                Coingameimage.enabled = false;
                anxietylevelimage.enabled = false;

                personalquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like your world to be Red?";

                StartCoroutine(Answeranim());
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

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like your world to be Blue?";

                StartCoroutine(Answeranim());
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

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like your world to be Yellow?";

                StartCoroutine(Answeranim());
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

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like your world to be Pink?";

                StartCoroutine(Answeranim());
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

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like your world to be Orange?";

                StartCoroutine(Answeranim());
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

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like your world to be Green?";

                StartCoroutine(Answeranim());
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

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Last one for colours, Would you like your world to be Brown?" +
                                          " Picking no or skipping will use the default white colour";

                StartCoroutine(Answeranim());
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

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like your world to be Rainy?";

                StartCoroutine(Answeranim());
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

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like your world to be Sunny?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Next Weather";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);

                StartCoroutine(Unlockcube());
            }

            if (questionnumber == 10)
            {
                personalquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like your world to be Snowy?";

                StartCoroutine(Answeranim());
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

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like your world to be Foggy?";

                StartCoroutine(Answeranim());
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

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Last one for Weather, Would you like your world to be Cloudy?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Next Question";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 13)
            {
                personalquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like to skip this personality quiz?" +
                                          " Recommended if you have done this before";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Lets start!";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            //--end of personal questions--

            //--start of stress questions--

            if (questionnumber == 14)
            {
                stressquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "You are trying to focus on your task in a library," +
                                           " and you can hear someone chewing from somewhere" +
                                           " across the library, how irritated would you be?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "I wouldnt mind";
                QuizManager.NewB = "A little";
                QuizManager.NewC = "Very irritated";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 15)
            {
                stressquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "You seem to be stuck in a semi long queue, around" +
                                          " 6 people in front of you, And the progress of the" +
                                          " queue seems to be moving slowly, how tempted are" +
                                          " you to leave the queue?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Its taking too long, i cant be bothered";
                QuizManager.NewB = "I can stay just for a little longer";
                QuizManager.NewC = "I can stay, i have time";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 16)
            {
                stressquestion = true;


                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "someone or something has made you upset," +
                                          " how long would it take you to calm down?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Not That long";
                QuizManager.NewB = "Just a bit of time";
                QuizManager.NewC = "It takes a while for me to relax";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 17)
            {
                stressquestion = true;


                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "You are trying to study in your room, but" +
                                          " someone keeps texting you on your phone every" +
                                          " few minutes, how annoyed would you be in this situation?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "A little";
                QuizManager.NewB = "Very, Just let me study already...";
                QuizManager.NewC = "I wouldn't mind";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 18)
            {
                stressquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Do you think that you overeact to situations a lot?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Somewhat, i guess";
                QuizManager.NewB = "i think so";
                QuizManager.NewC = "Nope :)";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);

                StartCoroutine(Unlockballs());
            }

            if (questionnumber == 19)
            {
                stressquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "How 'on edge' do you normally feel?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Not that often";
                QuizManager.NewB = "Sometimes, when it gets really busy";
                QuizManager.NewC = "A lot, its like i can never relax";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 20)
            {
                stressquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "How often do you receive Headaches or become dizzy?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Almost Everyday";
                QuizManager.NewB = "Rarely";
                QuizManager.NewC = "Never";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 21)
            {
                stressquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Do you often get Chest pains?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Sometimes";
                QuizManager.NewB = "Almost Everyday";
                QuizManager.NewC = "Nope";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 22)
            {
                stressquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Have you ever felt your heart racing faster recently?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes, wierdly";
                QuizManager.NewB = "Rarely";
                QuizManager.NewC = "Not at all";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 23)
            {
                stressquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "How often do you worry about things in your life?";

                StartCoroutine(Answeranim());
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

            if (questionnumber == 24)
            {
                depressionquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Are you happy with the way things are going in your life right now?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Very happy";
                QuizManager.NewB = "Could be worse";
                QuizManager.NewC = "Not happy at all";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 25)
            {
                depressionquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you say that you have the strength to keep going on in life?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Nope";
                QuizManager.NewB = "Maybe a little bit of strength";
                QuizManager.NewC = "I can keep going";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 26)
            {
                depressionquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "And how much Determination would you say you have to push yourself" +
                                          " forward and become stronger?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "A little bit";
                QuizManager.NewB = "None at all";
                QuizManager.NewC = "A lot, I am very determined";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 27)
            {
                depressionquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Do you blame all bad things that happen in your life on yourself?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes, because it is all my fault";
                QuizManager.NewB = "Only if it actually is my fault";
                QuizManager.NewC = "Sometimes";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);

                StartCoroutine(UnlockPingpong());
            }

            if (questionnumber == 28)
            {
                depressionquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "How quick are you to get angry at something very small?" +
                                          "(After saying quick so much, the word sounds wierd)";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Not quick at all";
                QuizManager.NewB = "Not that quick";
                QuizManager.NewC = "Very quick";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 29)
            {
                depressionquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Have you invested yourself into any hobbies recently?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "A few";
                QuizManager.NewB = "Nope";
                QuizManager.NewC = "Yes, quite a lot";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 30)
            {
                depressionquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "have you noticed yourself speaking slower or moving slower than usual?";

                StartCoroutine(Answeranim());
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

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "have you noticed yourself speaking slower or moving slower than usual?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "I am not sure";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Yes";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 32)
            {
                depressionquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Is your appetite suddenly very low or very high?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "I dont know";
                QuizManager.NewC = "No";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 33)
            {
                depressionquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Do you have difficulty trying to sleep?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "No";
                QuizManager.NewB = "Yes";
                QuizManager.NewC = "Kind of";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 34)
            {
                depressionquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Do you suddenly not have any energy to do any tasks?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Sometimes";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 35)
            {
                depressionquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Have you been avoiding your friends and family" +
                                          " or withholding from social events?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "No, i love talking to people";
                QuizManager.NewB = "Yes, I dont feel like interacting with anyone";
                QuizManager.NewC = "Sometimes, when im not in the mood";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 36)
            {
                depressionquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Have you stopped doing the hobbies you used to love?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes, i dont feel like doing it anymore";
                QuizManager.NewB = "Yes, because I physically cant do it anymore";
                QuizManager.NewC = "No";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);

                StartCoroutine(UnlockWhiteboard());
            }

            //--end of depression questions--

            //--start of anxiety questions--

            if (questionnumber == 37)
            {
                anxietyquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Do you struggle with taking a break and just resting?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes, i feel unproductive";
                QuizManager.NewB = "Sometimes, it depends how much work i have";
                QuizManager.NewC = "No, i want more breaks";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 38)
            {
                anxietyquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Were you in a state of fear or dread before playing" +
                                          " this game?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "A tiny bit";
                QuizManager.NewB = "Yes";
                QuizManager.NewC = "No";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 39)
            {
                anxietyquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Are you always worried about bad things happening any second?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "No";
                QuizManager.NewB = "A little bit";
                QuizManager.NewC = "Yes, always";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 40)
            {
                anxietyquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "How difficult is it to focus on a task because you are scared" +
                                          " about the result or the future";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Very diffucult";
                QuizManager.NewB = "Slightly difficult";
                QuizManager.NewC = "Not difficult, i can focus";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 41)
            {
                anxietyquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Have you been avoiding people and objects," +
                                          " in case they bring in more things to be worried about?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Sometimes";
                QuizManager.NewB = "Yes, I don't need more things on my plate";
                QuizManager.NewC = "No, I like talking with people";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 42)
            {
                anxietyquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Do you take time off work or studying because it" +
                                          "Has become much more difficult and scary?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes, i need a lot of breaks";
                QuizManager.NewB = "A little bit";
                QuizManager.NewC = "No, I can manage";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);

                StartCoroutine(UnlockPaperplane());
            }

            if (questionnumber == 43)
            {
                anxietyquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "How often do you get pins and needles?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "I am not sure";
                QuizManager.NewB = "Quite often";
                QuizManager.NewC = "Not that often";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 44)
            {
                anxietyquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Have you noticed yourself with a very dry mouth?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "No, when would that happen?";
                QuizManager.NewB = "Sometimes";
                QuizManager.NewC = "Yes, its very wierd";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 45)
            {
                anxietyquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Do you sweat very excessively?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Nope";
                QuizManager.NewB = "When i do physical exersise";
                QuizManager.NewC = "Yes, for no reason";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 46)
            {
                anxietyquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Do you struggle to sleep because you are scared" +
                                          " about something coming the next day or down the line?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes, I can't stop thinking about it";
                QuizManager.NewB = "A little, but I can sleep after a while";
                QuizManager.NewC = "Not at all";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 47)
            {

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Thank you for your honesty, the game will adjust" +
                                          " upon the answers you have selected, Press any button to continue.";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "";
                QuizManager.NewB = "";
                QuizManager.NewC = "";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
            }

            //--end of anxiety questions--

            //!!!all questions go above this line!!!

            QuizManager.UpdateQuestion = false;

        }
    }

}
