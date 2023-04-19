using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class vrbutton2 : MonoBehaviour
{
    public float deadtime;
    private bool deadtimeactivated = false;

    public XRBaseController leftcontroller;
    public XRBaseController rightcontroller;

    public UnityEvent onPressed, onReleased;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button" && !deadtimeactivated)
        {
            onPressed?.Invoke();
            //Debug.Log("press button");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Button" && !deadtimeactivated)
        {
            onReleased?.Invoke();
            //Debug.Log("RELEASE button");
            StartCoroutine(waitfordeadtime());
        }
    }

    public void vibratebutton()
    {
        leftcontroller.SendHapticImpulse(0.4f, 0.1f);
        rightcontroller.SendHapticImpulse(0.4f, 0.1f);
    }

    IEnumerator waitfordeadtime()
    {
        deadtimeactivated = true;
        yield return new WaitForSeconds(deadtime);
        deadtimeactivated = false;
    }
}
