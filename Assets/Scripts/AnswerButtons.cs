using System.Collections;
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

    //values to determine final scorecounter
    private int highestvalue;
    private int randomnumber;

    //value to check whatcolour is being used
    private int colourcheck = 0;

    //weather gameobjects
    public GameObject rainweather;
    public GameObject fogweather;
    public GameObject cloudyweather;
    public GameObject snowweather;
    public GameObject stars;

    //skyboxes
    public Material redspace;
    public Material bluespace;
    public Material pinkspace;
    public Material yellowspace;
    public Material orangespace;
    public Material greenspace;
    public Material brownspace;
    public Material sunskybox;

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
                        Redselect();
                        break;

                    case 2:
                        Blueselect();
                        break;

                    case 3:
                        Yellowselect();
                        break;

                    case 4:
                        Pinkselect();
                        break;

                    case 5:
                        Orangeselect();
                        break;

                    case 6:
                        Greenselect();
                        break;

                    case 7:
                        Brownselect();
                        break;

                    case 8:
                        Set_weather_to_Rain();
                        break;

                    case 9:
                        Set_weather_to_Sunny();
                        break;

                    case 10:
                        Set_weather_to_Snow();
                        break;

                    case 11:
                        Set_weather_to_Foggy();
                        break;

                    case 12:
                        Set_weather_to_Cloudy();
                        break;

                    case 13:
                        QuestionGenerator.questionnumber = -3;
                        break;
                }
            }
            if (QuestionGenerator.levelselectquestion == true)
            {
                switch(QuestionGenerator.questionnumber)
                {
                    case -2:
                        SceneManager.LoadScene(1);
                        break;

                    case -1:
                        SceneManager.LoadScene(2);
                        break;

                    case 0:
                        SceneManager.LoadScene(3);
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

        //answerAbutton.GetComponent<Button>().enabled = false;
        //answerBbutton.GetComponent<Button>().enabled = false;
        //answerCbutton.GetComponent<Button>().enabled = false;
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
            if (QuestionGenerator.levelselectquestion == true)
            {
                //do personal code here
                Debug.Log("NO SELECTED");
            }
        }

        else
        {
            Debug.Log("answer is not B");
        }

        //answerAbutton.GetComponent<Button>().enabled = false;
        //answerBbutton.GetComponent<Button>().enabled = false;
        //answerCbutton.GetComponent<Button>().enabled = false;
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
            if (QuestionGenerator.levelselectquestion == true)
            {
                //do personal code here
                Debug.Log("NEXTTTTTT SELECTED");
            }
        }

        else
        {
            Debug.Log("answer is not C");
        }

        //answerAbutton.GetComponent<Button>().enabled = false;
        //answerBbutton.GetComponent<Button>().enabled = false;
        //answerCbutton.GetComponent<Button>().enabled = false;
        StartCoroutine(Nextquestion());
    }

    //goes to next question
    IEnumerator Nextquestion()
    {
        //sets the bools to false to reset them before question loads
        QuestionGenerator.stressquestion = false;
        QuestionGenerator.depressionquestion = false;
        QuestionGenerator.anxietyquestion = false;
        QuestionGenerator.personalquestion = false;
        QuestionGenerator.levelselectquestion = false;

        //wait 0.3 seconds, stoppppp
        yield return new WaitForSeconds(0.3f);

        //checks if the quiz is done or not CHANGE THE NUMBER EQUAL TO HOW MNAY QUESTIONS THERE ARE + 1.
        if (QuestionGenerator.questionnumber >= 47)
        {
            Debug.Log("DONE WITH QUIZZZZZZZZZ");
            StartCoroutine("FinishQuiz");

            highestvalue = Mathf.Max(QuizManager.Anxietylevel, QuizManager.Depressionlevel, QuizManager.Stresslevel);
            Debug.Log(highestvalue);
        }

        else
        {
            QuestionGenerator.questionnumber += 1;
            QuestionGenerator.Displaying_Question = false;
            //answerAbutton.GetComponent<Button>().enabled = true;
            //answerBbutton.GetComponent<Button>().enabled = true;
            //answerCbutton.GetComponent<Button>().enabled = true;
        }
    }

    IEnumerator FinishQuiz()
    {
        //enables the animation for the removing of objects
        ButtonAnim.buttonanim.enabled = true;
        CanvasAnim.canvasanim.enabled = true;

        //turns off objects to prevent mashing
        //answerAbutton.GetComponent<Button>().enabled = false;
        //answerBbutton.GetComponent<Button>().enabled = false;
        //answerCbutton.GetComponent<Button>().enabled = false;

        //waits for a second or 2 and destroys it to save memory
        yield return new WaitForSeconds(1.1f);
        Destroy(destroy_this_button);
        Destroy(destroy_this_canvas);

        if (highestvalue == QuizManager.Stresslevel)
        {
            Debug.Log("stresswon");
            SceneManager.LoadScene("Coin_Game");
        }
        if (highestvalue == QuizManager.Anxietylevel)
        {
            Debug.Log("anxietywon");
            SceneManager.LoadScene("Coin_Game");
        }
        if (highestvalue == QuizManager.Depressionlevel)
        {
            Debug.Log("depressionwon");
            SceneManager.LoadScene("Ball_Rolling_Game");
        }
        if (highestvalue == (QuizManager.Depressionlevel & QuizManager.Anxietylevel & QuizManager.Stresslevel))
        {
            RandomSceneSelect();
        }
        else
        {
            RandomSceneSelect();
        }

    }

    void RandomSceneSelect()
    {
        Debug.Log("even,picking random");
        randomnumber = Random.Range(1, 2);
        switch (randomnumber)
        {
            case 1:
                Debug.Log("1");
                SceneManager.LoadScene("Coin_Game");
                break;

            case 2:
                Debug.Log("2");
                SceneManager.LoadScene("Ball_Rolling_Game");
                break;
        }
    }

    void Redselect()
    {
        Debug.Log("RED selected");
        worldmat.SetColor("_BaseColor", Color.red);
        RenderSettings.skybox = redspace;
        colourcheck = 1;
    }

    void Blueselect()
    {
        Debug.Log("BLUE selected");
        worldmat.SetColor("_BaseColor", Color.blue);
        RenderSettings.skybox = bluespace;
        colourcheck = 2;
    }

    void Yellowselect()
    {
        Debug.Log("YELLOW selected");
        worldmat.SetColor("_BaseColor", Color.yellow);
        RenderSettings.skybox = yellowspace;
        colourcheck = 3;
    }

    void Pinkselect()
    {
        Debug.Log("PINK selected");
        Color Pink = new Color32(227, 61, 148, 1);
        worldmat.SetColor("_BaseColor", Pink);
        RenderSettings.skybox = pinkspace;
        colourcheck = 4;
    }

    void Orangeselect()
    {
        Debug.Log("ORANGE selected");
        Color Orange = new Color32(211, 84, 0, 1);
        worldmat.SetColor("_BaseColor", Orange);
        RenderSettings.skybox = orangespace;
        colourcheck = 5;
    }

    void Greenselect()
    {
        Debug.Log("GREEN selected");
        worldmat.SetColor("_BaseColor", Color.green);
        RenderSettings.skybox = greenspace;
        colourcheck = 6;
    }

    void Brownselect()
    {
        Debug.Log("BROWN selected");
        Color Brown = new Color32(139, 69, 19, 1);
        worldmat.SetColor("_BaseColor", Brown);
        RenderSettings.skybox = brownspace;
        colourcheck = 7;
    }

    void Check_colour_of_Skybox()
    {
        if (RenderSettings.skybox == sunskybox)
        {
            switch (colourcheck)
            {
                case 1:
                    RenderSettings.skybox = redspace;
                    break;

                case 2:
                    RenderSettings.skybox = bluespace;
                    break;

                case 3:
                    RenderSettings.skybox = yellowspace;
                    break;

                case 4:
                    RenderSettings.skybox = pinkspace;
                    break;

                case 5:
                    RenderSettings.skybox = orangespace;
                    break;

                case 6:
                    RenderSettings.skybox = greenspace;
                    break;

                case 7:
                    RenderSettings.skybox = brownspace;
                    break;

            }
        }
    }

    void Set_weather_to_Rain()
    {
        if (snowweather.activeInHierarchy == true ||
            fogweather.activeInHierarchy == true ||
            cloudyweather.activeInHierarchy == true)
        {
            snowweather.SetActive(false);
            fogweather.SetActive(false);
            cloudyweather.SetActive(false);
        }

        if (!stars.activeInHierarchy)
        {
            stars.SetActive(true);
        }

        Check_colour_of_Skybox();

        Debug.Log("RAIN selected");
        rainweather.SetActive(true);
    }

    void Set_weather_to_Sunny()
    {
        if (rainweather.activeInHierarchy == true ||
            snowweather.activeInHierarchy == true ||
            fogweather.activeInHierarchy == true ||
            cloudyweather.activeInHierarchy == true)
        {
            rainweather.SetActive(false);
            snowweather.SetActive(false);
            fogweather.SetActive(false);
            cloudyweather.SetActive(false);
        }
        Debug.Log("SUNNY selected");
        stars.SetActive(false);
        RenderSettings.skybox = sunskybox;
    }

    void Set_weather_to_Snow()
    {
        if (rainweather.activeInHierarchy == true ||
            fogweather.activeInHierarchy == true ||
            cloudyweather.activeInHierarchy == true)
        {
            rainweather.SetActive(false);
            fogweather.SetActive(false);
            cloudyweather.SetActive(false);
        }

        if (!stars.activeInHierarchy)
        {
            stars.SetActive(true);
        }

        Check_colour_of_Skybox();
        snowweather.SetActive(true);
        Debug.Log("SNOWY selected");
    }

    void Set_weather_to_Foggy()
    {
        if (rainweather.activeInHierarchy == true ||
            snowweather.activeInHierarchy == true ||
            cloudyweather.activeInHierarchy == true)
        {
            rainweather.SetActive(false);
            snowweather.SetActive(false);
            cloudyweather.SetActive(false);
        }

        if (!stars.activeInHierarchy)
        {
            stars.SetActive(true);
        }

        Check_colour_of_Skybox();
        Debug.Log("FOGGY selected");
        fogweather.SetActive(true);
    }

    void Set_weather_to_Cloudy()
    {
        if (rainweather.activeInHierarchy == true ||
            snowweather.activeInHierarchy == true ||
            fogweather.activeInHierarchy == true)
        {
            rainweather.SetActive(false);
            snowweather.SetActive(false);
            fogweather.SetActive(false);
        }

        if (!stars.activeInHierarchy)
        {
            stars.SetActive(true);
        }

        Check_colour_of_Skybox();
        Debug.Log("CLOUDY selected");
        cloudyweather.SetActive(true);
    }


}
