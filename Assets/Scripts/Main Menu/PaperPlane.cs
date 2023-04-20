using UnityEngine;

public class PaperPlane : MonoBehaviour
{
    [SerializeField]
    private Rigidbody Paper_plane_rigidbody;
    [SerializeField]
    private float Speed = -0.4f;
    [SerializeField]
    private AudioSource Plane_sound_effect;

    private Vector3 Velocity;

    // Start is called before the first frame update
    private void Start()
    {
        Paper_plane_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        Paper_plane_rigidbody.AddForce(0, Speed, 0);
        Velocity = Paper_plane_rigidbody.velocity;

        if (Velocity.x >= 4 ||
            Velocity.y >= 4 ||
            Velocity.z >= 4 ||
            Velocity.x <= -4 ||
            Velocity.y <= -4 ||
            Velocity.z <= -4)
        {
            Play_sound_effect();
        }

        //if (Velocity.y >= 4)
        //{
        //    Play_sound_effect();
        //}

        //if (Velocity.z >= 4)
        //{
        //    Play_sound_effect();
        //}

        //if (Velocity.x <= -4)
        //{
        //    Play_sound_effect();
        //}

        //if (Velocity.y <= -4)
        //{
        //    Play_sound_effect();
        //}

        //if (Velocity.z <= -4)
        //{
        //    Play_sound_effect();
        //}
    }

    private void Play_sound_effect()
    {
        if (!Plane_sound_effect.isPlaying)
        {
            Plane_sound_effect.Play();
        }
    }
}
