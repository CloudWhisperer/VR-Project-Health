using UnityEngine;

public class CubeSoundEffect : MonoBehaviour
{
    [SerializeField]
    private AudioSource Cube_sound_effect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Table")
            || other.gameObject.CompareTag("Cube"))
        {
            if (!Cube_sound_effect.isPlaying)
            {
                Cube_sound_effect.Play();
            }
        }
    }
}
