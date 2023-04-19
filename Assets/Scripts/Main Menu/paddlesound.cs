using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class paddlesound : MonoBehaviour
{
    public AudioSource hitballsound;
    public XRBaseController leftcontroller;
    public XRBaseController rightcontroller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pingpongball")
            || other.gameObject.CompareTag("Balls")
            || other.gameObject.CompareTag("Marker")
            || other.gameObject.CompareTag("Cube"))
        {
            if (leftcontroller != null)
            {
                leftcontroller.SendHapticImpulse(0.4f, 0.1f);
            }

            if (rightcontroller != null)
            {
                rightcontroller.SendHapticImpulse(0.4f, 0.1f);
            }

            if (!hitballsound.isPlaying)
            {
                hitballsound.Play();
            }
        }
    }

}
