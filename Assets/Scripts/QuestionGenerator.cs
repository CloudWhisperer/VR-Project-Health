using System.Collections;
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

    public Image yellowworldimage, redworldimage, brownworldimage,
                 blueworldimage, pinkworldimage, greenworldimage, orangeworldimage;

    public Animator yellowworldimageanim, redworldimageanim, brownworldimageanim,
             blueworldimageanim, pinkworldimageanim, greenworldimageanim, orangeworldimageanim;

    public Image cloudimage, fogimage, rainimage, snowimage, sunimage;

    public Animator cloudimageanim, fogimageanim, rainimageanim, snowimageanim, sunimageanim;

    public GameObject balls, cubes, pingpong, pingpongball, whiteboard, marker, paperplane;

    public TextMeshProUGUI unlocktext;
    public Animator unlocktextanim;

    public AudioSource unlocksound;

    public GameObject grabtutorial;

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

    private void Awake()
    {
        //written here again to counter a bug when loading the level
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

        if (answer1 != null)
        {
            answer1.SetBool("show", false);
        }

        yield return new WaitForSeconds(0.4f);

        if (answer2 != null)
        {
            answer2.SetBool("show", false);
        }

        yield return new WaitForSeconds(0.4f);

        if (answer3 != null)
        {
            answer3.SetBool("show", false);
        }

    }

    IEnumerator Unlockcube()
    {
        grabtutorial.SetActive(true);
        unlocksound.Play();
        cubes.SetActive(true);
        unlocktext.text = "You have unlocked the cubes, try to stack them!";
        unlocktextanim.SetBool("zoom", true);
        yield return new WaitForSeconds(4f);
        unlocktextanim.SetBool("zoom", false);

    }

    IEnumerator Unlockballs()
    {
        unlocksound.Play();
        balls.SetActive(true);
        unlocktext.text = "You have unlocked the balls, try rolling them around!";
        unlocktextanim.SetBool("zoom", true);
        yield return new WaitForSeconds(4f);
        unlocktextanim.SetBool("zoom", false);

    }

    IEnumerator UnlockPingpong()
    {
        unlocksound.Play();
        pingpong.SetActive(true);
        pingpongball.SetActive(true);
        unlocktext.text = "You have unlocked the Ping Pong paddle and ball, try to get a good hit!";
        unlocktextanim.SetBool("zoom", true);
        yield return new WaitForSeconds(4f);
        unlocktextanim.SetBool("zoom", false);

    }

    IEnumerator UnlockWhiteboard()
    {
        unlocksound.Play();
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
        unlocksound.Play();
        paperplane.SetActive(true);
        unlocktext.text = "You have unlocked the Paper Airplanes, try to throw them far!";
        unlocktextanim.SetBool("zoom", true);
        yield return new WaitForSeconds(4f);
        unlocktextanim.SetBool("zoom", false);

    }

    public void Turnoffallimages()
    {
        CBTimageanim.SetBool("isshow", false);
        Coinimageanim.SetBool("isshow", false);
        Anxietyimageanim.SetBool("isshow", false);

        yellowworldimageanim.SetBool("fadein", false);
        redworldimageanim.SetBool("fadein", false);
        brownworldimageanim.SetBool("fadein", false);
        blueworldimageanim.SetBool("fadein", false);
        pinkworldimageanim.SetBool("fadein", false);
        greenworldimageanim.SetBool("fadein", false);
        orangeworldimageanim.SetBool("fadein", false);

        cloudimageanim.SetBool("fadein", false);
        fogimageanim.SetBool("fadein", false);
        rainimageanim.SetBool("fadein", false);
        snowimageanim.SetBool("fadein", false);
        sunimageanim.SetBool("fadein", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Displaying_Question == false)
        {
            Displaying_Question = true;

            //Switch cases wont work here because i need it to keep checking
            //when it switches to the next question so the player doesnt have to answer immediatly
            //i could just use a switch and check once the player presses a button...
            //check unity profile if it affects performance too much, if it does then change it to switch

            //--start of hidden questions--
            if (questionnumber == -2)
            {
                levelselectquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like to go into the CBT level?";

                Turnoffallimages();
                CBTImage.enabled = true;
                CBTimageanim.SetBool("isshow", true);

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "Next level";
                QuizManager.NewC = "Return to colour selection";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a levelselect question");

                Allenable();
            }

            if (questionnumber == -1)
            {
                levelselectquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like to go into the coin mini-game level?";

                Turnoffallimages();
                Coingameimage.enabled = true;
                Coinimageanim.SetBool("isshow", true);

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "Next level";
                QuizManager.NewC = "Return to colour selection";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a levelselect question");
            }

            if (questionnumber == 0)
            {
                levelselectquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like to go into the applied relaxation level?";

                Turnoffallimages();
                anxietylevelimage.enabled = true;
                Anxietyimageanim.SetBool("isshow", true);

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No (Will return to colour selection)";
                QuizManager.NewC = "Return to colour selection";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a levelselect question");
            }

            //--end of hidden questions--

            //--start of personal questions--
            if (questionnumber == 1)
            {
                personalquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like your world to be Red?";

                Turnoffallimages();
                redworldimage.enabled = true;
                redworldimageanim.SetBool("fadein", true);

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "Next colour";
                QuizManager.NewC = "Skip colour selection";
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

                Turnoffallimages();
                blueworldimage.enabled = true;
                blueworldimageanim.SetBool("fadein", true);

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "Next colour";
                QuizManager.NewC = "Skip colour selection";
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

                Turnoffallimages();
                yellowworldimage.enabled = true;
                yellowworldimageanim.SetBool("fadein", true);

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "Next colour";
                QuizManager.NewC = "Skip colour selection";
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

                Turnoffallimages();
                pinkworldimage.enabled = true;
                pinkworldimageanim.SetBool("fadein", true);

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "Next colour";
                QuizManager.NewC = "Skip colour selection";
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

                Turnoffallimages();
                orangeworldimage.enabled = true;
                orangeworldimageanim.SetBool("fadein", true);

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "Next colour";
                QuizManager.NewC = "Skip colour selection";
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

                Turnoffallimages();
                greenworldimage.enabled = true;
                greenworldimageanim.SetBool("fadein", true);

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "Next colour";
                QuizManager.NewC = "Skip colour selection";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 7)
            {
                personalquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like your world to be Brown?" +
                                          " If you have not chosen a colour, it will stay as white.";

                Turnoffallimages();
                brownworldimage.enabled = true;
                brownworldimageanim.SetBool("fadein", true);

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "Go to weather selection";
                QuizManager.NewC = "Skip colour selection";
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
                QuizManager.NewQuestion = "Would you like the weather to be Rainy?";

                Turnoffallimages();
                rainimage.enabled = true;
                rainimageanim.SetBool("fadein", true);

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "Next weather";
                QuizManager.NewC = "Skip weather selection";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);

                StartCoroutine(Unlockcube());
            }

            if (questionnumber == 9)
            {
                personalquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like the weather to be Sunny?";

                Turnoffallimages();
                sunimage.enabled = true;
                sunimageanim.SetBool("fadein", true);

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "Next weather";
                QuizManager.NewC = "Skip weather selection";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 10)
            {
                personalquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like the weather to be Snowy?";

                Turnoffallimages();
                snowimage.enabled = true;
                snowimageanim.SetBool("fadein", true);

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "Next weather";
                QuizManager.NewC = "Skip weather selection";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 11)
            {
                personalquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like the weather to be Foggy?";

                Turnoffallimages();
                fogimage.enabled = true;
                fogimageanim.SetBool("fadein", true);

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "Next weather";
                QuizManager.NewC = "Skip weather selection";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 12)
            {
                personalquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like the weather to be Cloudy?";

                Turnoffallimages();
                cloudimage.enabled = true;
                cloudimageanim.SetBool("fadein", true);

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "No";
                QuizManager.NewC = "Skip weather selection";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 13)
            {
                personalquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Would you like to skip the personality quiz and choose a level?" +
                                          " Not recommended for first time players";

                Turnoffallimages();

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes (Will go to level select)";
                QuizManager.NewB = "No (Start quiz)";
                QuizManager.NewC = "Customize colour and weather again";
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
                QuizManager.NewQuestion = "You are trying to focus on your work in the library," +
                                           " but you can hear someone chewing loudly" +
                                           " across the library, how irritated would you be?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Not irritated";
                QuizManager.NewB = "Slightly irritated";
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
                QuizManager.NewQuestion = "You are stuck in a queue, there are around" +
                                          " 6 people in front of you and the progress of the" +
                                          " queue seems to be moving slowly, how tempted are" +
                                          " you to leave?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "It's taking too long, i'm leaving";
                QuizManager.NewB = "I can stay for a little bit longer";
                QuizManager.NewC = "I can wait, I have time";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 16)
            {
                stressquestion = true;


                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Someone or something has made you upset," +
                                          " how long would it take for you to calm down?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Not That long";
                QuizManager.NewB = "Just a bit of time";
                QuizManager.NewC = "It takes a while for me to calm down";
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
                                          " someone keeps texting you every" +
                                          " few minutes, how annoyed would you be in this situation?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "A little";
                QuizManager.NewB = "Very annoyed, Just let me study already...";
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
                QuizManager.NewQuestion = "Do you think you overeact to situations a lot?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Somewhat";
                QuizManager.NewB = "I think so";
                QuizManager.NewC = "Nope";
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
                QuizManager.NewA = "Not as much";
                QuizManager.NewB = "Slightly, when it gets really busy";
                QuizManager.NewC = "A lot, I feel like I can never relax";
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
                QuizManager.NewQuestion = "Do you often get chest pains?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Almost Everyday";
                QuizManager.NewB = "Rarely";
                QuizManager.NewC = "Never";
                Answer_that_increases_score = "A";

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
                QuizManager.NewA = "Yes";
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
                QuizManager.NewQuestion = "How often do you worry about things?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "All the time";
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
                QuizManager.NewQuestion = "Are you happy with the way things are going in your life?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "I'm very happy";
                QuizManager.NewB = "It could be worse";
                QuizManager.NewC = "I'm not happy at all";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 25)
            {
                depressionquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Do you think you have the strength to keep going in your life?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "I don't think so";
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
                QuizManager.NewQuestion = "And how much determination would you say you have to push yourself" +
                                          " forward and become stronger?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "A little bit";
                QuizManager.NewB = "None at all";
                QuizManager.NewC = "A lot, I feel very determined";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 27)
            {
                depressionquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Do you blame the bad things that happen in your life on yourself?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes, because it's all my fault";
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
                QuizManager.NewQuestion = "How quick are you to get angry at something?";

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
                QuizManager.NewQuestion = "Have you noticed yourself speaking slower or moving slower than usual?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "I'm not sure";
                QuizManager.NewB = "No";
                QuizManager.NewC = "I think so";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 31)
            {
                depressionquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Is your appetite suddenly very low or very high?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "I can't tell";
                QuizManager.NewC = "No";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 32)
            {
                depressionquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Do you have difficulty trying to sleep?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "No";
                QuizManager.NewB = "Yes";
                QuizManager.NewC = "Slightly";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 33)
            {
                depressionquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Do you feel like you don't have any energy to do tasks?";

                StartCoroutine(Answeranim());
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

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Have you recently been avoiding your friends and family," +
                                          " or withholding from social events?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "No, I like to spend time with people";
                QuizManager.NewB = "Yes, I don't feel like interacting with anyone";
                QuizManager.NewC = "Sometimes, when i'm not in the mood";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 35)
            {
                depressionquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Have you suddenly stopped doing the hobbies you used to love?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes, I dont feel like doing them anymore";
                QuizManager.NewB = "Yes, because I physically can't do it anymore";
                QuizManager.NewC = "No";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);

                StartCoroutine(UnlockWhiteboard());
            }

            //--end of depression questions--

            //--start of anxiety questions--

            if (questionnumber == 36)
            {
                anxietyquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Do you struggle with taking a break or relaxing?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes, I feel unproductive";
                QuizManager.NewB = "Sometimes, it depends how much work I have";
                QuizManager.NewC = "No, I want more breaks";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 37)
            {
                anxietyquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Were you in a state of fear or dread today?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "A little bit";
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

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Are you always worried about bad things happening?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "No";
                QuizManager.NewB = "Sometimes";
                QuizManager.NewC = "Yes, always";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 39)
            {
                anxietyquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "How difficult is it to focus on a task because you are scared" +
                                          " about the result or the future?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Very diffucult";
                QuizManager.NewB = "Slightly difficult";
                QuizManager.NewC = "Not difficult";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 40)
            {
                anxietyquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Have you been avoiding people and objects," +
                                          " in case they bring in more things to be worried about?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Sometimes";
                QuizManager.NewB = "Yes, I don't need more things on my plate";
                QuizManager.NewC = "Nope";
                Answer_that_increases_score = "B";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 41)
            {
                anxietyquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Do you take time off work or studying because it" +
                                          " has become much more difficult and scary?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes";
                QuizManager.NewB = "A little bit";
                QuizManager.NewC = "No, I can manage";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);

                StartCoroutine(UnlockPaperplane());
            }

            if (questionnumber == 42)
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

            if (questionnumber == 43)
            {
                anxietyquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Have you noticed yourself with a very dry mouth?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "No";
                QuizManager.NewB = "Sometimes";
                QuizManager.NewC = "Yes";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 44)
            {
                anxietyquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Do you sweat very excessively?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Nope";
                QuizManager.NewB = "Yes, when I do physical exersise";
                QuizManager.NewC = "Yes, for no reason";
                Answer_that_increases_score = "C";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 45)
            {
                anxietyquestion = true;

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Do you struggle with sleeping because you are scared" +
                                          " about something coming the next day or down the line?";

                StartCoroutine(Answeranim());
                QuizManager.NewA = "Yes, I can't stop thinking about it";
                QuizManager.NewB = "A little, but I can still sleep";
                QuizManager.NewC = "Not at all";
                Answer_that_increases_score = "A";

                Debug.Log(questionnumber);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (questionnumber == 46)
            {

                StartCoroutine(Questionanim());
                QuizManager.NewQuestion = "Thank you for your honesty, the game will adjust" +
                                          " based on your answers, press any button to continue";

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
