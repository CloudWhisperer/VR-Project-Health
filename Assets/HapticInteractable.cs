using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public class Haptic
{
    [Range(0, 1)]
    public float Intensity;
    public float Duration;

    public void TriggerHaptic(BaseInteractionEventArgs eventargs)
    {
        if (eventargs.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            TriggerHaptic(controllerInteractor.xrController);
        }
    }

    public void TriggerHaptic(XRBaseController controller)
    {
        if (Intensity > 0)
            controller.SendHapticImpulse(Intensity, Duration);
    }
}

public class HapticInteractable : MonoBehaviour
{
    public Haptic HapticOnActivated;
    public Haptic HapticHoverEnter;
    public Haptic HapticHoverExit;
    public Haptic HapticSelectEnter;
    public Haptic HapticSelectExit;

    // Start is called before the first frame update
    void Start()
    {
        XRBaseInteractable interactable = GetComponent<XRBaseInteractable>();
        interactable.activated.AddListener(HapticOnActivated.TriggerHaptic);
        interactable.hoverEntered.AddListener(HapticHoverEnter.TriggerHaptic);
        interactable.hoverExited.AddListener(HapticHoverExit.TriggerHaptic);
        interactable.selectEntered.AddListener(HapticSelectEnter.TriggerHaptic);
        interactable.selectExited.AddListener(HapticSelectExit.TriggerHaptic);
    }

}
