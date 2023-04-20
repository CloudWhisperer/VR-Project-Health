using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class PhysicalButtons : MonoBehaviour
{
    [Header("-VR Controllers-")]
    [SerializeField]
    private XRBaseController Left_VR_Controller;
    [SerializeField]
    private XRBaseController Right_VR_Controller;

    [Header("-Cooldown timer-")]
    public float Cooldown_timer;
    private bool Is_on_cooldown = false;

    public UnityEvent onPressed, onReleased;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button" && !Is_on_cooldown)
        {
            onPressed?.Invoke();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Button" && !Is_on_cooldown)
        {
            onReleased?.Invoke();
            StartCoroutine(Wait_for_cooldown());
        }
    }

    public void Vibrate_Controllers()
    {
        Left_VR_Controller.SendHapticImpulse(0.4f, 0.1f);
        Right_VR_Controller.SendHapticImpulse(0.4f, 0.1f);
    }

    IEnumerator Wait_for_cooldown()
    {
        Is_on_cooldown = true;
        yield return new WaitForSeconds(Cooldown_timer);
        Is_on_cooldown = false;
    }
}
