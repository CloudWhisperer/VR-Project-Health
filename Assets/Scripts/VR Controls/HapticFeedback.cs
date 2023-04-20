using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public class Haptic
{
    [Range(0, 1)]
    public float Intensity;
    public float Duration;

    public void Check_VR_controller(BaseInteractionEventArgs eventargs)
    {
        if (eventargs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            Trigger_haptic_vibration(controllerInteractor.xrController);
        }
    }

    public void Trigger_haptic_vibration(XRBaseController controller)
    {
        if (Intensity > 0)
            controller.SendHapticImpulse(Intensity, Duration);
    }
}

public class HapticFeedback : MonoBehaviour
{
    //events that i can use on each object
    public Haptic HapticOnActivated;
    public Haptic HapticHoverEnter;
    public Haptic HapticHoverExit;
    public Haptic HapticSelectEnter;
    public Haptic HapticSelectExit;

    // Start is called before the first frame update
    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.activated.AddListener(HapticOnActivated.Check_VR_controller);
        interactable.hoverEntered.AddListener(HapticHoverEnter.Check_VR_controller);
        interactable.hoverExited.AddListener(HapticHoverExit.Check_VR_controller);
        interactable.selectEntered.AddListener(HapticSelectEnter.Check_VR_controller);
        interactable.selectExited.AddListener(HapticSelectExit.Check_VR_controller);
    }

}
