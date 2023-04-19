using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRgrabinteractabletwoattach : XRGrabInteractable
{
    public Transform leftattacktransform;
    public Transform rightattacktransform;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag("Left Hand"))
        {
            attachTransform = leftattacktransform;
        }
        else if (args.interactableObject.transform.CompareTag("Right Hand"))
        {
            attachTransform = rightattacktransform;
        }
         
        base.OnSelectEntered(args);
    }

}
