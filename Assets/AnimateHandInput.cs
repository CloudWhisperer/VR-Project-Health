using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandInput : MonoBehaviour
{
    public InputActionProperty PinchAnimationAction;
    public InputActionProperty GripAnimationAction;
    public Animator HandAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float TriggerValue = PinchAnimationAction.action.ReadValue<float>();
        HandAnim.SetFloat("Trigger", TriggerValue);

        float GripValue = GripAnimationAction.action.ReadValue<float>();
        HandAnim.SetFloat("Grip", GripValue);
    }
}
