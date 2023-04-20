using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public class Haptic
{
    [Range(0, 1)]
    public float Intensity;
    public float Duration;

    public void Trigger_haptic_feedback(BaseInteractionEventArgs eventargs)
    {
        if (eventargs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            Start_vibrating(controllerInteractor.xrController);
        }
    }

    public void Start_vibrating(XRBaseController controller)
    {
        if (Intensity > 0)
            controller.SendHapticImpulse(Intensity, Duration);
    }
}

public class HapticControls : MonoBehaviour
{
    //events that i can use on each object to enable vibrations
    public Haptic HapticOnActivated;
    public Haptic HapticHoverEnter;
    public Haptic HapticHoverExit;
    public Haptic HapticSelectEnter;
    public Haptic HapticSelectExit;

    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.activated.AddListener(HapticOnActivated.Trigger_haptic_feedback);
        interactable.hoverEntered.AddListener(HapticHoverEnter.Trigger_haptic_feedback);
        interactable.hoverExited.AddListener(HapticHoverExit.Trigger_haptic_feedback);
        interactable.selectEntered.AddListener(HapticSelectEnter.Trigger_haptic_feedback);
        interactable.selectExited.AddListener(HapticSelectExit.Trigger_haptic_feedback);
    }

}
