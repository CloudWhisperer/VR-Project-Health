using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPlane : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private float speed = -0.4f;
    [SerializeField] private AudioSource planesound;

    private Vector3 velocity;

    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        body.AddForce(0, speed, 0);
        velocity = body.velocity;

        if (velocity.x >= 4)
        {
            if (!planesound.isPlaying)
            {
                planesound.Play();
            }
        }
        if(velocity.y >= 4)
        {
            if(!planesound.isPlaying)
            {
                planesound.Play();
            }

        }
        if(velocity.z >= 4)
        {
            if (!planesound.isPlaying)
            {
                planesound.Play();
            }
        }

        if (velocity.x <= -4)
        {
            if (!planesound.isPlaying)
            {
                planesound.Play();
            }
        }
        if (velocity.y <= -4)
        {
            if (!planesound.isPlaying)
            {
                planesound.Play();
            }

        }
        if (velocity.z <= -4)
        {
            if (!planesound.isPlaying)
            {
                planesound.Play();
            }
        }
    }
}
