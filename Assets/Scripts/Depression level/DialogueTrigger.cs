using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void Start()
    {
        triggerdialogue();
    }
    public void triggerdialogue()
    {
        FindObjectOfType<DialogueManager>().Begin_dialogue(dialogue);
    }

}
