using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class AnxietyGameScript : MonoBehaviour
{
    [Header("-Controllers-")]
    [SerializeField]
    private XRBaseController Left_VR_Controller;
    [SerializeField]
    private XRBaseController Right_VR_Controller;

    LevelChangeFade Level_fade_script;

    [Header("-Game text-")]
    [SerializeField]
    private TextMeshProUGUI Game_instruction_text;
    [SerializeField]
    private Animator Game_instruction_text_animator;

    [Header("-Breathing particles-")]
    [SerializeField]
    private ParticleSystem Breath_in_particle;
    [SerializeField]
    private ParticleSystem Breath_out_particle;

    [Header("-Breathing sound effects-")]
    [SerializeField]
    private AudioSource Breath_in_sound_effect;
    [SerializeField]
    private AudioSource Breath_out_sound_effect;

    //Object that makes the screen black to make player close eyes
    [Header("-Black screen-")]
    [SerializeField]
    private GameObject Close_eyes_object;
    [SerializeField]
    private Animator Close_eyes_animator;
    [SerializeField]
    private AudioSource Open_eyes_sound_effect;


    //Gameobject with collision that checks if the player has their arms out
    [Header("-Arms out collision-")]
    [SerializeField]
    private GameObject Arms_out_collision;

    //Slider used for countdown in the exercise
    [Header("-Exercise slider-")]
    [SerializeField]
    public GameObject Exercise_slider_gameobject;
    [SerializeField]
    public TextMeshProUGUI Exercise_slider_text;
    [SerializeField]
    public Slider Exercise_slider;
    [SerializeField]
    public Animator Exercise_slider_with_text_animator;
    [SerializeField]
    public Image Background_image_for_slider;
    [SerializeField]
    public Image Fill_image_for_slider;

    private float Time_remaining;
    private float Maximum_time = 5.0f;
    private bool Stop_timer = true;

    //Exercise images
    [Header("-Canvas images-")]
    [SerializeField]
    private Image Canvas_border;
    [SerializeField]
    private Image Eyes_close_image,
                  Eyes_open_image,
                  Body_image,
                  Circle_jaw_image,
                  Circle_shoulder_image,
                  Circle_arms_image,
                  Circle_legs_image,
                  Shoulder_up_image,
                  Shoulder_down_image,
                  Arms_out_image,
                  Foot_pointing_up_image,
                  Foot_pointing_forward_image,
                  Jaw_clench_image,
                  Jaw_open_image;

    [Header("-Canvas image animators-")]
    [SerializeField]
    private Animator Canvas_border_anim;
    [SerializeField]
    private Animator Eyes_close_image_anim,
                     Eyes_open_image_anim,
                     Body_image_anim,
                     Circle_jaw_image_anim,
                     Circle_shoulders_image_anim,
                     Circle_arms_image_anim,
                     Circle_legs_image_anim,
                     Shoulder_up_image_anim,
                     Shoulder_down_image_anim,
                     Arms_out_image_anim,
                     Foot_pointing_up_image_anim,
                     Foot_pointing_forward_image_anim,
                     Jaw_clench_image_anim,
                     Jaw_open_image_anim;

    //Voice acting
    [Header("-Voices-")]
    [SerializeField]
    private AudioSource Voice_part_1, Voice_part_2;

    private void Awake()
    {
        Preparing_game();
    }

    private void Preparing_game()
    {
        Close_eyes_object.SetActive(false);
        Breath_in_particle.Pause();
        Breath_out_particle.Pause();
        StartCoroutine(Begin_breathing_exercise());
        Game_instruction_text_animator.GetComponent<Animator>();
        Level_fade_script = GameObject.FindGameObjectWithTag("Fade").GetComponent<LevelChangeFade>();
        Time_remaining = Maximum_time;
    }

    private void Update()
    {
        Countdown_timer();
    }

    private void Countdown_timer()
    {
        if (Time_remaining > 0 && Stop_timer == false)
        {
            //sets the text to only show the first number and not the decimals after it
            Exercise_slider_text.SetText(Time_remaining.ToString("#"));
            Time_remaining -= Time.deltaTime;
            Exercise_slider.value = Time_remaining / Maximum_time;
        }

        if (Time_remaining <= 0)
        {
            StartCoroutine(End_exercise_countdown_timer());
        }
    }

    private void Arms_out_collision_enabled()
    {
        Arms_out_collision.SetActive(true);
    }

    private IEnumerator Begin_exercise_countdown_timer()
    {
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);

        yield return new WaitForSeconds(2f);

        Background_image_for_slider.enabled = true;
        Fill_image_for_slider.enabled = true;
        Exercise_slider_text.enabled = true;

        yield return new WaitForSeconds(1f);

        Exercise_slider_with_text_animator.SetBool("isopen", true);

        yield return new WaitForSeconds(0.2f);

        Stop_timer = false;
    }

    private IEnumerator End_exercise_countdown_timer()
    {
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);

        Exercise_slider_text.SetText("0");
        Stop_timer = true;

        yield return new WaitForSeconds(0.5f);

        Exercise_slider_with_text_animator.SetBool("isopen", false);

        yield return new WaitForSeconds(0.3f);

        Time_remaining = Maximum_time;
        Background_image_for_slider.enabled = false;
        Fill_image_for_slider.enabled = false;
        Exercise_slider_text.enabled = false;
    }

    IEnumerator Breathing_exercise_short_version()
    {
        yield return new WaitForSeconds(3f);
        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(2f);
        Game_instruction_text.text = "And breath in...";
        Game_instruction_text_animator.SetBool("fadeout", false);

        yield return new WaitForSeconds(1f);
        Breath_in_particle.Play();
        Breath_in_sound_effect.Play();

        yield return new WaitForSeconds(1.5f);
        Right_VR_Controller.SendHapticImpulse(0.2f, 6f);
        Left_VR_Controller.SendHapticImpulse(0.2f, 6f);

        yield return new WaitForSeconds(1.5f);
        Breath_in_particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        yield return new WaitForSeconds(1f);
        //shows the countdowntimer
        StartCoroutine(Begin_exercise_countdown_timer());

        yield return new WaitForSeconds(2f);
        Game_instruction_text_animator.SetBool("fadeout", true);

        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "And breath out...";
        Game_instruction_text_animator.SetBool("fadeout", false);

        yield return new WaitForSeconds(1f);
        Breath_out_particle.Play();
        Breath_out_sound_effect.Play();
        Right_VR_Controller.SendHapticImpulse(0.2f, 6f);
        Left_VR_Controller.SendHapticImpulse(0.2f, 6f);

        yield return new WaitForSeconds(2f);
        Breath_out_particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        yield return new WaitForSeconds(2f);
    }

    IEnumerator Begin_breathing_exercise()
    {
        //introduction
        Game_instruction_text_animator.SetBool("fadeout", true);

        yield return new WaitForSeconds(0.2f);

        Game_instruction_text.text = "Welcome!";
        Voice_part_1.Play();
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(7f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "In life, sometimes we feel anxious or worried. And it affects our daily lives.";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(6f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "That's why it is important to give ourselves a break and try and avoid situations that make us anxious.";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(7f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "So we will do a series of activites to help relax your mind.";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(7f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Let us begin with some breathing.";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(6f);

        //start breathing part 1

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Breath in.";
        Game_instruction_text_animator.SetBool("fadeout", false);

        yield return new WaitForSeconds(1f);
        Breath_in_particle.Play();
        Breath_in_sound_effect.Play();

        yield return new WaitForSeconds(1.5f);
        Right_VR_Controller.SendHapticImpulse(0.2f, 6f);
        Left_VR_Controller.SendHapticImpulse(0.2f, 6f);

        yield return new WaitForSeconds(1.5f);
        Breath_in_particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        yield return new WaitForSeconds(2f);
        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Hold your breath.";
        Game_instruction_text_animator.SetBool("fadeout", false);

        yield return new WaitForSeconds(2f);
        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "And breath out.";
        Game_instruction_text_animator.SetBool("fadeout", false);

        yield return new WaitForSeconds(1f);
        Breath_out_particle.Play();
        Breath_out_sound_effect.Play();
        Right_VR_Controller.SendHapticImpulse(0.2f, 6f);
        Left_VR_Controller.SendHapticImpulse(0.2f, 6f);

        yield return new WaitForSeconds(3f);
        Breath_out_particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        yield return new WaitForSeconds(1f);
        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Try to match your breathing with the flow of the particles";
        Game_instruction_text_animator.SetBool("fadeout", false);

        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(Breathing_exercise_loop());
    }

    IEnumerator Breathing_exercise_loop()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(3f);
            Breath_in_particle.Play();
            Breath_in_sound_effect.Play();

            yield return new WaitForSeconds(1.5f);
            Right_VR_Controller.SendHapticImpulse(0.2f, 6f);
            Left_VR_Controller.SendHapticImpulse(0.2f, 6f);

            yield return new WaitForSeconds(1.5f);
            Breath_in_particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);

            yield return new WaitForSeconds(4f);
            Breath_out_particle.Play();
            Breath_out_sound_effect.Play();
            Right_VR_Controller.SendHapticImpulse(0.2f, 6f);
            Left_VR_Controller.SendHapticImpulse(0.2f, 6f);

            yield return new WaitForSeconds(3f);
            Breath_out_particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        yield return new WaitForSeconds(2f);
        StartCoroutine(Begin_applied_relaxation_exercise());
    }

    private void Enable_image_set_1()
    {
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Canvas_border.enabled = true;
        Canvas_border_anim.SetBool("opencanvas", true);
        Eyes_close_image.enabled = true;
        Eyes_close_image_anim.SetBool("Eyes_open_image", true);
    }

    private IEnumerator Enable_image_set_2()
    {
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Eyes_close_image_anim.SetBool("Eyes_open_image", false);
        yield return new WaitForSeconds(1f);
        Eyes_open_image.enabled = true;
        Eyes_open_image_anim.SetBool("isopen", true);
    }

    private IEnumerator Enable_image_set_3()
    {
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Eyes_open_image_anim.SetBool("isopen", false);
        yield return new WaitForSeconds(1f);
        Body_image.enabled = true;
        Body_image_anim.SetBool("openbody", true);
        Circle_jaw_image.enabled = true;
        Circle_jaw_image_anim.SetBool("openjaw", true);
    }

    private IEnumerator Enable_image_set_4()
    {
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Circle_jaw_image_anim.SetBool("openjaw", false);
        Body_image_anim.SetBool("openbody", false);
        yield return new WaitForSeconds(1f);
        Jaw_clench_image.enabled = true;
        Jaw_clench_image_anim.SetBool("isopen", true);
    }

    private IEnumerator Enable_image_set_5()
    {
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Jaw_clench_image_anim.SetBool("isopen", false);
        yield return new WaitForSeconds(1f);
        Jaw_open_image.enabled = true;
        Jaw_open_image_anim.SetBool("isopen", true);
    }

    private IEnumerator Enable_image_set_6()
    {
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Jaw_open_image_anim.SetBool("isopen", false);
        yield return new WaitForSeconds(1f);
        Circle_shoulder_image.enabled = true;
        Circle_shoulders_image_anim.SetBool("opencircleshoulder", true);
        Body_image_anim.SetBool("openbody", true);
    }

    private IEnumerator Enable_image_set_7()
    {
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Circle_shoulders_image_anim.SetBool("opencircleshoulder", false);
        Body_image_anim.SetBool("openbody", false);
        yield return new WaitForSeconds(1f);
        Shoulder_up_image.enabled = true;
        Shoulder_up_image_anim.SetBool("openshoulderup", true);
    }

    private IEnumerator Enable_image_set_8()
    {
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Shoulder_up_image_anim.SetBool("openshoulderup", false);
        yield return new WaitForSeconds(1f);
        Shoulder_down_image.enabled = true;
        Shoulder_down_image_anim.SetBool("openshoulderdown", true);
    }

    private IEnumerator Enable_image_set_9()
    {
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Shoulder_down_image_anim.SetBool("openshoulderdown", false);
        yield return new WaitForSeconds(1f);
        Body_image_anim.SetBool("openbody", true);
        Circle_arms_image.enabled = true;
        Circle_arms_image_anim.SetBool("opencirclearms", true);
    }

    private IEnumerator Enable_image_set_10()
    {
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Body_image_anim.SetBool("openbody", false);
        Circle_arms_image_anim.SetBool("opencirclearms", false);
        yield return new WaitForSeconds(1f);
        Arms_out_image.enabled = true;
        Arms_out_image_anim.SetBool("openarmsout", true);
    }

    private IEnumerator Enable_image_set_11()
    {
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Arms_out_image_anim.SetBool("openarmsout", false);
        yield return new WaitForSeconds(1f);
        Body_image_anim.SetBool("openbody", true);
    }

    private void Enable_image_set_12()
    {
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Circle_legs_image.enabled = true;
        Circle_legs_image_anim.SetBool("opencirclelegs", true);
    }

    private IEnumerator Enable_image_set_13()
    {
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Body_image_anim.SetBool("openbody", false);
        Circle_legs_image_anim.SetBool("opencirclelegs", false);
        yield return new WaitForSeconds(1f);
        Foot_pointing_forward_image.enabled = true;
        Foot_pointing_forward_image_anim.SetBool("openfootforward", true);
    }

    private IEnumerator Enable_image_set_14()
    {
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Foot_pointing_forward_image_anim.SetBool("openfootforward", false);
        yield return new WaitForSeconds(1f);
        Body_image_anim.SetBool("openbody", true);
    }

    private IEnumerator Enable_image_set_15()
    {
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Body_image_anim.SetBool("openbody", false);
        yield return new WaitForSeconds(1f);
        Foot_pointing_up_image.enabled = true;
        Foot_pointing_up_image_anim.SetBool("openfootup", true);
    }

    private IEnumerator Enable_image_set_16()
    {
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        yield return new WaitForSeconds(2f);
        Foot_pointing_up_image_anim.SetBool("openfootup", false);
        Canvas_border_anim.SetBool("opencanvas", false);
    }

    public IEnumerator Begin_applied_relaxation_exercise()
    {

        //intro
        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Now we will partake in a short, and relaxing physical activity.";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "This activity aims to relax your Paper_plane_rigidbody and help you feel calm.";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        //relaxing the eyes
        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Let us begin by relaxing our eyes.";

        //displays the first set of images
        Enable_image_set_1();

        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);


        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Close your eyes as tightly as you can, when the audio plays open your eyes.";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(6f);

        //black screen to make player close eyes
        Close_eyes_object.SetActive(true);
        Close_eyes_animator.SetBool("closeeyes", true);

        yield return new WaitForSeconds(6f);
        Close_eyes_animator.SetBool("closeeyes", false);
        Right_VR_Controller.SendHapticImpulse(0.4f, 0.2f);
        Left_VR_Controller.SendHapticImpulse(0.4f, 0.2f);
        Open_eyes_sound_effect.Play();

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Open and relax your eyes.";

        //plays second set of images, used coroutine for delay
        StartCoroutine(Enable_image_set_2());

        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);
        Close_eyes_object.SetActive(false);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Did you feel the difference between the tense and the relaxed state?";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "It's important to try and notice that so your Paper_plane_rigidbody can feel relaxed.";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "We will be repeating this exercise with different parts of the Paper_plane_rigidbody.";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        Eyes_close_image.enabled = false;

        //jaw relax
        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Let us now relax our jaws.";

        //plays third set of images
        StartCoroutine(Enable_image_set_3());

        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);



        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Clench your teeth together as tightly as you can.";

        //displays images
        StartCoroutine(Enable_image_set_4());

        //shows the countdowntimer
        StartCoroutine(Begin_exercise_countdown_timer());


        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(8f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Now relax your jaws.";

        StartCoroutine(Enable_image_set_5());

        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Your mouth should feel soft and comfortable, and your face feeling relaxed.";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);



        //shoulder relax
        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Let us work on our shoulders.";

        //shows the fourth set of images
        StartCoroutine(Enable_image_set_6());

        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);



        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Hunch your shoulders up towards your ears and hold the position.";

        //shows fifth set of images
        StartCoroutine(Enable_image_set_7());

        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(2f);

        //plays breathing function
        StartCoroutine(Breathing_exercise_short_version());
        yield return Breathing_exercise_short_version();

        Shoulder_up_image.enabled = false;
        Shoulder_down_image.enabled = true;

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Slowly let your shoulders down.";

        //shows sixth set of images
        StartCoroutine(Enable_image_set_8());

        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);



        //relax arms
        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Onto relaxing our arms.";

        //shows seventh set of images
        StartCoroutine(Enable_image_set_9());

        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);





        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Hold your arms out in front of you, with your palms facing the ground.";

        //shows eighths set of images
        StartCoroutine(Enable_image_set_10());

        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Hold down the trigger and grip buttons on the controller and hold the position.";


        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(2f);

        Arms_out_collision_enabled();

    }

    public IEnumerator Begin_applied_relaxation_part_2()
    {
        //plays breathing function
        StartCoroutine(Breathing_exercise_short_version());
        Voice_part_2.PlayDelayed(5f);
        yield return Breathing_exercise_short_version();

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Now slowly relax your arms, your shoulders and arms should feel comfortable.";

        //displays the ninth set of images
        StartCoroutine(Enable_image_set_11());

        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);



        //relaxing legs and feet
        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Let us now relax our legs and our feet.";

        //displays tenth set of images
        Enable_image_set_12();

        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);



        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Hold both legs out in front of you, and point your toes towards the floor. Hold the position.";

        //displays eleventh set of images
        StartCoroutine(Enable_image_set_13());

        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(2f);

        //plays breathing function
        StartCoroutine(Breathing_exercise_short_version());
        yield return Breathing_exercise_short_version();

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Now slowly relax your legs.";

        //displays twelve set of images
        StartCoroutine(Enable_image_set_14());

        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);



        //toes pointing up version
        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "We will do the same leg movement as before, but with a small change.";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Hold both legs out in front of you.";

        //displays thirteenth set of images
        StartCoroutine(Enable_image_set_15());

        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);



        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "This time, point your toes towards the ceiling and hold the position.";

        //shows the countdowntimer
        StartCoroutine(Begin_exercise_countdown_timer());

        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(7f);


        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Now slowly relax your legs.";

        StartCoroutine(Enable_image_set_16());

        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(6f);



        //outro / ending
        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Your whole Paper_plane_rigidbody should feel much more relaxed than before.";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(6f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "There are a few things I would like to mention before you go.";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(6f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Please do not try to do everything at once, set smaller targets that you can achieve.";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(7f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Try not to focus on the things you cannot change.";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(7f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Getting worked up over something you can't control can make you worried.";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(7f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Instead, focus on yourself.";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(7f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "And finally, do not tell yourself you are alone.";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(7f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Most people experience anxiety in their life, it is a normal thing to go through.";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(7f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "That concludes the activity. Congratulations! You did very well.";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(6f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Come back anytime using the level select if you would like to partake in this activity again";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(6f);

        Game_instruction_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        Game_instruction_text.text = "Take care of yourself, Goodbye!";
        Game_instruction_text_animator.SetBool("fadeout", false);
        yield return new WaitForSeconds(6f);

        //fade to main menu
        LevelChangeFade.What_level_number_to_load = 1;
        Level_fade_script.Fade_to_level();
    }
}
