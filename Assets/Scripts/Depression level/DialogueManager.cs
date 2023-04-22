using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DialogueManager : MonoBehaviour
{
    LevelChangeFade Fade_level_script;

    [Header("-Tutorial images and animations-")]
    [SerializeField]
    private GameObject Grabbing_object_tutorial;
    [SerializeField]
    private GameObject Dialogue_advancement_tutorial;
    [SerializeField]
    private GameObject Selecting_choice_tutorial;
    [SerializeField]
    private Animator Grabbing_object_tutorial_animator;
    [SerializeField]
    private Animator Dialogue_advancement_tutorial_animator;
    [SerializeField]
    private Animator Selecting_choice_tutorial_animator;

    [Header("-VR Controllers-")]
    [SerializeField]
    private XRBaseController Right_VR_controller;
    [SerializeField]
    private XRBaseController Left_VR_controller;

    [Header("-Character name and dialogue-")]
    [SerializeField]
    private TextMeshProUGUI Character_name_text;
    [SerializeField]
    private TextMeshProUGUI Character_dialogue_text;

    [SerializeField]
    public InputActionProperty ContinueButton;
    private bool Can_press_continue_button = true;

    [Header("-Audio-")]
    [SerializeField]
    private AudioSource Proceed_text_sound;
    [SerializeField]
    private AudioSource Choice_1_appear_sound,
                        Choice_2_appear_sound,
                        Thought_bubble_appear_audio,
                        Thought_bubble_dissapear_audio,
                        Character_waving_audio,
                        Character_introducting_audio,
                        Character_showing_example_audio;

    //Thought bubble that shows up during the conversation
    //Example 1 and 2 is the pieces of paper that appear during conversations
    [Header("-Thought bubble & Examples-")]
    [SerializeField]
    private GameObject Thought_bubble;
    [SerializeField]
    private GameObject Example1;
    [SerializeField]
    private GameObject Example2;
    [SerializeField]
    private Animator Thought_bubble_animator;
    [SerializeField]
    private Animator Example_1_animator;
    [SerializeField]
    private Animator Example_2_animator;

    [Header("-Canvas-")]
    [SerializeField]
    private Animator Canvas_animator;

    private Queue<string> Sentences;

    [Header("-Character Animator-")]
    [SerializeField]
    private Animator CBT_charanimator;

    [Header("-Choice bubbles & text-")]
    [SerializeField]
    public GameObject Choice_1_bubble;
    [SerializeField]
    public GameObject Choice_2_bubble;
    [SerializeField]
    public TextMeshProUGUI Choice_1_text;
    [SerializeField]
    public TextMeshProUGUI Choice_2_text;
    [SerializeField]
    public Animator Choice_1_bubble_animator;
    [SerializeField]
    public Animator Choice_2_bubble_animator;

    [SerializeField]
    private float Speed_of_text;

    // Start is called before the first frame update
    private void Start()
    {
        Sentences = new Queue<string>();
        Fade_level_script = GameObject.FindGameObjectWithTag("Fade").GetComponent<LevelChangeFade>();
    }

    void Update()
    {
        if (Can_press_continue_button == true && ContinueButton.action.WasPressedThisFrame())
        {
            Display_next_sentence();
            Right_VR_controller.SendHapticImpulse(0.1f, 0.1f);
            Left_VR_controller.SendHapticImpulse(0.1f, 0.1f);
        }
    }

    public void Begin_dialogue(Dialogue dialogue)
    {
        Canvas_animator.SetBool("isopen", true);
        Dialogue_advancement_tutorial.SetActive(true);
        Dialogue_advancement_tutorial_animator.SetBool("fadein", true);

        Character_name_text.text = dialogue.name;

        //clears the queue
        Sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            //queues up the sentences
            Sentences.Enqueue(sentence);
        }

        Display_next_sentence();

    }

    public void Display_next_sentence()
    {
        Proceed_text_sound.Play();

        if (Sentences.Count == 0)
        {
            Canvas_animator.SetBool("isopen", false);
            End_dialogue_and_game();
            return;
        }

        //checks if the sentence is one of the numbers, if it is it will trigger something in game
        switch (Sentences.Count) //case numbers are dependant on how many sentences are left.
                                 //just minus the total number of Sentences with the sentence number you want
                                 //to add onto.
                                 //also plus 1 after because its the text before
        {
            case 68:
                Event_1_beginning();
                break;

            case 67:
                Event_2_introductions();
                break;

            case 64:
                Event_3_first_interaction();
                break;

            case 62:
                Event_4();
                break;

            case 58:
                Event_5();
                break;

            case 56:
                Event_6_player_overwhelmed();
                break;

            case 51:
                Event_7();
                break;

            case 47:
                Event_8();
                break;

            case 46:
                Event_9_thought_bubble_appear();
                break;

            case 45:
                Event_10();
                break;

            case 44:
                Event_11_player_response_to_lesson_1();
                break;

            case 41:
                Event_12();
                break;

            case 35:
                Event_13_player_understanding_first_lesson();
                break;

            case 34:
                Event_14();
                break;

            case 31:
                Event_15();
                break;

            case 29:
                Event_16();
                break;

            case 22:
                Event_17_showing_example_1();
                break;

            case 20:
                Event_18_player_understanding();
                break;

            case 19:
                Event_19_disabling_example_1();
                break;

            case 17:
                Event_20();
                break;

            case 16:
                Event_21();
                break;

            case 10:
                Event_22_showing_second_example();
                break;

            case 7:
                Event_23_player_saying_thanks();
                break;

            case 4:
                Event_24();
                break;

            case 1:
                Event_25_saying_goodbye();
                break;

            case 0:
                Event_26_Ending();
                break;

            //reset values and parameters when not in a special event
            default:
                Reset_events();
                break;
        }

        //will remove the sentence from the queue.
        //and stop the letter by letter typing.
        //and type out the next sentence letter by letter.
        string sentence = Sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(Type_out_sentence(sentence));
    }

    private void Reset_events()
    {
        CBT_charanimator.SetBool("iswaving", false);
        CBT_charanimator.SetBool("isexampling", false);
        CBT_charanimator.SetBool("isintroducing", false);
        Can_press_continue_button = true;
        if (Selecting_choice_tutorial_animator.isActiveAndEnabled)
        {
            Selecting_choice_tutorial_animator.SetBool("fadein", false);
        }
    }

    private void Event_26_Ending()
    {
        Canvas_animator.SetBool("isopen", false);
        End_dialogue_and_game();
    }

    private void Event_25_saying_goodbye()
    {
        CBT_charanimator.SetBool("iswaving", true);
        Character_waving_audio.Play();
        Can_press_continue_button = false;
        Selecting_choice_tutorial_animator.SetBool("fadein", true);
        Choice_1_text.text = "Goodbye!";
        Choice_2_text.text = "Thank you again!";
        Choice_1_bubble.SetActive(true);
        Choice_2_bubble.SetActive(true);
        Choice_1_bubble_animator.SetBool("isopen", true);
        Choice_2_bubble_animator.SetBool("isopen", true);
        Choice_1_appear_sound.Play();
        Choice_2_appear_sound.PlayDelayed(1f);
    }

    private void Event_24()
    {
        CBT_charanimator.SetBool("isexampling", true);
        Character_showing_example_audio.Play();
    }

    private void Event_23_player_saying_thanks()
    {
        CBT_charanimator.SetBool("isintroducing", true);
        Character_introducting_audio.Play();
        Example_2_animator.SetBool("isopen", false);
        Grabbing_object_tutorial_animator.SetBool("fadein", false);
        Can_press_continue_button = false;
        Selecting_choice_tutorial_animator.SetBool("fadein", true);
        Choice_1_text.text = "This helped me a lot!";
        Choice_2_text.text = "Thank you so much!";
        Choice_1_bubble_animator.SetBool("isopen", true);
        Choice_2_bubble_animator.SetBool("isopen", true);
        Choice_1_appear_sound.Play();
        Choice_2_appear_sound.PlayDelayed(1f);
    }

    private void Event_22_showing_second_example()
    {
        CBT_charanimator.SetBool("isexampling", true);
        Character_showing_example_audio.Play();
        Example2.SetActive(true);
        Grabbing_object_tutorial_animator.SetBool("fadein", true);
    }

    private void Event_21()
    {
        CBT_charanimator.SetBool("isexampling", false);
        CBT_charanimator.SetBool("isintroducing", true);
        Character_introducting_audio.Play();
    }

    private void Event_20()
    {
        CBT_charanimator.SetBool("isexampling", true);
        Character_showing_example_audio.Play();
    }

    private void Event_19_disabling_example_1()
    {
        Can_press_continue_button = true;
        Example_1_animator.SetBool("isopen", false);
        Grabbing_object_tutorial_animator.SetBool("fadein", false);
    }

    private void Event_18_player_understanding()
    {
        Can_press_continue_button = false;
        Selecting_choice_tutorial_animator.SetBool("fadein", true);
        Choice_1_text.text = "I understand";
        Choice_2_text.text = "Thank you!";
        Choice_1_bubble_animator.SetBool("isopen", true);
        Choice_2_bubble_animator.SetBool("isopen", true);
        Choice_1_appear_sound.Play();
        Choice_2_appear_sound.PlayDelayed(1f);
    }

    private void Event_17_showing_example_1()
    {
        CBT_charanimator.SetBool("isintroducing", true);
        Character_introducting_audio.Play();
        Example1.SetActive(true);
        Grabbing_object_tutorial.SetActive(true);
        Grabbing_object_tutorial_animator.SetBool("fadein", true);
    }

    private void Event_16()
    {
        CBT_charanimator.SetBool("isintroducing", true);
        Character_introducting_audio.Play();
    }

    private void Event_15()
    {
        Thought_bubble_animator.SetBool("isshowing", false);
        Thought_bubble_dissapear_audio.Play();
    }

    private void Event_14()
    {
        Can_press_continue_button = true;
        CBT_charanimator.SetBool("isexampling", true);
        Character_showing_example_audio.Play();
    }

    private void Event_13_player_understanding_first_lesson()
    {
        Can_press_continue_button = false;
        Selecting_choice_tutorial_animator.SetBool("fadein", true);
        Choice_1_text.text = "Someone else caught their attention first";
        Choice_2_text.text = "They could have been deep in their own thought";
        Choice_1_bubble_animator.SetBool("isopen", true);
        Choice_2_bubble_animator.SetBool("isopen", true);
        Choice_1_appear_sound.Play();
        Choice_2_appear_sound.PlayDelayed(1f);
    }

    private void Event_12()
    {
        CBT_charanimator.SetBool("isintroducing", true);
        Character_introducting_audio.Play();
    }

    private void Event_11_player_response_to_lesson_1()
    {
        Can_press_continue_button = false;
        Selecting_choice_tutorial_animator.SetBool("fadein", true);
        Choice_1_text.text = "Because they hate me";
        Choice_2_text.text = "Because they are trying to avoid me";
        Choice_1_bubble_animator.SetBool("isopen", true);
        Choice_2_bubble_animator.SetBool("isopen", true);
        Choice_1_appear_sound.Play();
        Choice_2_appear_sound.PlayDelayed(1f);
    }

    private void Event_10()
    {
        CBT_charanimator.SetBool("isexampling", true);
        Character_showing_example_audio.Play();
    }

    private void Event_9_thought_bubble_appear()
    {
        CBT_charanimator.SetBool("isexampling", true);
        Character_showing_example_audio.Play();
        Thought_bubble.SetActive(true);
        Thought_bubble_appear_audio.Play();
        Thought_bubble_animator.SetBool("isshowing", true);
    }

    private void Event_8()
    {
        CBT_charanimator.SetBool("isintroducing", true);
        Character_introducting_audio.Play();
    }

    private void Event_7()
    {
        CBT_charanimator.SetBool("iswaving", true);
        Character_waving_audio.Play();
    }

    private void Event_6_player_overwhelmed()
    {
        CBT_charanimator.SetBool("isexampling", true);
        Character_showing_example_audio.Play();
        Can_press_continue_button = false;
        Selecting_choice_tutorial_animator.SetBool("fadein", true);
        Choice_1_text.text = "This sounds like a lot of work...";
        Choice_2_text.text = "This might be a lot to take in...";
        Choice_1_bubble_animator.SetBool("isopen", true);
        Choice_2_bubble_animator.SetBool("isopen", true);
        Choice_1_appear_sound.Play();
        Choice_2_appear_sound.PlayDelayed(1f);
    }

    private void Event_5()
    {
        CBT_charanimator.SetBool("isintroducing", true);
        Character_introducting_audio.Play();
    }

    private void Event_4()
    {
        CBT_charanimator.SetBool("isexampling", true);
        Character_showing_example_audio.Play();
    }

    private void Event_3_first_interaction()
    {
        Dialogue_advancement_tutorial_animator.SetBool("fadein", false);
        Selecting_choice_tutorial.SetActive(true);
        Selecting_choice_tutorial_animator.SetBool("fadein", true);
        Can_press_continue_button = false;
        Choice_1_text.text = "How come you aren't sitting with me?";
        Choice_2_text.text = "Do you not feel like sitting down?";
        Choice_1_bubble.SetActive(true);
        Choice_2_bubble.SetActive(true);
        Choice_1_bubble_animator.SetBool("isopen", true);
        Choice_2_bubble_animator.SetBool("isopen", true);
        Choice_1_appear_sound.Play();
        Choice_2_appear_sound.PlayDelayed(1f);
    }

    private void Event_2_introductions()
    {
        CBT_charanimator.SetBool("iswaving", false);
        CBT_charanimator.SetBool("isintroducing", true);
        Character_introducting_audio.Play();
    }

    private void Event_1_beginning()
    {
        CBT_charanimator.SetBool("iswaving", true);
        Character_waving_audio.Play();
    }

    IEnumerator Type_out_sentence(string sentence)
    {
        Character_dialogue_text.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            Character_dialogue_text.text += letter;
            yield return new WaitForSeconds(Speed_of_text);
        }
    }

    void End_dialogue_and_game()
    {
        Debug.Log("End of conversation");
        LevelChangeFade.What_level_number_to_load = 1;
        Fade_level_script.Fade_to_level();

    }
}
