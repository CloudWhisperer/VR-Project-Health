using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whatisbeinggrabbed : MonoBehaviour
{
    public SphereCollider grabCollider;
    public Animator handanimator;

    private void OnTriggerEnter(Collider grabCollider)
    {
        if(grabCollider.CompareTag("Cube"))
        {
            handanimator.SetBool("iscube", true);
        }
    }

    private void OnTriggerExit(Collider grabCollider)
    {
        if (grabCollider.CompareTag("Cube"))
        {
            handanimator.SetBool("iscube", false);
        }
    }



}
