using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionGenerator : MonoBehaviour
{
    [Header("-Question and answer text animators-")]
    [SerializeField]
    private Animator Question_text_animator;
    [SerializeField]
    private Animator Answer_A_text_animator,
                     Answer_B_text_animator,
                     Answer_C_text_animator;

    public static string Answer_that_increases_score;
    public static bool Is_displaying_question = false;

    //bools to check which type of question user is on
    public static bool Is_stress_question = false;
    public static bool Is_depression_question = false;
    public static bool Is_anxiety_question = false;
    public static bool Is_personal_question = false;
    public static bool Is_level_select_question = true;

    //int to check what question number use is on
    public static int Question_number;

    [Header("-Level select images-")]
    [SerializeField]
    private Image CBT_level_image;
    [SerializeField]
    private Image Coin_game_level_image;
    [SerializeField]
    private Image Anxiety_level_image;

    [Header("-Level select image animators-")]
    [SerializeField]
    private Animator CBT_level_image_animator;
    [SerializeField]
    private Animator Coin_game_level_image_animator;
    [SerializeField]
    private Animator Anxiety_level_image_animator;

    [Header("-Coloured world images-")]
    [SerializeField]
    private Image Yellow_world_image;
    [SerializeField]
    private Image Red_world_image,
                  Brown_world_image,
                  Blue_world_image,
                  Pink_world_image,
                  Green_world_image,
                  Orange_world_image;

    [Header("-Coloured world image animators-")]
    [SerializeField]
    private Animator Yellow_world_image_animator;
    [SerializeField]
    private Animator Red_world_image_animator,
                     Brown_world_image_animator,
                     Blue_world_image_animator,
                     Pink_world_image_animator,
                     Green_world_image_animator,
                     Orange_world_image_animator;

    [Header("-World weather images-")]
    [SerializeField]
    private Image Cloud_weather_image;
    [SerializeField]
    private Image Fog_weather_image,
                  Rain_weather_image,
                  Snow_weather_image,
                  Sun_weather_image;

    [Header("-World weather image animators-")]
    [SerializeField]
    private Animator Cloud_weather_image_animator;
    [SerializeField]
    private Animator Fog_weather_image_animator,
                     Rain_weather_image_animator,
                     Snow_weather_image_animator,
                     Sun_weather_image_animator;

    [Header("-Vignette for images-")]
    [SerializeField]
    private Image Vignette_for_level_select;
    [SerializeField]
    private Image Vignette_for_world_colours_and_weather_images;

    [Header("-Vignette image animators-")]
    [SerializeField]
    private Animator Vignette_for_level_select_animator;
    [SerializeField]
    private Animator Vignette_for_world_colours_and_weather_images_animator;

    [Header("-Objects on the table-")]
    [SerializeField]
    private GameObject Balls;
    [SerializeField]
    private GameObject Cubes,
                       Ping_pong_paddle,
                       Ping_pong_ball,
                       Whiteboard,
                       Whiteboard_marker,
                       Paper_plane;

    [Header("Unlock text, animator, and sound effect")]
    [SerializeField]
    private TextMeshProUGUI Unlock_item_text;
    [SerializeField]
    private Animator Unlock_item_text_animator;
    [SerializeField]
    private AudioSource Unlock_item_sound;

    [Header("Tutorials")]
    [SerializeField]
    private GameObject Grabbing_objects_tutorial;
    [SerializeField]
    private Animator Button_pushing_tutorial;

    public void Enable_all_items()
    {
        Balls.SetActive(true);
        Cubes.SetActive(true);
        Ping_pong_paddle.SetActive(true);
        Ping_pong_ball.SetActive(true);
        Whiteboard.SetActive(true);
        Whiteboard_marker.SetActive(true);
        Paper_plane.SetActive(true);
    }

    private void Start()
    {
        Question_number = 1;
        Update_question_number();
    }

    private void Awake()
    {
        //written here again to counter a bug when loading the level
        Question_number = 1;
    }

    IEnumerator Show_question_text()
    {
        yield return new WaitForSeconds(0.2f);
        Question_text_animator.SetBool("isshow", true);
    }

    IEnumerator Fade_out_answer_texts()
    {
        yield return new WaitForSeconds(0.3f);

        if (Answer_A_text_animator != null)
        {
            Answer_A_text_animator.SetBool("show", false);
        }

        yield return new WaitForSeconds(0.3f);

        if (Answer_B_text_animator != null)
        {
            Answer_B_text_animator.SetBool("show", false);
        }

        yield return new WaitForSeconds(0.3f);

        if (Answer_C_text_animator != null)
        {
            Answer_C_text_animator.SetBool("show", false);
        }

    }

    IEnumerator Unlock_cubes()
    {
        Grabbing_objects_tutorial.SetActive(true);
        Unlock_item_sound.Play();
        Cubes.SetActive(true);
        Unlock_item_text.text = "You have unlocked the Cubes, try to stack them!";
        Unlock_item_text_animator.SetBool("zoom", true);
        yield return new WaitForSeconds(4f);
        Unlock_item_text_animator.SetBool("zoom", false);

    }

    IEnumerator Unlock_balls()
    {
        Unlock_item_sound.Play();
        Balls.SetActive(true);
        Unlock_item_text.text = "You have unlocked the Balls, try rolling them around!";
        Unlock_item_text_animator.SetBool("zoom", true);
        yield return new WaitForSeconds(4f);
        Unlock_item_text_animator.SetBool("zoom", false);

    }

    IEnumerator Unlock_ping_pong_paddle()
    {
        Unlock_item_sound.Play();
        Ping_pong_paddle.SetActive(true);
        Ping_pong_ball.SetActive(true);
        Unlock_item_text.text = "You have unlocked the Ping Pong paddle and ball, try to get a good hit!";
        Unlock_item_text_animator.SetBool("zoom", true);
        yield return new WaitForSeconds(4f);
        Unlock_item_text_animator.SetBool("zoom", false);

    }

    IEnumerator Unlock_whiteboard()
    {
        Unlock_item_sound.Play();
        Whiteboard.SetActive(true);
        Whiteboard_marker.SetActive(true);
        Unlock_item_text.text = "You have unlocked the Whiteboard and Whiteboard_marker, try to draw a star!";
        Unlock_item_text_animator.SetBool("zoom", true);
        yield return new WaitForSeconds(4f);
        Unlock_item_text_animator.SetBool("zoom", false);

    }

    IEnumerator Unlock_paper_plane()
    {
        Unlock_item_sound.Play();
        Paper_plane.SetActive(true);
        Unlock_item_text.text = "You have unlocked the Paper Airplanes, try to throw them far!";
        Unlock_item_text_animator.SetBool("zoom", true);
        yield return new WaitForSeconds(4f);
        Unlock_item_text_animator.SetBool("zoom", false);

    }

    public void Turn_off_all_images()
    {
        //level images
        CBT_level_image_animator.SetBool("isshow", false);
        Coin_game_level_image_animator.SetBool("isshow", false);
        Anxiety_level_image_animator.SetBool("isshow", false);

        //world colour images
        Yellow_world_image_animator.SetBool("fadein", false);
        Red_world_image_animator.SetBool("fadein", false);
        Brown_world_image_animator.SetBool("fadein", false);
        Blue_world_image_animator.SetBool("fadein", false);
        Pink_world_image_animator.SetBool("fadein", false);
        Green_world_image_animator.SetBool("fadein", false);
        Orange_world_image_animator.SetBool("fadein", false);

        //world weather images
        Cloud_weather_image_animator.SetBool("fadein", false);
        Fog_weather_image_animator.SetBool("fadein", false);
        Rain_weather_image_animator.SetBool("fadein", false);
        Snow_weather_image_animator.SetBool("fadein", false);
        Sun_weather_image_animator.SetBool("fadein", false);

        //image vignettes
        Vignette_for_level_select_animator.SetBool("isshow", false);
        Vignette_for_world_colours_and_weather_images_animator.SetBool("fadein", false);
    }

    public void Update_question_number()
    {
        if (Is_displaying_question == false)
        {
            Is_displaying_question = true;

            //--start of hidden questions--
            if (Question_number == -2)
            {
                Is_level_select_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Would you like to go into the CBT level?";

                Turn_off_all_images();
                CBT_level_image.enabled = true;
                CBT_level_image_animator.SetBool("isshow", true);
                Vignette_for_level_select.enabled = true;
                Vignette_for_level_select_animator.SetBool("isshow", true);

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes";
                QuizManager.New_answer_B = "Next level";
                QuizManager.New_answer_C = "Return to colour selection";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a levelselect question");

                Enable_all_items();
            }

            if (Question_number == -1)
            {
                Is_level_select_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Would you like to go into the coin mini-game level?";

                Turn_off_all_images();
                Coin_game_level_image.enabled = true;
                Coin_game_level_image_animator.SetBool("isshow", true);
                Vignette_for_level_select_animator.SetBool("isshow", true);

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes";
                QuizManager.New_answer_B = "Next level";
                QuizManager.New_answer_C = "Return to colour selection";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a levelselect question");
            }

            if (Question_number == 0)
            {
                Is_level_select_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Would you like to go into the applied relaxation level?";

                Turn_off_all_images();
                Anxiety_level_image.enabled = true;
                Anxiety_level_image_animator.SetBool("isshow", true);
                Vignette_for_level_select_animator.SetBool("isshow", true);

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes";
                QuizManager.New_answer_B = "No (Will return to colour selection)";
                QuizManager.New_answer_C = "Return to colour selection";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a levelselect question");
            }

            //--end of hidden questions--

            //--start of personal questions--
            if (Question_number == 1)
            {
                Is_personal_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Would you like your world to be Red?";

                Turn_off_all_images();
                Red_world_image.enabled = true;
                Red_world_image_animator.SetBool("fadein", true);
                Vignette_for_world_colours_and_weather_images.enabled = true;
                Vignette_for_world_colours_and_weather_images_animator.SetBool("fadein", true);

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes";
                QuizManager.New_answer_B = "Next colour";
                QuizManager.New_answer_C = "Skip colour selection";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 2)
            {
                Is_personal_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Would you like your world to be Blue?";

                Turn_off_all_images();
                Blue_world_image.enabled = true;
                Blue_world_image_animator.SetBool("fadein", true);
                Vignette_for_world_colours_and_weather_images_animator.SetBool("fadein", true);

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes";
                QuizManager.New_answer_B = "Next colour";
                QuizManager.New_answer_C = "Skip colour selection";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 3)
            {
                Is_personal_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Would you like your world to be Yellow?";

                Turn_off_all_images();
                Yellow_world_image.enabled = true;
                Yellow_world_image_animator.SetBool("fadein", true);
                Vignette_for_world_colours_and_weather_images_animator.SetBool("fadein", true);

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes";
                QuizManager.New_answer_B = "Next colour";
                QuizManager.New_answer_C = "Skip colour selection";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 4)
            {
                Is_personal_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Would you like your world to be Pink?";

                Turn_off_all_images();
                Pink_world_image.enabled = true;
                Pink_world_image_animator.SetBool("fadein", true);
                Vignette_for_world_colours_and_weather_images_animator.SetBool("fadein", true);

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes";
                QuizManager.New_answer_B = "Next colour";
                QuizManager.New_answer_C = "Skip colour selection";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 5)
            {
                Is_personal_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Would you like your world to be Orange?";

                Turn_off_all_images();
                Orange_world_image.enabled = true;
                Orange_world_image_animator.SetBool("fadein", true);
                Vignette_for_world_colours_and_weather_images_animator.SetBool("fadein", true);

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes";
                QuizManager.New_answer_B = "Next colour";
                QuizManager.New_answer_C = "Skip colour selection";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 6)
            {
                Is_personal_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Would you like your world to be Green?";

                Turn_off_all_images();
                Green_world_image.enabled = true;
                Green_world_image_animator.SetBool("fadein", true);
                Vignette_for_world_colours_and_weather_images_animator.SetBool("fadein", true);

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes";
                QuizManager.New_answer_B = "Next colour";
                QuizManager.New_answer_C = "Skip colour selection";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 7)
            {
                Is_personal_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Would you like your world to be Brown?" +
                                          " If you have not chosen a colour, it will stay as white.";

                Turn_off_all_images();
                Brown_world_image.enabled = true;
                Brown_world_image_animator.SetBool("fadein", true);
                Vignette_for_world_colours_and_weather_images_animator.SetBool("fadein", true);

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes";
                QuizManager.New_answer_B = "Go to weather selection";
                QuizManager.New_answer_C = "Skip colour selection";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            //--end of colours--

            if (Question_number == 8)
            {
                Is_personal_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Would you like the weather to be Rainy?";

                Turn_off_all_images();
                Rain_weather_image.enabled = true;
                Rain_weather_image_animator.SetBool("fadein", true);
                Vignette_for_world_colours_and_weather_images_animator.SetBool("fadein", true);

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes";
                QuizManager.New_answer_B = "Next weather";
                QuizManager.New_answer_C = "Skip weather selection";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);

                StartCoroutine(Unlock_cubes());
            }

            if (Question_number == 9)
            {
                Is_personal_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Would you like the weather to be Sunny?";

                Turn_off_all_images();
                Sun_weather_image.enabled = true;
                Sun_weather_image_animator.SetBool("fadein", true);
                Vignette_for_world_colours_and_weather_images_animator.SetBool("fadein", true);

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes";
                QuizManager.New_answer_B = "Next weather";
                QuizManager.New_answer_C = "Skip weather selection";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 10)
            {
                Is_personal_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Would you like the weather to be Snowy?";

                Turn_off_all_images();
                Snow_weather_image.enabled = true;
                Snow_weather_image_animator.SetBool("fadein", true);
                Vignette_for_world_colours_and_weather_images_animator.SetBool("fadein", true);

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes";
                QuizManager.New_answer_B = "Next weather";
                QuizManager.New_answer_C = "Skip weather selection";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 11)
            {
                Is_personal_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Would you like the weather to be Foggy?";

                Turn_off_all_images();
                Fog_weather_image.enabled = true;
                Fog_weather_image_animator.SetBool("fadein", true);
                Vignette_for_world_colours_and_weather_images_animator.SetBool("fadein", true);

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes";
                QuizManager.New_answer_B = "Next weather";
                QuizManager.New_answer_C = "Skip weather selection";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 12)
            {
                Is_personal_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Would you like the weather to be Cloudy?";

                Turn_off_all_images();
                Cloud_weather_image.enabled = true;
                Cloud_weather_image_animator.SetBool("fadein", true);
                Vignette_for_world_colours_and_weather_images_animator.SetBool("fadein", true);

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes";
                QuizManager.New_answer_B = "No";
                QuizManager.New_answer_C = "Skip weather selection";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 13)
            {
                Is_personal_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Would you like to skip the personality quiz and choose a level?" +
                                          " Not recommended for first time players";

                Turn_off_all_images();
                Button_pushing_tutorial.SetBool("isshow", false);

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes (Will go to level select)";
                QuizManager.New_answer_B = "No (Start quiz)";
                QuizManager.New_answer_C = "Customize colour and weather again";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a personal question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            //--end of personal questions--

            //--start of stress questions--

            if (Question_number == 14)
            {
                Is_stress_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "You are trying to focus on your work in the library," +
                                           " but you can hear someone chewing loudly" +
                                           " across the library, how irritated would you be?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Not irritated";
                QuizManager.New_answer_B = "Slightly irritated";
                QuizManager.New_answer_C = "Very irritated";
                Answer_that_increases_score = "C";

                Debug.Log(Question_number);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 15)
            {
                Is_stress_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "You are stuck in a queue, there are around" +
                                          " 6 people in front of you and the progress of the" +
                                          " queue seems to be moving slowly, how tempted are" +
                                          " you to leave?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "It's taking too long, i'm leaving";
                QuizManager.New_answer_B = "I can stay for a little bit longer";
                QuizManager.New_answer_C = "I can wait, I have time";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 16)
            {
                Is_stress_question = true;


                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Someone or something has made you upset," +
                                          " how long would it take for you to calm down?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Not that long";
                QuizManager.New_answer_B = "Just a bit of time";
                QuizManager.New_answer_C = "It takes a while for me to calm down";
                Answer_that_increases_score = "C";

                Debug.Log(Question_number);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 17)
            {
                Is_stress_question = true;


                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "You are trying to study in your room, but" +
                                          " someone keeps texting you every" +
                                          " few minutes, how annoyed would you be in this situation?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "A little";
                QuizManager.New_answer_B = "Very annoyed, just let me study already...";
                QuizManager.New_answer_C = "I wouldn't mind";
                Answer_that_increases_score = "B";

                Debug.Log(Question_number);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 18)
            {
                Is_stress_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Do you think you overeact to a lot of situations?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Somewhat";
                QuizManager.New_answer_B = "I think so";
                QuizManager.New_answer_C = "Nope";
                Answer_that_increases_score = "B";

                Debug.Log(Question_number);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);

                StartCoroutine(Unlock_balls());
            }

            if (Question_number == 19)
            {
                Is_stress_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "How 'on edge' do you normally feel?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Not as much";
                QuizManager.New_answer_B = "Slightly, when it gets really busy";
                QuizManager.New_answer_C = "A lot, I feel like I can never relax";
                Answer_that_increases_score = "C";

                Debug.Log(Question_number);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 20)
            {
                Is_stress_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "How often do you receive headaches or become dizzy?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Almost everyday";
                QuizManager.New_answer_B = "Rarely";
                QuizManager.New_answer_C = "Never";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 21)
            {
                Is_stress_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Do you often get chest pains?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Almost everyday";
                QuizManager.New_answer_B = "Rarely";
                QuizManager.New_answer_C = "Never";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 22)
            {
                Is_stress_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Have you ever felt your heart racing faster recently?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes";
                QuizManager.New_answer_B = "Rarely";
                QuizManager.New_answer_C = "Not at all";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 23)
            {
                Is_stress_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "How often do you worry about things?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "All the time";
                QuizManager.New_answer_B = "Sometimes";
                QuizManager.New_answer_C = "Not that much";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a stress question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            //--end of stress questions--

            //--start of depression questions--

            if (Question_number == 24)
            {
                Is_depression_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Are you happy with the way things are going in your life?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "I'm very happy";
                QuizManager.New_answer_B = "It could be worse";
                QuizManager.New_answer_C = "I'm not happy at all";
                Answer_that_increases_score = "C";

                Debug.Log(Question_number);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 25)
            {
                Is_depression_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Do you think you have the strength to keep going in your life?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "I don't think so";
                QuizManager.New_answer_B = "Maybe a little bit of strength";
                QuizManager.New_answer_C = "I can keep going";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 26)
            {
                Is_depression_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "And how much determination would you say you have to push yourself" +
                                          " forward and become stronger?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "A little bit";
                QuizManager.New_answer_B = "None at all";
                QuizManager.New_answer_C = "A lot, I feel very determined";
                Answer_that_increases_score = "B";

                Debug.Log(Question_number);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 27)
            {
                Is_depression_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Do you blame the bad things that happen in your life on yourself?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes, because it's all my fault";
                QuizManager.New_answer_B = "Only if it actually is my fault";
                QuizManager.New_answer_C = "Sometimes";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);

                StartCoroutine(Unlock_ping_pong_paddle());
            }

            if (Question_number == 28)
            {
                Is_depression_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "How quick are you to get angry at something?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Not quick at all";
                QuizManager.New_answer_B = "Not that quick";
                QuizManager.New_answer_C = "Very quick";
                Answer_that_increases_score = "C";

                Debug.Log(Question_number);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 29)
            {
                Is_depression_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Have you invested yourself into any hobbies recently?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "A few";
                QuizManager.New_answer_B = "Nope";
                QuizManager.New_answer_C = "Yes, quite a lot";
                Answer_that_increases_score = "B";

                Debug.Log(Question_number);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 30)
            {
                Is_depression_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Have you noticed yourself speaking slower or moving slower than usual?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "I'm not sure";
                QuizManager.New_answer_B = "No";
                QuizManager.New_answer_C = "I think so";
                Answer_that_increases_score = "C";

                Debug.Log(Question_number);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 31)
            {
                Is_depression_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Is your appetite suddenly very low or very high?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes";
                QuizManager.New_answer_B = "I can't tell";
                QuizManager.New_answer_C = "No";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 32)
            {
                Is_depression_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Do you have difficulty trying to sleep?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "No";
                QuizManager.New_answer_B = "Yes";
                QuizManager.New_answer_C = "Slightly";
                Answer_that_increases_score = "B";

                Debug.Log(Question_number);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 33)
            {
                Is_depression_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Do you feel like you don't have any energy to do tasks?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes";
                QuizManager.New_answer_B = "No";
                QuizManager.New_answer_C = "Sometimes";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 34)
            {
                Is_depression_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Have you recently been avoiding your friends and family," +
                                          " or withholding from social events?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "No, I like to spend time with people";
                QuizManager.New_answer_B = "Yes, I don't feel like interacting with anyone";
                QuizManager.New_answer_C = "Sometimes, when i'm not in the mood";
                Answer_that_increases_score = "B";

                Debug.Log(Question_number);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 35)
            {
                Is_depression_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Have you suddenly stopped doing the hobbies you used to love?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes, I don't feel like doing them anymore";
                QuizManager.New_answer_B = "Yes, because I physically can't do them anymore";
                QuizManager.New_answer_C = "No";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a depression question");
                Debug.Log("And the answer is" + Answer_that_increases_score);

                StartCoroutine(Unlock_whiteboard());
            }

            //--end of depression questions--

            //--start of anxiety questions--

            if (Question_number == 36)
            {
                Is_anxiety_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Do you struggle with taking a break or relaxing?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes, I feel unproductive";
                QuizManager.New_answer_B = "Sometimes, it depends how much work I have";
                QuizManager.New_answer_C = "No, I want more breaks";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 37)
            {
                Is_anxiety_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Were you in a state of fear or dread today?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "A little bit";
                QuizManager.New_answer_B = "Yes";
                QuizManager.New_answer_C = "No";
                Answer_that_increases_score = "B";

                Debug.Log(Question_number);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 38)
            {
                Is_anxiety_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Are you always worried about bad things happening?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "No";
                QuizManager.New_answer_B = "Sometimes";
                QuizManager.New_answer_C = "Yes, always";
                Answer_that_increases_score = "C";

                Debug.Log(Question_number);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 39)
            {
                Is_anxiety_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "How difficult is it to focus on a task because you are scared" +
                                          " about the result or the future?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Very difficult";
                QuizManager.New_answer_B = "Slightly difficult";
                QuizManager.New_answer_C = "Not difficult";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 40)
            {
                Is_anxiety_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Have you been avoiding people and objects," +
                                          " in case they bring in more things to be worried about?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Sometimes";
                QuizManager.New_answer_B = "Yes, I don't need more things on my plate";
                QuizManager.New_answer_C = "Nope";
                Answer_that_increases_score = "B";

                Debug.Log(Question_number);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 41)
            {
                Is_anxiety_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Do you take time off work or studying because it" +
                                          " has become much more intimidating?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes";
                QuizManager.New_answer_B = "A little bit";
                QuizManager.New_answer_C = "No, I can manage";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);

                StartCoroutine(Unlock_paper_plane());
            }

            if (Question_number == 42)
            {
                Is_anxiety_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "How often do you get pins and needles?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "I am not sure";
                QuizManager.New_answer_B = "Quite often";
                QuizManager.New_answer_C = "Not that often";
                Answer_that_increases_score = "B";

                Debug.Log(Question_number);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 43)
            {
                Is_anxiety_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Have you noticed yourself with a very dry mouth?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "No";
                QuizManager.New_answer_B = "Sometimes";
                QuizManager.New_answer_C = "Yes";
                Answer_that_increases_score = "C";

                Debug.Log(Question_number);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 44)
            {
                Is_anxiety_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Do you sweat very excessively?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Nope";
                QuizManager.New_answer_B = "Yes, when I do physical exersise";
                QuizManager.New_answer_C = "Yes, for no reason";
                Answer_that_increases_score = "C";

                Debug.Log(Question_number);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 45)
            {
                Is_anxiety_question = true;

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Do you struggle with sleeping because you are scared" +
                                          " about something coming the next day or down the line?";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "Yes, I can't stop thinking about it";
                QuizManager.New_answer_B = "A little, but I can still sleep";
                QuizManager.New_answer_C = "Not at all";
                Answer_that_increases_score = "A";

                Debug.Log(Question_number);
                Debug.Log("This is a anxiety question");
                Debug.Log("And the answer is" + Answer_that_increases_score);
            }

            if (Question_number == 46)
            {

                StartCoroutine(Show_question_text());
                QuizManager.New_question_text = "Thank you for your honesty, the game will adjust" +
                                          " based on your answers, press any button to continue";

                StartCoroutine(Fade_out_answer_texts());
                QuizManager.New_answer_A = "";
                QuizManager.New_answer_B = "";
                QuizManager.New_answer_C = "";
                Answer_that_increases_score = "C";

                Debug.Log(Question_number);
            }

            //--end of anxiety questions--

            //!!!all questions go above this line!!!

            QuizManager.Update_Question = false;

        }
    }
}
