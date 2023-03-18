using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nametext;
    public TextMeshProUGUI dialoguetext;

    public Animator Thought_bubble_animator;
    public Animator example1_anim;
    public Animator example2_anim;

    public GameObject Thoughtbubble;
    public GameObject Example1;
    public GameObject Example2;

    public Animator canvasanim;
    private Queue<string> sentences;

    public Animator CBT_charanimator;

    [SerializeField] private float speed_of_text;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void startDialogue(Dialogue dialogue)
    {
        canvasanim.SetBool("isopen", true);

        nametext.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        Displaynextsentence();

    }

    public void Displaynextsentence()
    {
        if (sentences.Count == 0)
        {
            canvasanim.SetBool("isopen", false);
            EndDialogue();
            return;
        }

        switch (sentences.Count) //case numbers are dependant on how many sentences are left, remember it
                                 //just minus the total number of sentences with the sentence number you want
                                 //to add onto.
                                 //also plus 1 after because its the text before
        {
            case 68:
                CBT_charanimator.SetBool("iswaving", true);
                break;

            case 67:
                CBT_charanimator.SetBool("iswaving", false);
                CBT_charanimator.SetBool("isintroducing", true);
                break;

            case 62:
                CBT_charanimator.SetBool("isexampling", true);
                break;

            case 58:
                CBT_charanimator.SetBool("isintroducing", true);
                break;

            case 56:
                CBT_charanimator.SetBool("isexampling", true);
                break;

            case 51:
                CBT_charanimator.SetBool("iswaving", true);
                break;

            case 47:
                CBT_charanimator.SetBool("isintroducing", true);
                break;

            case 46:
                CBT_charanimator.SetBool("isexampling", true);
                Thoughtbubble.SetActive(true);
                Thought_bubble_animator.SetBool("isshowing", true);
                break;

            case 45:
                CBT_charanimator.SetBool("isexampling", true);
                break;

            case 41:
                CBT_charanimator.SetBool("isintroducing", true);
                break;

            case 34:
                CBT_charanimator.SetBool("isexampling", true);
                break;

            case 31:
                Thought_bubble_animator.SetBool("isshowing", false);
                break;

            case 29:
                CBT_charanimator.SetBool("isintroducing", true);
                break;

            case 22:
                CBT_charanimator.SetBool("isintroducing", true);
                Example1.SetActive(true);
                break;

            case 19:
                example1_anim.SetBool("isopen", false);
                break;

            case 17:
                CBT_charanimator.SetBool("isexampling", true);
                break;

            case 16:
                CBT_charanimator.SetBool("isexampling", false);
                CBT_charanimator.SetBool("isintroducing", true);
                break;

            case 10:
                CBT_charanimator.SetBool("isexampling", true);
                Example2.SetActive(true);
                break;

            case 7:
                CBT_charanimator.SetBool("isintroducing", true);
                example2_anim.SetBool("isopen", false);
                break;

            case 4:
                CBT_charanimator.SetBool("isexampling", true);
                break;

            case 1:
                CBT_charanimator.SetBool("iswaving", true);
                break;

            default:
                CBT_charanimator.SetBool("iswaving", false);
                CBT_charanimator.SetBool("isexampling", false);
                CBT_charanimator.SetBool("isintroducing", false);
                break;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(typesentence(sentence));
    }

    IEnumerator typesentence(string sentence)
    {
        dialoguetext.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialoguetext.text += letter;
            yield return new WaitForSeconds(speed_of_text);
        }
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");
    }
}
