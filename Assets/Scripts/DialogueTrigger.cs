using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void triggerdialogue()
    {
        FindObjectOfType<DialogueManager>().startDialogue(dialogue);
    }

}
