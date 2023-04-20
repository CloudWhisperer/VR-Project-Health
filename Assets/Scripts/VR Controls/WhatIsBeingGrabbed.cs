using UnityEngine;

public class WhatIsBeingGrabbed : MonoBehaviour
{
    [Header("-Hands-")]
    [SerializeField]
    private SphereCollider Hand_collider;
    private Animator Hand_animator;

    private void OnTriggerEnter(Collider grabCollider)
    {
        if (grabCollider.CompareTag("Cube"))
        {
            Hand_animator.SetBool("iscube", true);
        }
        if (grabCollider.CompareTag("Plane"))
        {
            Hand_animator.SetBool("isplane", true);
        }
    }

    private void OnTriggerExit(Collider grabCollider)
    {
        if (grabCollider.CompareTag("Cube"))
        {
            Hand_animator.SetBool("iscube", false);
        }
        if (grabCollider.CompareTag("Plane"))
        {
            Hand_animator.SetBool("isplane", false);
        }
    }
}
