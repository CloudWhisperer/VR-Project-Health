using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class cointouchminigamescorescript : MonoBehaviour
{
    private Levelchangefade Fade_level_script;

    [Header("-VR Controllers-")]
    [SerializeField]
    private XRBaseController Right_VR_controller;
    [SerializeField]
    private XRBaseController Left_VR_controller;

    [Header("-Player sphere-")]
    [SerializeField]
    private GameObject Player_sphere;
    [SerializeField]
    private Animator Player_sphere_animator;

    [Header("-Coins, obstacles, and world text-")]
    [SerializeField]
    private GameObject Coins_and_obstacles_gameobject;
    [SerializeField]
    private GameObject Tutorial_coins;
    [SerializeField]
    private GameObject Respawn_wall;
    [SerializeField]
    private TextMeshProUGUI World_text;
    [SerializeField]
    private Animator World_text_animator;

    [Header("-Particle systems-")]
    [SerializeField]
    private ParticleSystem Breath_in_particle_effect;
    [SerializeField]
    private ParticleSystem Breath_out_particle_effect;

    [Header("Sound effects & voices")]
    [SerializeField]
    private AudioSource Breath_in_sound_effect;
    [SerializeField]
    private AudioSource Breath_out_sound_effect;
    [SerializeField]
    private AudioSource Voice_part_1;
    [SerializeField]
    private AudioSource Voice_part_2;

    [Header("Score counters")]
    public static int scorecounter;
    public static int losecounter;

    private void Start()
    {
        Initialize_values_and_start_game();
    }

    private void Initialize_values_and_start_game()
    {
        StartCoroutine(Start_of_game());
        World_text_animator.GetComponent<Animator>();
        Fade_level_script = GameObject.FindGameObjectWithTag("Fade").GetComponent<Levelchangefade>();
    }

    IEnumerator Start_of_game()
    {
        //beginning text
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "Welcome!";
        World_text_animator.SetBool("fadeout", false);

        Voice_part_1.Play();

        yield return new WaitForSeconds(6f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "Life can be stressful for us sometimes.";
        World_text_animator.SetBool("fadeout", false);


        yield return new WaitForSeconds(5f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "That's why it's very important that we take breaks, and relax our minds.";
        World_text_animator.SetBool("fadeout", false);


        yield return new WaitForSeconds(6f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "There are lots of ways to relax our minds.";
        World_text_animator.SetBool("fadeout", false);


        yield return new WaitForSeconds(5f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "And we will do a few of them together!";
        World_text_animator.SetBool("fadeout", false);


        yield return new WaitForSeconds(5f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "Let's begin by taking a few deep breaths.";
        World_text_animator.SetBool("fadeout", false);


        yield return new WaitForSeconds(4f);
        yield return StartCoroutine(Begin_Breathing_exercise());
    }
    IEnumerator Begin_Breathing_exercise()
    {
        //start breathing part  //1

        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "Breath in...";
        World_text_animator.SetBool("fadeout", false);


        yield return new WaitForSeconds(1f);
        Breath_in_particle_effect.Play();
        Breath_in_sound_effect.Play();
        yield return new WaitForSeconds(1.5f);
        Right_VR_controller.SendHapticImpulse(0.2f, 6f);
        Left_VR_controller.SendHapticImpulse(0.2f, 6f);
        yield return new WaitForSeconds(1.5f);
        Breath_in_particle_effect.Stop(true, ParticleSystemStopBehavior.StopEmitting);


        yield return new WaitForSeconds(2f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "Hold your breath...";
        World_text_animator.SetBool("fadeout", false);


        yield return new WaitForSeconds(2f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "Breath out...";
        World_text_animator.SetBool("fadeout", false);


        yield return new WaitForSeconds(1f);
        Breath_out_particle_effect.Play();
        Breath_out_sound_effect.Play();
        Right_VR_controller.SendHapticImpulse(0.2f, 6f);
        Left_VR_controller.SendHapticImpulse(0.2f, 6f);
        yield return new WaitForSeconds(3f);
        Breath_out_particle_effect.Stop(true, ParticleSystemStopBehavior.StopEmitting);


        yield return new WaitForSeconds(1f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "Try to match your breathing with the flow.";
        World_text_animator.SetBool("fadeout", false);
        yield return StartCoroutine(Breathing_exercise_loop());
    }

    IEnumerator Breathing_exercise_loop()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(3f);
            Breath_in_particle_effect.Play();
            Breath_in_sound_effect.Play();
            yield return new WaitForSeconds(1.5f);
            Right_VR_controller.SendHapticImpulse(0.2f, 6f);
            Left_VR_controller.SendHapticImpulse(0.2f, 6f);
            yield return new WaitForSeconds(1.5f);
            Breath_in_particle_effect.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            yield return new WaitForSeconds(4f);
            Breath_out_particle_effect.Play();
            Breath_out_sound_effect.Play();
            Right_VR_controller.SendHapticImpulse(0.2f, 6f);
            Left_VR_controller.SendHapticImpulse(0.2f, 6f);
            yield return new WaitForSeconds(3f);
            Breath_out_particle_effect.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        yield return new WaitForSeconds(2f);
        StartCoroutine(Begin_coin_game());
    }

    IEnumerator Begin_coin_game()
    {
        Player_sphere.SetActive(true);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "Now lets play a short game.";
        World_text_animator.SetBool("fadeout", false);


        yield return new WaitForSeconds(5f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "This game is designed to keep you into a flow state.";
        World_text_animator.SetBool("fadeout", false);


        yield return new WaitForSeconds(5f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "You control the sphere in front of you.";
        World_text_animator.SetBool("fadeout", false);


        yield return new WaitForSeconds(5f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "The sphere moves based on where you are looking.";
        World_text_animator.SetBool("fadeout", false);


        yield return new WaitForSeconds(5f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "Use the movement of your head to touch the rotating coins.";
        World_text_animator.SetBool("fadeout", false);


        yield return new WaitForSeconds(6f);
        Tutorial_coins.SetActive(true);
        yield return new WaitForSeconds(7f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "Now let's add some obstacles in the way.";
        World_text_animator.SetBool("fadeout", false);


        yield return new WaitForSeconds(6f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "Now try to touch the rotating coins while avoiding the obstacles.";
        yield return new WaitForSeconds(1f);
        Coins_and_obstacles_gameobject.SetActive(true);
        Respawn_wall.SetActive(true);
    }

    //this function was made so another script can call the end stress game function
    public void End_Game()
    {
        StartCoroutine(End_stress_game());
    }

    public IEnumerator End_stress_game()
    {
        Respawn_wall.SetActive(false);
        Player_sphere_animator.SetTrigger("isend");
        yield return new WaitForSeconds(1);
        Player_sphere.SetActive(false);


        yield return new WaitForSeconds(5f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "Stress can lead us towards bad decisions because we don't think straight.";
        World_text_animator.SetBool("fadeout", false);

        Voice_part_2.Play();

        yield return new WaitForSeconds(6f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "Try your best to ignore any negative thoughts, everything is always in motion.";
        World_text_animator.SetBool("fadeout", false);


        yield return new WaitForSeconds(6f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "Some people say that when a door closes, another door opens.";
        World_text_animator.SetBool("fadeout", false);


        yield return new WaitForSeconds(6f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "Which means that if something ever goes wrong in your life, another opportunity will arise.";
        World_text_animator.SetBool("fadeout", false);


        yield return new WaitForSeconds(6f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "Take care of yourself, and remember to give yourself time to relax!";
        World_text_animator.SetBool("fadeout", false);


        yield return new WaitForSeconds(6f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "That concludes our session.";
        World_text_animator.SetBool("fadeout", false);


        yield return new WaitForSeconds(3f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "Feel free to come back anytime to play again.";
        World_text_animator.SetBool("fadeout", false);


        yield return new WaitForSeconds(4f);
        World_text_animator.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        World_text.text = "Goodbye!";
        World_text_animator.SetBool("fadeout", false);


        //fades back into the main menu
        yield return new WaitForSeconds(4f);
        Levelchangefade.What_level_number_to_load = 1;
        Fade_level_script.Fade_to_level();
    }
}
