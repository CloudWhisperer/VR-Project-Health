using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnxietyGameScript : MonoBehaviour
{
    Levelchangefade fadelevelscript;
    public TextMeshProUGUI screentext;
    public Animator screentextanim;
    public ParticleSystem breathin;
    public ParticleSystem breathout;
    public AudioSource breathinsound;
    public AudioSource breathoutsound;
    public GameObject closeyesobject;
    public Animator closeeyesanim;
    public AudioSource openeyesound;

    //images for the canvas
    [Header("Images for the canvas")]
    [SerializeField]
    private Image imagecanvas, eyesclose, eyesopen, bodyimage,
                  circlejaw, circleshoulders, circlearms,
                  circlelegs, shouldrrup, shoulderdown, armsout, footup,
                  footforward;

    private void Awake()
    {
        closeyesobject.SetActive(false);
        breathin.Pause();
        breathout.Pause();
    }
    private void Start()
    {
        StartCoroutine(appliedrelaxation());
        screentextanim.GetComponent<Animator>();
        fadelevelscript = GameObject.FindGameObjectWithTag("Fade").GetComponent<Levelchangefade>();
    }

    IEnumerator shortbreathing()
    {
        yield return new WaitForSeconds(3f);
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(2f);
        screentext.text = "Breath in.";
        screentextanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(1f);
        breathin.Play();
        breathinsound.Play();
        yield return new WaitForSeconds(2f);
        breathin.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        yield return new WaitForSeconds(2f);
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Breath out...";
        screentextanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(1f);
        breathout.Play();
        breathoutsound.Play();
        yield return new WaitForSeconds(2f);
        breathout.Stop(true, ParticleSystemStopBehavior.StopEmitting);
    }

    IEnumerator BreathingexerciseStart()
    {
        //start breathing part  //1

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Breath in.";
        screentextanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(1f);
        breathin.Play();
        breathinsound.Play();
        yield return new WaitForSeconds(5f);
        breathin.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Hold your breath...";
        screentextanim.SetBool("fadeout", false);


        yield return new WaitForSeconds(2f);
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Breath out...";
        screentextanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(1f);
        breathout.Play();
        breathoutsound.Play();
        yield return new WaitForSeconds(5f);
        breathout.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        yield return new WaitForSeconds(1f);
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Try to match your breathing with the flow";
        screentextanim.SetBool("fadeout", false);
        yield return StartCoroutine(Breathingexercise());
    }

    IEnumerator Breathingexercise()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(5f);
            breathin.Play();
            breathinsound.Play();
            yield return new WaitForSeconds(5f);
            breathin.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            yield return new WaitForSeconds(2f);
            breathout.Play();
            breathoutsound.Play();
            yield return new WaitForSeconds(5f);
            breathout.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        yield return new WaitForSeconds(2f);
        StartCoroutine(appliedrelaxation());
    }

    //IEnumerator opencanvas()
    //{
    //    imagecanvas.enabled = true;
    //    eyesclose.enabled = true;
    //}

    IEnumerator appliedrelaxation()
    {

        //intro
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Now we will partake in a short and relaxing physical activity";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "This activity aims to relax your body and help you feel calm";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        //relaxing the eyes
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Let us begin by relaxing our eyes";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        imagecanvas.enabled = true;
        eyesclose.enabled = true;

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Close your eyes tightly for 5 seconds, when the audio plays open your eyes";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(4f);

        //black screen to make player close eyes change later
        closeyesobject.SetActive(true);
        closeeyesanim.SetBool("closeeyes", true);
        Debug.Log("black screen");

        yield return new WaitForSeconds(5f);
        closeeyesanim.SetBool("closeeyes", false);
        openeyesound.Play();

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Open and relax your eyes";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);
        closeyesobject.SetActive(false);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Feel the difference between the tense and relaxed state...";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "We will be repeating this exercise with different parts of the body";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        eyesclose.enabled = false;

        //jaw relax
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Let us now relax our jaws";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        bodyimage.enabled = true;
        circlejaw.enabled = true;

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Clench your teeth together for 5 seconds";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(6f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Now relax your jaws";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Your mouth should feel soft and comfortable, and your face feeling relaxed";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        circlejaw.enabled = false;
        circleshoulders.enabled = true;

        //shoulder relax
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Now onto our shoulders";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        circleshoulders.enabled = false;
        bodyimage.enabled = false;
        shouldrrup.enabled = true;

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Hunch your shoulders up towards your ears and hold the position";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(2f);

        //plays breathing function
        StartCoroutine(shortbreathing());
        yield return shortbreathing();

        shouldrrup.enabled = false;
        shoulderdown.enabled = true;

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Slowly let your shoulders down...";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        shoulderdown.enabled = false;
        bodyimage.enabled = true;
        circlearms.enabled = true;

        //relax arms
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Onto relaxing our arms";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        bodyimage.enabled = false;
        circlearms.enabled = false;
        armsout.enabled = true;

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Hold your arms out in front of you";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Hold down the trigger and grip buttons on the controller and hold the position";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(2f);

        //plays breathing function
        StartCoroutine(shortbreathing());
        yield return shortbreathing();

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Slowly relax your arms and shoulders and feel the difference";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        armsout.enabled = false;
        bodyimage.enabled = true;
        circlelegs.enabled = true;

        //relaxing legs and feet
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Let us now relax our legs and our feet";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        bodyimage.enabled = false;
        circlelegs.enabled = false;
        footforward.enabled = true;

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Hold your legs out in front of you and point your toes towards the floor, hold the position";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(2f);

        //plays breathing function
        StartCoroutine(shortbreathing());
        yield return shortbreathing();

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Now slowly relax your legs";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        footforward.enabled = false;
        bodyimage.enabled = true;

        //toes pointing up version
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "We will do the same as before but with a small change";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Hold your legs out in front of you";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        bodyimage.enabled = false;
        footup.enabled = true;

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Point your toes towards the ceiling and hold the position";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Now slowly relax your legs";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        footup.enabled = false;
        imagecanvas.enabled = false;

        //outro / ending
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Feel the difference in your body between the tense and relaxed states";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "And how relaxed the whole of your body feels";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "That concludes the activity";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Come back whenever you like if you would like to do the activity again";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        //fade to main menu
        Levelchangefade.leveltoload = 0;
        fadelevelscript.fadetolevel();

    }
}
