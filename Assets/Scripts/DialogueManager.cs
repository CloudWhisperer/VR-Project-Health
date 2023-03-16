using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nametext;
    public TextMeshProUGUI dialoguetext;

    public Animator canvasanim;
    private Queue<string> sentences;

    public Animator CBT_charanimator;

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

        switch(sentences.Count) //case numbers are dependant on how many sentences are left, remember it
            //just minus the total number of sentences with the sentence number you want to add onto
            //also plus 1 after because its the text before
        {
            case 8:
                CBT_charanimator.SetBool("isintroducing", true);
                    break;

            case 6:
                CBT_charanimator.SetBool("isexampling", true);
                    break;
            case 5:
                CBT_charanimator.SetBool("isexampling", false);
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
            yield return null;
        }
    }

    void EndDialogue()
    {
        Debug.Log("end of convo");
    }
}
