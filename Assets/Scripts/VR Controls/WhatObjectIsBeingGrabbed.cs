using UnityEngine;

public class WhatObjectIsBeingGrabbed : MonoBehaviour
{
    [SerializeField]
    private SphereCollider Hand_collider;
    [SerializeField]
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
