using System.Collections;
using TMPro;
using UnityEngine;

public class cointouchminigamescorescript : MonoBehaviour
{
    public GameObject objects;
    public GameObject tutorialobjects;
    public GameObject backwall;
    public TextMeshProUGUI starttext;

    public static int scorecounter;
    public static int losecounter;

    private void Start()
    {
        //StartCoroutine(begingame());
    }

    private void Update()
    {
        Debug.Log(scorecounter);
        if (scorecounter < 0)
        {
            scorecounter = 0;
        }
    }

    IEnumerator begingame()
    {
        starttext.text = "Welcome";
        yield return new WaitForSeconds(2f);
        starttext.text = "Collect the coins and avoid the obstacles";
        yield return new WaitForSeconds(4f);
        starttext.text = "Use your head to control the movement of the ball";
        yield return new WaitForSeconds(4f);
        starttext.text = "lets start of simple, try to collect these 3 coins";
        yield return new WaitForSeconds(4f);
        tutorialobjects.SetActive(true);
        yield return new WaitForSeconds(7f);
        starttext.text = "Now lets add some obstacles in the way";
        yield return new WaitForSeconds(4f);
        starttext.text = "Try to collect these 5 coins whilst avoiding the obstacles";
        yield return new WaitForSeconds(4f);
        objects.SetActive(true);
        yield return new WaitForSeconds(10f);
        starttext.text = "very good, continue onwardsss";
        objects.SetActive(true);
        backwall.SetActive(true);

    }

}
