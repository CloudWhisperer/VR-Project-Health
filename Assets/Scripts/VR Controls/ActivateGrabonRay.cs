using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateGrabonRay : MonoBehaviour
{
    public GameObject LeftGrabRay;
    public GameObject RightGrabRay;

    public XRDirectInteractor leftdirectgrab;
    public XRDirectInteractor rightdirectgrab;

    // Update is called once per frame
    void Update()
    {
        LeftGrabRay.SetActive(leftdirectgrab.interactablesSelected.Count == 0);
        RightGrabRay.SetActive(rightdirectgrab.interactablesSelected.Count == 0);
    }
}
