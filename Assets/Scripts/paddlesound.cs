using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddlesound : MonoBehaviour
{
    public AudioSource hitballsound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Pingpongball")
            || other.gameObject.CompareTag("Balls")
            || other.gameObject.CompareTag("Marker")
            || other.gameObject.CompareTag("Cube"))
        {
            if (!hitballsound.isPlaying)
            {
                hitballsound.Play();
            }
        }
    }

}
