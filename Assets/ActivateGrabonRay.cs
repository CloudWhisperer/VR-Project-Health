using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateGrabonRay : MonoBehaviour
{

    public GameObject LeftGrabRay;
    public GameObject RightGrabRay;

    public XRDirectInteractor leftdirectgrab;
    public XRDirectInteractor rightdirectgrab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LeftGrabRay.SetActive(leftdirectgrab.interactablesSelected.Count == 0);
        RightGrabRay.SetActive(rightdirectgrab.interactablesSelected.Count == 0);
    }
}
