using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PingPongPaddleSoundEffect : MonoBehaviour
{
    [Header("-VR Controllers-")]
    [SerializeField]
    private XRBaseController Left_VR_Controller;
    [SerializeField]
    private XRBaseController Right_VR_Controller;

    [Header("-Sound effect-")]
    [SerializeField]
    private AudioSource Hit_object_sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pingpongball")
            || other.gameObject.CompareTag("Balls")
            || other.gameObject.CompareTag("Marker")
            || other.gameObject.CompareTag("Cube"))
        {
            if (Left_VR_Controller != null)
            {
                Left_VR_Controller.SendHapticImpulse(0.4f, 0.1f);
            }

            if (Right_VR_Controller != null)
            {
                Right_VR_Controller.SendHapticImpulse(0.4f, 0.1f);
            }

            if (!Hit_object_sound.isPlaying)
            {
                Hit_object_sound.Play();
            }
        }
    }
}
