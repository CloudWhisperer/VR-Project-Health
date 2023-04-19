using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class CBT_Game_Choices : MonoBehaviour
{
    [Header("-VR Controllers-")]
    [SerializeField]
    private XRBaseController Right_VR_controller;
    [SerializeField]
    private XRBaseController Left_VR_controller;

    [Header("-Script-")]
    [SerializeField]
    private DialogueManager Dialogue_script;

    [Header("-Choice Colliders-")]
    [SerializeField]
    private SphereCollider Choice_1_collider;
    [SerializeField]
    private SphereCollider Choice_2_collider;

    [Header("-Choice animators-")]
    [SerializeField]
    private Animator Choice_1_animator;
    [SerializeField]
    private Animator Choice2_animator;

    [Header("-Choice Sound effects-")]
    [SerializeField]
    private AudioSource Choice_selection_sound_effect;

    //choices
    [Header("-VR hand collider-")]
    [SerializeField]
    private SphereCollider VR_Hand_collider;

    private int Choice_1_selection_value;
    private int Choice_2_selection_value;

    [Header("Choice sliders")]
    [SerializeField]
    private Slider Choice_1_slider;
    [SerializeField]
    public Slider Choice_2_slider;

    private bool Can_continue_text = false;

    private void Start()
    {
        FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter(Collider touchCollider)
    {
        if (touchCollider.CompareTag("Choice1"))
        {
            Choice_1_selection_value = 0;
            Choice_1_slider.value = Choice_1_selection_value;
        }
        if (touchCollider.CompareTag("Choice2"))
        {
            Choice_2_selection_value = 0;
            Choice_2_slider.value = Choice_2_selection_value;
        }
    }

    private void OnTriggerStay(Collider touchCollider)
    {
        if (touchCollider.CompareTag("Choice1"))
        {
            Right_VR_controller.SendHapticImpulse(0.1f, 0.1f);
            Left_VR_controller.SendHapticImpulse(0.1f, 0.1f);
            Choice_1_selection_value += 1;
            Choice_1_slider.value = Choice_1_selection_value;
        }
        if (touchCollider.CompareTag("Choice2"))
        {
            Right_VR_controller.SendHapticImpulse(0.1f, 0.1f);
            Left_VR_controller.SendHapticImpulse(0.1f, 0.1f);
            Choice_2_selection_value += 1;
            Choice_2_slider.value = Choice_2_selection_value;
        }
        if (Choice_1_selection_value > 300)
        {
            StartCoroutine(forwardtext());
        }
        if (Choice_2_selection_value > 300)
        {
            StartCoroutine(forwardtext());
        }
    }

    private void OnTriggerExit(Collider touchCollider)
    {
        if (touchCollider.CompareTag("Choice1"))
        {
            Choice_1_selection_value = 0;
            Choice_1_slider.value = Choice_1_selection_value;
        }
        if (touchCollider.CompareTag("Choice2"))
        {
            Choice_2_selection_value = 0;
            Choice_2_slider.value = Choice_2_selection_value;
        }
    }

    IEnumerator forwardtext()
    {
        Choice_selection_sound_effect.Play();
        Choice_1_selection_value = 0;
        Choice_2_selection_value = 0;
        Choice_1_slider.value = Choice_1_selection_value;
        Choice_2_slider.value = Choice_2_selection_value;
        Can_continue_text = true;

        if (Can_continue_text == true)
        {
            Choice_1_collider.enabled = false;
            Choice_2_collider.enabled = false;
            Choice_1_animator.SetBool("isopen", false);
            Choice2_animator.SetBool("isopen", false);
            Dialogue_script.Display_next_sentence();
        }

        Can_continue_text = false;

        yield return new WaitForSeconds(2f);

        Choice_1_collider.enabled = true;
        Choice_2_collider.enabled = true;
    }
}
