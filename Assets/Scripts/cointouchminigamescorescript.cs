using System.Collections;
using TMPro;
using UnityEngine;

public class cointouchminigamescorescript : MonoBehaviour
{
    Levelchangefade fadelevelscript;

    public GameObject playersphere;
    public Animator sphereanim;

    public GameObject objects;
    public GameObject tutorialobjects;
    public GameObject backwall;
    public TextMeshProUGUI starttext;
    public Animator textanim;

    public ParticleSystem breathin;
    public ParticleSystem breathout;
    public AudioSource breathinsound;
    public AudioSource breathoutsound;

    public static int scorecounter;
    public static int losecounter;

    private void Awake()
    {
        breathin.Pause();
        breathout.Pause();
    }
    private void Start()
    {
        StartCoroutine(beginningtext());
        textanim.GetComponent<Animator>();
        fadelevelscript = GameObject.FindGameObjectWithTag("Fade").GetComponent<Levelchangefade>();
    }

    IEnumerator beginningtext()
    {
        //beggining text
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "Welcome!";
        textanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(6f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "Life can be stressful for us sometimes.";
        textanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(5f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "That's why it's very important that we take breaks, and relax our minds.";
        textanim.SetBool("fadeout", false);


        yield return new WaitForSeconds(6f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "There are lots of ways to relax our minds.";
        textanim.SetBool("fadeout", false);


        yield return new WaitForSeconds(5f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "And we will do a few of them together!";
        textanim.SetBool("fadeout", false);


        yield return new WaitForSeconds(5f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "Let's begin by taking a few deep breaths.";
        textanim.SetBool("fadeout", false);


        yield return new WaitForSeconds(4f);
        yield return StartCoroutine(BreathingexerciseStart());
    }
    IEnumerator BreathingexerciseStart()
    {
        //start breathing part  //1

        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "Breath in...";
        textanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(1f);
        breathin.Play();
        breathinsound.Play();
        yield return new WaitForSeconds(3f);
        breathin.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        yield return new WaitForSeconds(2f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "Hold your breath...";
        textanim.SetBool("fadeout", false);


        yield return new WaitForSeconds(2f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "Breath out...";
        textanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(1f);
        breathout.Play();
        breathoutsound.Play();
        yield return new WaitForSeconds(3f);
        breathout.Stop(true, ParticleSystemStopBehavior.StopEmitting);

        yield return new WaitForSeconds(1f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "Try to match your breathing with the flow.";
        textanim.SetBool("fadeout", false);
        yield return StartCoroutine(Breathingexercise());
    }

    IEnumerator Breathingexercise()
    {
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(3f);
            breathin.Play();
            breathinsound.Play();
            yield return new WaitForSeconds(3f);
            breathin.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            yield return new WaitForSeconds(4f);
            breathout.Play();
            breathoutsound.Play();
            yield return new WaitForSeconds(3f);
            breathout.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        yield return new WaitForSeconds(2f);
        StartCoroutine(Coingame());
    }

    IEnumerator Coingame()
    {
        playersphere.SetActive(true);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "Now lets play a short game.";
        textanim.SetBool("fadeout", false);


        yield return new WaitForSeconds(5f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "This game is designed to keep you into a flow state.";
        textanim.SetBool("fadeout", false);


        yield return new WaitForSeconds(5f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "You control the sphere in front of you.";
        textanim.SetBool("fadeout", false);


        yield return new WaitForSeconds(5f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "Use the movement of your head to touch the rotating coins.";
        textanim.SetBool("fadeout", false);


        yield return new WaitForSeconds(6f);
        tutorialobjects.SetActive(true);
        yield return new WaitForSeconds(7f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "Now let's add some obstacles in the way.";
        textanim.SetBool("fadeout", false);


        yield return new WaitForSeconds(6f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "Now try to touch the rotating coins while avoiding the obstacles.";
        yield return new WaitForSeconds(1f);
        objects.SetActive(true);
        backwall.SetActive(true);

    }

    public void End_Game()
    {
        StartCoroutine(Endgame());
    }

    public IEnumerator Endgame()
    {
        backwall.SetActive(false);
        sphereanim.SetTrigger("isend");
        yield return new WaitForSeconds(1);
        playersphere.SetActive(false);

        yield return new WaitForSeconds(5f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "Stress can lead us towards bad decisions because we don't think straight.";
        textanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(6f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "Try your best to ignore any negative thoughts, everything is always in motion.";
        textanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(6f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "Some people say that when a door closes, another door opens.";
        textanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(6f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "Which means that if something ever goes wrong in your life, another opportunity will arise.";
        textanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(6f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "Take care of yourself, and remember to give yourself time to relax!";
        textanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(6f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "That concludes our session.";
        textanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(3f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "Feel free to come back anytime to play again.";
        textanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(4f);
        textanim.SetBool("fadeout", true);
        yield return new WaitForSeconds(0.2f);
        starttext.text = "Goodbye!";
        textanim.SetBool("fadeout", false);

        yield return new WaitForSeconds(4f);
        Levelchangefade.leveltoload = 0;
        fadelevelscript.fadetolevel();

    }
}
