using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nametext;
    public TextMeshProUGUI dialoguetext;

    public InputActionProperty ContinueButton;
    private bool canpress = true;

    public Animator Thought_bubble_animator;
    public Animator example1_anim;
    public Animator example2_anim;

    public GameObject Thoughtbubble;
    public GameObject Example1;
    public GameObject Example2;

    public Animator canvasanim;
    private Queue<string> sentences;

    public Animator CBT_charanimator;

    public GameObject choice1;
    public GameObject choice2;
    public TextMeshProUGUI textchoice1;
    public Animator choice1anim;
    public TextMeshProUGUI textchoice2;
    public Animator choice2anim;

    [SerializeField] private float speed_of_text;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

    }

    void Update()
    {
        if (canpress == true && ContinueButton.action.WasPressedThisFrame())
        {
            Displaynextsentence();
        }
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

            case 64:
                canpress = false;
                textchoice1.text = "How come you arent sitting with me?";
                textchoice2.text = "Do you not feel like sitting down?";
                choice1.SetActive(true);
                choice2.SetActive(true);
                choice1anim.SetBool("isopen", true);
                choice2anim.SetBool("isopen", true);
                break;

            case 62:
                CBT_charanimator.SetBool("isexampling", true);
                break;

            case 58:
                CBT_charanimator.SetBool("isintroducing", true);
                break;

            case 56:
                CBT_charanimator.SetBool("isexampling", true);
                canpress = false;
                textchoice1.text = "This sounds like a lot of work...";
                textchoice2.text = "This might be a lot to take in...";
                choice1anim.SetBool("isopen", true);
                choice2anim.SetBool("isopen", true);
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

            case 44:
                canpress = false;
                textchoice1.text = "Because they hate me";
                textchoice2.text = "Because they are trying to avoid me";
                choice1anim.SetBool("isopen", true);
                choice2anim.SetBool("isopen", true);
                break;

            case 41:
                CBT_charanimator.SetBool("isintroducing", true);
                break;

            case 35:
                canpress = false;
                textchoice1.text = "Someone else caught thier attention first";
                textchoice2.text = "They could have been deep in their own thought";
                choice1anim.SetBool("isopen", true);
                choice2anim.SetBool("isopen", true);
                break;

            case 34:
                canpress = true;
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

            case 20:
                canpress = false;
                textchoice1.text = "I understand";
                textchoice2.text = "Thank you!";
                choice1anim.SetBool("isopen", true);
                choice2anim.SetBool("isopen", true);
                break;

            case 19:
                canpress = true;
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
                canpress = false;
                textchoice1.text = "This helped me a lot!";
                textchoice2.text = "Thank you so much!";
                choice1anim.SetBool("isopen", true);
                choice2anim.SetBool("isopen", true);
                break;

            case 4:
                CBT_charanimator.SetBool("isexampling", true);
                break;

            case 1:
                CBT_charanimator.SetBool("iswaving", true);
                canpress = false;
                textchoice1.text = "Goodbye!";
                textchoice2.text = "Thank you again!";
                choice1.SetActive(true);
                choice2.SetActive(true);
                choice1anim.SetBool("isopen", true);
                choice2anim.SetBool("isopen", true);
                break;

            case 0:
                canvasanim.SetBool("isopen", false);
                EndDialogue();
                SceneManager.LoadScene("putscenehere");
                break;



            default:
                CBT_charanimator.SetBool("iswaving", false);
                CBT_charanimator.SetBool("isexampling", false);
                CBT_charanimator.SetBool("isintroducing", false);
                canpress = true;
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
