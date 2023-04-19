using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubesounds : MonoBehaviour
{
    public AudioSource cubesound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Table")
            || other.gameObject.CompareTag("Cube"))
        {
            if (!cubesound.isPlaying)
            {
                cubesound.Play();
            }
        }
    }
}
