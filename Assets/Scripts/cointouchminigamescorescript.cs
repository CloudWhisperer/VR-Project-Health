using System.Collections;
using TMPro;
using UnityEngine;

public class cointouchminigamescorescript : MonoBehaviour
{
    public GameObject playersphere;

    public GameObject objects;
    public GameObject tutorialobjects;
    public GameObject backwall;
    public TextMeshProUGUI starttext;

    public ParticleSystem breathin;
    public ParticleSystem breathout;

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
    }

    IEnumerator beginningtext()
    {
        //beggining text
        starttext.text = "Welcome!";
        yield return new WaitForSeconds(4f);
        starttext.text = "Life can be stressful sometimes.";
        yield return new WaitForSeconds(3f);
        starttext.text = "That's why it is very important that we take breaks and relax our minds.";
        yield return new WaitForSeconds(4f);
        starttext.text = "There are multiple ways to do this.";
        yield return new WaitForSeconds(3f);
        starttext.text = "And we will do it together.";
        yield return new WaitForSeconds(4f);
        starttext.text = "Let's begin by taking a few deep breaths.";
        yield return new WaitForSeconds(4f);
        yield return StartCoroutine(BreathingexerciseStart());
    }
    IEnumerator BreathingexerciseStart()
    {
        //start breathing part  //1
        starttext.text = "Breath in.";
        yield return new WaitForSeconds(1f);
        breathin.Play();
        yield return new WaitForSeconds(3f);
        breathin.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        starttext.text = "Hold your breath...";
        yield return new WaitForSeconds(2f);
        starttext.text = "Breath out...";
        yield return new WaitForSeconds(1f);
        breathout.Play();
        yield return new WaitForSeconds(3f);
        breathout.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        yield return new WaitForSeconds(1f);
        starttext.text = "Try to match your breathing with the flow";
        yield return StartCoroutine(Breathingexercise());
    }

    IEnumerator Breathingexercise()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(3f);
            breathin.Play();
            yield return new WaitForSeconds(3f);
            breathin.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            yield return new WaitForSeconds(2f);
            breathout.Play();
            yield return new WaitForSeconds(3f);
            breathout.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }

        yield return new WaitForSeconds(2f);
        StartCoroutine(Coingame());
    }

    IEnumerator Coingame()
    {
        playersphere.SetActive(true);
        starttext.text = "Now lets play a short game.";
        yield return new WaitForSeconds(3f);
        starttext.text = "This game is designed to keep you into a flow state";
        yield return new WaitForSeconds(3f);
        starttext.text = "You control the sphere in front of you";
        yield return new WaitForSeconds(3f);
        starttext.text = "Use the movement of your head to touch the rotating coins";
        yield return new WaitForSeconds(4f);
        tutorialobjects.SetActive(true);
        yield return new WaitForSeconds(7f);
        starttext.text = "Now lets add some obstacles in the way";
        yield return new WaitForSeconds(4f);
        starttext.text = "Now try to touch the rotating coins while avoiding the obstacles";
        yield return new WaitForSeconds(4f);
        objects.SetActive(true);
        backwall.SetActive(true);

    }
}
