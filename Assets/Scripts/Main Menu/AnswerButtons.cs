using System.Collections;
using UnityEngine;

public class AnswerButtons : MonoBehaviour
{
    private QuestionGenerator Question_generator_script;

    [Header("-Question and answer animators-")]
    [SerializeField]
    private Animator Question_text_animator;
    [SerializeField]
    private Animator Answer_1_animator,
                     Answer_2_animator,
                     Answer_3_animator,
                     Button_animator,
                     Canvas_animator;

    private LevelChangeFade Level_fade_script;

    [Header("-Sound effects-")]
    [SerializeField]
    private AudioSource Button_press_sound_effect;

    [Header("-Answer buttons-")]
    [SerializeField]
    private GameObject Answer_A_button;
    [SerializeField]
    private GameObject Answer_B_button;
    [SerializeField]
    private GameObject Answer_C_button;

    [Header("-World material-")]
    [SerializeField]
    private Material World_material;

    //destroy these at the end
    [Header("-Canvas and physical button gameobjects-")]
    [SerializeField]
    private GameObject Physical_buttons;
    [SerializeField]
    private GameObject Quiz_canvas;

    //values to determine final scorecounter
    private int Highest_value = -1;
    private int Random_number;

    //value to check what colour is being used in the world
    private int World_colour_check = 0;

    [Header("-Weather particle effects-")]
    [SerializeField]
    private ParticleSystem Rain;
    [SerializeField]
    private ParticleSystem Fog,
                           Cloudy,
                           Snow;
    [SerializeField]
    private GameObject Stars;

    [Header("-Skyboxes-")]
    [SerializeField]
    private Material Red_skybox;
    [SerializeField]
    private Material Blue_skybox,
                     Pink_skybox,
                     Yellow_skybox,
                     Orange_skybox,
                     Green_skybox,
                     Brown_skybox,
                     Sun_skybox;

    //particle effect to play when pushed button
    [Header("-Button particle effects-")]
    [SerializeField]
    private ParticleSystem Button_A_particle_effect;
    [SerializeField]
    private ParticleSystem Button_B_particle_effect;
    [SerializeField]
    private ParticleSystem Button_C_particle_effect;

    private void Start()
    {
        Question_generator_script = GameObject.FindGameObjectWithTag("QuestionManager").GetComponent<QuestionGenerator>();
        Level_fade_script = GameObject.FindGameObjectWithTag("Fade").GetComponent<LevelChangeFade>();
        Button_animator.GetComponent<Animator>();
    }

    public void Answer_A_pressed()
    {
        Button_A_particle_effect.Play();
        Button_press_sound_effect.Play();

        if (QuestionGenerator.Answer_that_increases_score == "A")
        {
            if (QuestionGenerator.Is_stress_question == true)
            {
                QuizManager.Stress_level += 1;
            }

            if (QuestionGenerator.Is_depression_question == true)
            {
                QuizManager.Depression_level += 1;
            }

            if (QuestionGenerator.Is_anxiety_question == true)
            {
                QuizManager.Anxiety_level += 1;
            }

            if (QuestionGenerator.Is_personal_question == true)
            {
                switch (QuestionGenerator.Question_number)
                {
                    case 1:
                        Red_selected();
                        break;

                    case 2:
                        Blue_selected();
                        break;

                    case 3:
                        Yellow_selected();
                        break;

                    case 4:
                        Pink_selected();
                        break;

                    case 5:
                        Orange_selected();
                        break;

                    case 6:
                        Green_selected();
                        break;

                    case 7:
                        Brown_selected();
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
                        QuestionGenerator.Question_number = -3;
                        break;
                }
            }
            if (QuestionGenerator.Is_level_select_question == true)
            {
                switch (QuestionGenerator.Question_number)
                {
                    case -2:
                        StartCoroutine(Level_has_been_selected());
                        LevelChangeFade.What_level_number_to_load = 4;
                        Level_fade_script.Fade_to_level();
                        break;

                    case -1:
                        StartCoroutine(Level_has_been_selected());
                        LevelChangeFade.What_level_number_to_load = 3;
                        Level_fade_script.Fade_to_level();
                        break;

                    case 0:
                        StartCoroutine(Level_has_been_selected());
                        LevelChangeFade.What_level_number_to_load = 2;
                        Level_fade_script.Fade_to_level();
                        break;
                }
            }
        }

        else
        {
            Debug.Log("answer is not A");
        }

        StartCoroutine(Go_to_next_question());
    }

    public void Answer_B_pressed()
    {
        Button_B_particle_effect.Play();
        Button_press_sound_effect.Play();

        if (QuestionGenerator.Answer_that_increases_score == "B")
        {
            if (QuestionGenerator.Is_stress_question == true)
            {
                QuizManager.Stress_level += 1;
            }

            if (QuestionGenerator.Is_depression_question == true)
            {
                QuizManager.Depression_level += 1;
            }

            if (QuestionGenerator.Is_anxiety_question == true)
            {
                QuizManager.Anxiety_level += 1;
            }

            if (QuestionGenerator.Is_personal_question == true)
            {
                //do personal code here
                Debug.Log("NO SELECTED");
            }
            if (QuestionGenerator.Is_level_select_question == true)
            {
                //do personal code here
                Debug.Log("NO SELECTED");
            }
        }

        else
        {
            Debug.Log("answer is not B");
        }

        StartCoroutine(Go_to_next_question());
    }

    public void Answer_C_pressed()
    {
        Button_C_particle_effect.Play();
        Button_press_sound_effect.Play();

        if (QuestionGenerator.Answer_that_increases_score == "C")
        {
            if (QuestionGenerator.Is_stress_question == true)
            {
                QuizManager.Stress_level += 1;
            }

            if (QuestionGenerator.Is_depression_question == true)
            {
                QuizManager.Depression_level += 1;
            }

            if (QuestionGenerator.Is_anxiety_question == true)
            {
                QuizManager.Anxiety_level += 1;
            }
        }

        if (QuestionGenerator.Is_personal_question == true)
        {
            switch (QuestionGenerator.Question_number)
            {
                case 1:
                    //did it manually here because of a bug
                    QuestionGenerator.Question_number = 6;
                    StartCoroutine(Go_to_next_question());
                    break;
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    QuestionGenerator.Question_number = 7;
                    break;

                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                    QuestionGenerator.Question_number = 12;
                    break;

                case 13:
                    QuestionGenerator.Question_number = 0;
                    break;
            }
        }

        if (QuestionGenerator.Is_level_select_question == true)
        {
            QuestionGenerator.Question_number = 0;
        }

        else
        {
            Debug.Log("answer is not C");
        }

        StartCoroutine(Go_to_next_question());
    }

    IEnumerator Go_to_next_question()
    {
        //sets the bools to false to reset them before question loads
        QuestionGenerator.Is_stress_question = false;
        QuestionGenerator.Is_depression_question = false;
        QuestionGenerator.Is_anxiety_question = false;
        QuestionGenerator.Is_personal_question = false;
        QuestionGenerator.Is_level_select_question = false;

        Question_text_animator.SetBool("isshow", false);
        Answer_1_animator.SetBool("show", true);
        Answer_2_animator.SetBool("show", true);
        Answer_3_animator.SetBool("show", true);

        //Show_question_text 0.3 seconds, stoppppp
        yield return new WaitForSeconds(0.3f);

        //checks if the quiz is done or not CHANGE THE NUMBER EQUAL TO HOW MANY QUESTIONS THERE ARE + 1.
        if (QuestionGenerator.Question_number > 45)
        {
            Debug.Log("DONE WITH QUIZZZZZZZZZ");
            StartCoroutine(Finish_Quiz());
        }

        else
        {
            QuestionGenerator.Question_number += 1;
            QuestionGenerator.Is_displaying_question = false;
            Answer_A_button.SetActive(true);
            Answer_B_button.SetActive(true);
            Answer_C_button.SetActive(true);
        }

        Question_generator_script.Update_question_number();
    }

    IEnumerator Finish_Quiz()
    {
        //enables the animation for the removing of objects
        Button_animator.enabled = true;
        Canvas_animator.enabled = true;

        //turns off objects to prevent mashing
        Answer_A_button.SetActive(false);
        Answer_B_button.SetActive(false);
        Answer_C_button.SetActive(false);

        //waits for a second or 2 and destroys it to save memory
        yield return new WaitForSeconds(1.1f);
        Destroy(Physical_buttons);
        Destroy(Quiz_canvas);

        //for loop that checks which value is the highest. does it multiple times just in case.
        for (int i = 0; i < 3; i++)
        {
            if (QuizManager.Stress_level > Highest_value)
            {
                Highest_value = QuizManager.Stress_level;
            }
            if (QuizManager.Depression_level > Highest_value)
            {
                Highest_value = QuizManager.Depression_level;
            }
            if (QuizManager.Anxiety_level > Highest_value)
            {
                Highest_value = QuizManager.Anxiety_level;
            }

            Debug.Log(Highest_value);
        }

        //loads the level based on the results (after the 3 checks)
        if (Highest_value == QuizManager.Stress_level)
        {
            Debug.Log("stress win");
            LevelChangeFade.What_level_number_to_load = 3;
            Level_fade_script.Fade_to_level();
        }
        if (Highest_value == QuizManager.Depression_level)
        {
            Debug.Log("depression win");
            LevelChangeFade.What_level_number_to_load = 4;
            Level_fade_script.Fade_to_level();
        }
        if (Highest_value == QuizManager.Anxiety_level)
        {
            Debug.Log("anxiety win");
            LevelChangeFade.What_level_number_to_load = 2;
            Level_fade_script.Fade_to_level();
        }

        //this check is in case multiple values are the same
        if (
           //checks if they are all the same
           Highest_value == QuizManager.Stress_level &&
           Highest_value == QuizManager.Depression_level &&
           Highest_value == QuizManager.Anxiety_level ||

           //checks if stress and depression is the same
           Highest_value == QuizManager.Stress_level &&
           Highest_value == QuizManager.Depression_level ||

           //checks if stress and anxiety is the same
           Highest_value == QuizManager.Stress_level &&
           Highest_value == QuizManager.Anxiety_level ||

           //checks if depression and anxiety is the same
           Highest_value == QuizManager.Depression_level &&
           Highest_value == QuizManager.Anxiety_level)
        {
            Debug.Log("they were either the same or all 0. (which is kinda the same thing)");
            Random_level_select();
        }
    }

    void Random_level_select()
    {
        Debug.Log("even,picking random");
        Random_number = Random.Range(0, 3);
        switch (Random_number)
        {
            case 0:
                Debug.Log("number1");
                LevelChangeFade.What_level_number_to_load = 3;
                Level_fade_script.Fade_to_level();
                break;

            case 1:
                Debug.Log("number2");
                LevelChangeFade.What_level_number_to_load = 2;
                Level_fade_script.Fade_to_level();
                break;

            case 2:
                Debug.Log("number3");
                LevelChangeFade.What_level_number_to_load = 1;
                Level_fade_script.Fade_to_level();
                break;
        }
    }

    void Red_selected()
    {
        Debug.Log("RED selected");
        World_material.SetColor("_BaseColor", Color.red);
        RenderSettings.skybox = Red_skybox;
        World_colour_check = 1;
    }

    void Blue_selected()
    {
        Debug.Log("BLUE selected");
        World_material.SetColor("_BaseColor", Color.blue);
        RenderSettings.skybox = Blue_skybox;
        World_colour_check = 2;
    }

    void Yellow_selected()
    {
        Debug.Log("YELLOW selected");
        World_material.SetColor("_BaseColor", Color.yellow);
        RenderSettings.skybox = Yellow_skybox;
        World_colour_check = 3;
    }

    void Pink_selected()
    {
        Debug.Log("PINK selected");
        Color Pink = new Color32(227, 61, 148, 1);
        World_material.SetColor("_BaseColor", Pink);
        RenderSettings.skybox = Pink_skybox;
        World_colour_check = 4;
    }

    void Orange_selected()
    {
        Debug.Log("ORANGE selected");
        Color Orange = new Color32(211, 84, 0, 1);
        World_material.SetColor("_BaseColor", Orange);
        RenderSettings.skybox = Orange_skybox;
        World_colour_check = 5;
    }

    void Green_selected()
    {
        Debug.Log("GREEN selected");
        World_material.SetColor("_BaseColor", Color.green);
        RenderSettings.skybox = Green_skybox;
        World_colour_check = 6;
    }

    void Brown_selected()
    {
        Debug.Log("BROWN selected");
        Color Brown = new Color32(139, 69, 19, 1);
        World_material.SetColor("_BaseColor", Brown);
        RenderSettings.skybox = Brown_skybox;
        World_colour_check = 7;
    }

    void Check_colour_of_Skybox()
    {
        if (RenderSettings.skybox == Sun_skybox)
        {
            Debug.Log("sunison");
            switch (World_colour_check)
            {
                case 1:
                    RenderSettings.skybox = Red_skybox;
                    break;

                case 2:
                    RenderSettings.skybox = Blue_skybox;
                    break;

                case 3:
                    RenderSettings.skybox = Yellow_skybox;
                    break;

                case 4:
                    RenderSettings.skybox = Pink_skybox;
                    break;

                case 5:
                    RenderSettings.skybox = Orange_skybox;
                    break;

                case 6:
                    RenderSettings.skybox = Green_skybox;
                    break;

                case 7:
                    RenderSettings.skybox = Brown_skybox;
                    break;

                default:
                    RenderSettings.skybox = Pink_skybox;
                    break;

            }
        }
    }

    void Set_weather_to_Rain()
    {
        if (Snow.isPlaying ||
            Fog.isPlaying)
        {
            Snow.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            Fog.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        if (!Stars.activeInHierarchy)
        {
            Stars.SetActive(true);
        }

        Check_colour_of_Skybox();

        Debug.Log("RAIN selected");
        Rain.Play();
        Cloudy.Play();
    }

    void Set_weather_to_Sunny()
    {
        //if (QuestionGenerator.Unlock_weather_1 == true)
        //{
            if (Rain.isPlaying ||
                Snow.isPlaying ||
                Fog.isPlaying ||
                Cloudy.isPlaying)
            {
                Rain.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                Snow.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                Fog.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                Cloudy.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            }
            Debug.Log("SUNNY selected");
            Stars.SetActive(false);
            RenderSettings.skybox = Sun_skybox;
        //}
        //Debug.Log(QuestionGenerator.Unlock_weather_1);
    }

    void Set_weather_to_Snow()
    {
        //if (QuestionGenerator.Unlock_weather_2 == true)
        //{
            if (Rain.isPlaying ||
            Fog.isPlaying ||
            Cloudy.isPlaying)
            {
                Rain.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                Fog.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                Cloudy.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            }

            Snow.Play();
            Debug.Log("SNOWY selected");
        //}
        //Debug.Log(QuestionGenerator.Unlock_weather_2);
    }

    void Set_weather_to_Foggy()
    {
        //if (QuestionGenerator.Unlock_weather_3 == true)
        //{
            if (Rain.isPlaying ||
            Snow.isPlaying)
            {
                Rain.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                Snow.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            }

            if (!Stars.activeInHierarchy)
            {
                Stars.SetActive(true);
            }

            Check_colour_of_Skybox();
            Debug.Log("FOGGY selected");
            Fog.Play();
            Cloudy.Play();
        //}
        //Debug.Log(QuestionGenerator.Unlock_weather_3);
    }

    void Set_weather_to_Cloudy()
    {
        if (Rain.isPlaying ||
            Snow.isPlaying ||
            Fog.isPlaying)
        {
            Rain.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            Snow.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            Fog.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        if (!Stars.activeInHierarchy)
        {
            Stars.SetActive(true);
        }

        Check_colour_of_Skybox();
        Debug.Log("CLOUDY selected");
        Cloudy.Play();
    }

    IEnumerator Level_has_been_selected()
    {
        //enables the animation for the removing of objects
        Button_animator.enabled = true;
        Canvas_animator.enabled = true;

        //waits for a second or 2 and destroys it to save memory
        yield return new WaitForSeconds(1.1f);
        Destroy(Physical_buttons);
        Destroy(Quiz_canvas);
    }
}
