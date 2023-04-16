using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class AnxietyGameScript : MonoBehaviour
{
    public XRBaseController leftcontroller;
    public XRBaseController rightcontroller;

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

    public GameObject armsoutcollision;

    public GameObject exercise_slider_with_text;
    public TextMeshProUGUI slidernumber;
    private float timeremaining;
    public float maxtime = 5.0f;
    private bool stoptimer = true;
    public Slider exerciseslider;
    public Animator exercise_slider_with_text_animator;
    public Image backgroundslider;
    public Image fillslider;

    //images for the canvas
    [SerializeField]
    private Image imagecanvas, eyesclose, eyesopen, bodyimage,
                  circlejaw, circleshoulders, circlearms,
                  circlelegs, shouldrrup, shoulderdown, armsout, footup,
                  footforward, jawclench, jawopen;

    [SerializeField]
    private Animator imagecanvasanim, eyescloseanim, eyesopenanim, bodyimageanim,
                  circlejawanim, circleshouldersanim, circlearmsanim,
                  circlelegsanim, shouldrrupanim, shoulderdownanim, armsoutanim, footupanim,
                  footforwardanim, jawclenchanim, jawopenanim;

    private void Awake()
    {
        closeyesobject.SetActive(false);
        breathin.Pause();
        breathout.Pause();
    }
    private void Start()
    {
        //change when done with game
        StartCoroutine(BreathingexerciseStart());
        screentextanim.GetComponent<Animator>();
        fadelevelscript = GameObject.FindGameObjectWithTag("Fade").GetComponent<Levelchangefade>();

        timeremaining = maxtime;
    }

    private void Update()
    {
        Timer();
    }

    private void Timer()
    {
        if (timeremaining > 0 && stoptimer == false)
        {
            slidernumber.SetText(timeremaining.ToString("#"));
            timeremaining -= Time.deltaTime;
            exerciseslider.value = timeremaining / maxtime;
        }

        if (timeremaining <= 0)
        {
            StartCoroutine(exercisesliderclose());
        }
    }

    private void armsouttest()
    {
        armsoutcollision.SetActive(true);
    }

    private IEnumerator exersicesliderspawn()
    {
        rightcontroller.SendHapticImpulse(0.1f, 0.1f);
        leftcontroller.SendHapticImpulse(0.1f, 0.1f);
        yield return new WaitForSeconds(2f);
        backgroundslider.enabled = true;
        fillslider.enabled = true;
        slidernumber.enabled = true;
        yield return new WaitForSeconds(1f);
        //opens the animation for the slider
        exercise_slider_with_text_animator.SetBool("isopen", true);
        yield return new WaitForSeconds(0.2f);

        //turns the timer on
        stoptimer = false;
    }

    private IEnumerator exercisesliderclose()
    {
        rightcontroller.SendHapticImpulse(0.1f, 0.1f);
        leftcontroller.SendHapticImpulse(0.1f, 0.1f);
        slidernumber.SetText("0");
        stoptimer = true;
        yield return new WaitForSeconds(0.5f);
        exercise_slider_with_text_animator.SetBool("isopen", false);
        yield return new WaitForSeconds(0.3f);
        timeremaining = maxtime;
        backgroundslider.enabled = false;
        fillslider.enabled = false;
        slidernumber.enabled = false;
    }

    IEnumerator shortbreathing()
    {
        yield return new WaitForSeconds(3f);
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(2f);
        screentext.text = "And breath in...";
        screentextanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(1f);
        breathin.Play();
        breathinsound.Play();
        yield return new WaitForSeconds(1.5f);
        rightcontroller.SendHapticImpulse(0.2f, 6f);
        leftcontroller.SendHapticImpulse(0.2f, 6f);
        yield return new WaitForSeconds(1.5f);
        breathin.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        yield return new WaitForSeconds(1f);

        //shows the countdowntimer
        StartCoroutine(exersicesliderspawn());

        yield return new WaitForSeconds(2f);
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "And breath out...";
        screentextanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(1f);
        breathout.Play();
        breathoutsound.Play();
        rightcontroller.SendHapticImpulse(0.2f, 6f);
        leftcontroller.SendHapticImpulse(0.2f, 6f);
        yield return new WaitForSeconds(2f);
        breathout.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        yield return new WaitForSeconds(2f);


    }

    IEnumerator BreathingexerciseStart()
    {
        //intro
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Welcome!";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(7f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "In life, sometimes we feel anxious or worried. And it affects our daily lives.";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(6f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "That's why it is important to give ourselves a break and try and avoid situations that make us anxious.";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(7f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "So we will do a series of activites to help relax your mind.";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(7f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Let us begin with some breathing.";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(6f);

        //start breathing part 1

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Breath in.";
        screentextanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(1f);
        breathin.Play();
        breathinsound.Play();
        yield return new WaitForSeconds(1.5f);
        rightcontroller.SendHapticImpulse(0.2f, 6f);
        leftcontroller.SendHapticImpulse(0.2f, 6f);
        yield return new WaitForSeconds(1.5f);
        breathin.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        yield return new WaitForSeconds(2f);
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Hold your breath.";
        screentextanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(2f);
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "And breath out.";
        screentextanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(1f);
        breathout.Play();
        breathoutsound.Play();
        rightcontroller.SendHapticImpulse(0.2f, 6f);
        leftcontroller.SendHapticImpulse(0.2f, 6f);
        yield return new WaitForSeconds(3f);
        breathout.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        yield return new WaitForSeconds(1f);
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Try to match your breathing with the flow of the particles";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(Breathingexercise());
    }

    IEnumerator Breathingexercise()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(3f);
            breathin.Play();
            breathinsound.Play();
            yield return new WaitForSeconds(1.5f);
            rightcontroller.SendHapticImpulse(0.2f, 6f);
            leftcontroller.SendHapticImpulse(0.2f, 6f);
            yield return new WaitForSeconds(1.5f);
            breathin.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            yield return new WaitForSeconds(4f);
            breathout.Play();
            breathoutsound.Play();
            rightcontroller.SendHapticImpulse(0.2f, 6f);
            leftcontroller.SendHapticImpulse(0.2f, 6f);
            yield return new WaitForSeconds(3f);
            breathout.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        yield return new WaitForSeconds(2f);
        StartCoroutine(appliedrelaxation());
    }

    private void Images1()
    {
        rightcontroller.SendHapticImpulse(0.1f, 0.1f);
        leftcontroller.SendHapticImpulse(0.1f, 0.1f);
        imagecanvas.enabled = true;
        imagecanvasanim.SetBool("opencanvas", true);
        eyesclose.enabled = true;
        eyescloseanim.SetBool("eyesopen", true);
    }

    private IEnumerator Images2()
    {
        rightcontroller.SendHapticImpulse(0.1f, 0.1f);
        leftcontroller.SendHapticImpulse(0.1f, 0.1f);
        eyescloseanim.SetBool("eyesopen", false);
        yield return new WaitForSeconds(1f);
        eyesopen.enabled = true;
        eyesopenanim.SetBool("isopen", true);
    }

    private IEnumerator Images3()
    {
        rightcontroller.SendHapticImpulse(0.1f, 0.1f);
        leftcontroller.SendHapticImpulse(0.1f, 0.1f);
        eyesopenanim.SetBool("isopen", false);
        yield return new WaitForSeconds(1f);
        bodyimage.enabled = true;
        bodyimageanim.SetBool("openbody", true);
        circlejaw.enabled = true;
        circlejawanim.SetBool("openjaw", true);
    }

    private IEnumerator Images3_1()
    {
        rightcontroller.SendHapticImpulse(0.1f, 0.1f);
        leftcontroller.SendHapticImpulse(0.1f, 0.1f);
        circlejawanim.SetBool("openjaw", false);
        bodyimageanim.SetBool("openbody", false);
        yield return new WaitForSeconds(1f);
        jawclench.enabled = true;
        jawclenchanim.SetBool("isopen", true);
    }

    private IEnumerator Images3_2()
    {
        rightcontroller.SendHapticImpulse(0.1f, 0.1f);
        leftcontroller.SendHapticImpulse(0.1f, 0.1f);
        jawclenchanim.SetBool("isopen", false);
        yield return new WaitForSeconds(1f);
        jawopen.enabled = true;
        jawopenanim.SetBool("isopen", true);
    }

    private IEnumerator Images4()
    {
        rightcontroller.SendHapticImpulse(0.1f, 0.1f);
        leftcontroller.SendHapticImpulse(0.1f, 0.1f);
        jawopenanim.SetBool("isopen", false);
        yield return new WaitForSeconds(1f);
        circleshoulders.enabled = true;
        circleshouldersanim.SetBool("opencircleshoulder", true);
        bodyimageanim.SetBool("openbody", true);
    }

    private IEnumerator Images5()
    {
        rightcontroller.SendHapticImpulse(0.1f, 0.1f);
        leftcontroller.SendHapticImpulse(0.1f, 0.1f);
        circleshouldersanim.SetBool("opencircleshoulder", false);
        bodyimageanim.SetBool("openbody", false);
        yield return new WaitForSeconds(1f);
        shouldrrup.enabled = true;
        shouldrrupanim.SetBool("openshoulderup", true);
    }

    private IEnumerator Images6()
    {
        rightcontroller.SendHapticImpulse(0.1f, 0.1f);
        leftcontroller.SendHapticImpulse(0.1f, 0.1f);
        shouldrrupanim.SetBool("openshoulderup", false);
        yield return new WaitForSeconds(1f);
        shoulderdown.enabled = true;
        shoulderdownanim.SetBool("openshoulderdown", true);
    }

    private IEnumerator Images7()
    {
        rightcontroller.SendHapticImpulse(0.1f, 0.1f);
        leftcontroller.SendHapticImpulse(0.1f, 0.1f);
        shoulderdownanim.SetBool("openshoulderdown", false);
        yield return new WaitForSeconds(1f);
        bodyimageanim.SetBool("openbody", true);
        circlearms.enabled = true;
        circlearmsanim.SetBool("opencirclearms", true);
    }

    private IEnumerator Images8()
    {
        rightcontroller.SendHapticImpulse(0.1f, 0.1f);
        leftcontroller.SendHapticImpulse(0.1f, 0.1f);
        bodyimageanim.SetBool("openbody", false);
        circlearmsanim.SetBool("opencirclearms", false);
        yield return new WaitForSeconds(1f);
        armsout.enabled = true;
        armsoutanim.SetBool("openarmsout", true);
    }

    private IEnumerator Images9()
    {
        rightcontroller.SendHapticImpulse(0.1f, 0.1f);
        leftcontroller.SendHapticImpulse(0.1f, 0.1f);
        armsoutanim.SetBool("openarmsout", false);
        yield return new WaitForSeconds(1f);
        bodyimageanim.SetBool("openbody", true);
    }

    private void Images10()
    {
        rightcontroller.SendHapticImpulse(0.1f, 0.1f);
        leftcontroller.SendHapticImpulse(0.1f, 0.1f);
        circlelegs.enabled = true;
        circlelegsanim.SetBool("opencirclelegs", true);
    }

    private IEnumerator Images11()
    {
        rightcontroller.SendHapticImpulse(0.1f, 0.1f);
        leftcontroller.SendHapticImpulse(0.1f, 0.1f);
        bodyimageanim.SetBool("openbody", false);
        circlelegsanim.SetBool("opencirclelegs", false);
        yield return new WaitForSeconds(1f);
        footforward.enabled = true;
        footforwardanim.SetBool("openfootforward", true);
    }

    private IEnumerator Images12()
    {
        rightcontroller.SendHapticImpulse(0.1f, 0.1f);
        leftcontroller.SendHapticImpulse(0.1f, 0.1f);
        footforwardanim.SetBool("openfootforward", false);
        yield return new WaitForSeconds(1f);
        bodyimageanim.SetBool("openbody", true);
    }

    private IEnumerator Images13()
    {
        rightcontroller.SendHapticImpulse(0.1f, 0.1f);
        leftcontroller.SendHapticImpulse(0.1f, 0.1f);
        bodyimageanim.SetBool("openbody", false);
        yield return new WaitForSeconds(1f);
        footup.enabled = true;
        footupanim.SetBool("openfootup", true);
    }

    private IEnumerator Images14()
    {
        rightcontroller.SendHapticImpulse(0.1f, 0.1f);
        leftcontroller.SendHapticImpulse(0.1f, 0.1f);
        yield return new WaitForSeconds(2f);
        footupanim.SetBool("openfootup", false);
        imagecanvasanim.SetBool("opencanvas", false);
    }

    public IEnumerator appliedrelaxation()
    {

        //intro
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Now we will partake in a short, and relaxing physical activity.";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "This activity aims to relax your body and help you feel calm.";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        //relaxing the eyes
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Let us begin by relaxing our eyes.";

        //displays the first set of images
        Images1();

        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);


        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Close your eyes as tightly as you can, when the audio plays open your eyes.";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(6f);

        //black screen to make player close eyes
        closeyesobject.SetActive(true);
        closeeyesanim.SetBool("closeeyes", true);

        yield return new WaitForSeconds(6f);
        closeeyesanim.SetBool("closeeyes", false);
        rightcontroller.SendHapticImpulse(0.4f, 0.2f);
        leftcontroller.SendHapticImpulse(0.4f, 0.2f);
        openeyesound.Play();

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Open and relax your eyes.";

        //plays second set of images, used coroutine for delay
        StartCoroutine(Images2());

        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);
        closeyesobject.SetActive(false);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Did you feel the difference between the tense and the relaxed state?";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "It's important to try and notice that so your body can feel relaxed.";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "We will be repeating this exercise with different parts of the body.";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        eyesclose.enabled = false;

        //jaw relax
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Let us now relax our jaws.";

        //plays third set of images
        StartCoroutine(Images3());

        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);



        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Clench your teeth together as tightly as you can.";

        //displays images
        StartCoroutine(Images3_1());

        //shows the countdowntimer
        StartCoroutine(exersicesliderspawn());


        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(8f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Now relax your jaws.";

        StartCoroutine(Images3_2());

        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Your mouth should feel soft and comfortable, and your face feeling relaxed.";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);



        //shoulder relax
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Let us work on our shoulders.";

        //shows the fourth set of images
        StartCoroutine(Images4());

        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);



        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Hunch your shoulders up towards your ears and hold the position.";

        //shows fifth set of images
        StartCoroutine(Images5());

        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(2f);

        //plays breathing function
        StartCoroutine(shortbreathing());
        yield return shortbreathing();

        shouldrrup.enabled = false;
        shoulderdown.enabled = true;

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Slowly let your shoulders down.";

        //shows sixth set of images
        StartCoroutine(Images6());

        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);



        //relax arms
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Onto relaxing our arms.";

        //shows seventh set of images
        StartCoroutine(Images7());

        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);





        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Hold your arms out in front of you, with your palms facing the ground.";

        //shows eighths set of images
        StartCoroutine(Images8());

        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Hold down the trigger and grip buttons on the controller and hold the position.";


        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(2f);

        armsouttest();

    }

    public IEnumerator Relaxationpart2()
    {
        //plays breathing function
        StartCoroutine(shortbreathing());
        yield return shortbreathing();

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Now slowly relax your arms, your shoulders and arms should feel comfortable.";

        //displays the ninth set of images
        StartCoroutine(Images9());

        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);



        //relaxing legs and feet
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Let us now relax our legs and our feet.";

        //displays tenth set of images
        Images10();

        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);



        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Hold both legs out in front of you, and point your toes towards the floor. Hold the position.";

        //displays eleventh set of images
        StartCoroutine(Images11());

        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(2f);

        //plays breathing function
        StartCoroutine(shortbreathing());
        yield return shortbreathing();

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Now slowly relax your legs.";

        //displays twelve set of images
        StartCoroutine(Images12());

        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);



        //toes pointing up version
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "We will do the same leg movement as before, but with a small change.";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Hold both legs out in front of you.";

        //displays thirteenth set of images
        StartCoroutine(Images13());

        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(5f);



        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "This time, point your toes towards the ceiling and hold the position.";

        //shows the countdowntimer
        StartCoroutine(exersicesliderspawn());

        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(7f);


        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Now slowly relax your legs.";

        StartCoroutine(Images14());

        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(6f);



        //outro / ending
        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Your whole body should now feel much more relaxed than before.";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(6f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "There are a few things I would like to mention before you go.";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(6f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Please do not try to do everything at once, set smaller targets that you can acheieve.";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(7f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Try not to focus on the things you cannot change.";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(7f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Getting worked up over something you can't control can make you worried.";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(7f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Instead, focus on yourself.";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(7f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "And finally, do not tell yourself you are alone.";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(7f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Most people experience anxiety in their life, it is a normal thing to go through.";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(7f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "That concludes the activity. Congratulations! You did very well.";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(6f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Come back anytime using the level select if you would like to partake in this activity again";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(6f);

        screentextanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        screentext.text = "Take care of yourself, Goodbye!";
        screentextanim.SetBool("fadeout", false);
        yield return new WaitForSeconds(6f);

        //fade to main menu
        Levelchangefade.leveltoload = 0;
        fadelevelscript.fadetolevel();
    }
}
