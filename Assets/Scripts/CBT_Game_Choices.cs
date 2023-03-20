using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CBT_Game_Choices : MonoBehaviour
{
    public DialogueManager dialoguescript;
    public SphereCollider coll1;
    public SphereCollider coll2;

    public Animator anim1;
    public Animator anim2;

    //choices
    public SphereCollider touchCollider;

    public int selectingtimer1;
    public int selectingtimer2;
    public Slider choice1slidervalue;

    public Slider choice2slidervalue;

    private bool skiptext = false;

    private void Start()
    {
        FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter(Collider touchCollider)
    {
        if (touchCollider.CompareTag("Choice1"))
        {
            selectingtimer1 = 0;
            choice1slidervalue.value = selectingtimer1;
        }
        if(touchCollider.CompareTag("Choice2"))
        {
            selectingtimer2 = 0;
            choice2slidervalue.value = selectingtimer2;
        }
    }

    private void OnTriggerStay(Collider touchCollider)
    {
        if (touchCollider.CompareTag("Choice1"))
        {
            selectingtimer1 += 1;
            choice1slidervalue.value = selectingtimer1;
        }
        if (touchCollider.CompareTag("Choice2"))
        {
            selectingtimer2 += 1;
            choice2slidervalue.value = selectingtimer2;
        }
        if (selectingtimer1 > 300)
        {
            StartCoroutine(forwardtext());
        }
        if (selectingtimer2 > 300)
        {
            StartCoroutine(forwardtext());
        }
    }

    private void OnTriggerExit(Collider touchCollider)
    {
        if (touchCollider.CompareTag("Choice1"))
        {
            selectingtimer1 = 0;
            choice1slidervalue.value = selectingtimer1;
        }
        if (touchCollider.CompareTag("Choice2"))
        {
            selectingtimer2 = 0;
            choice2slidervalue.value = selectingtimer2;
        }
    }

    IEnumerator forwardtext()
    {
        selectingtimer1 = 0;
        selectingtimer2 = 0;
        choice1slidervalue.value = selectingtimer1;
        choice2slidervalue.value = selectingtimer2;
        skiptext = true;

        if (skiptext == true)
        {
            coll1.enabled = false;
            coll2.enabled = false;
            anim1.SetBool("isopen", false);
            anim2.SetBool("isopen", false);
            dialoguescript.Displaynextsentence();
        }

        skiptext = false;

        yield return new WaitForSeconds(2f);

        coll1.enabled = true;
        coll2.enabled = true;
    }
}
