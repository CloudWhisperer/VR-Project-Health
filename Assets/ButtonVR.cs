using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{

    public GameObject button;
    public UnityEvent OnPress;
    public UnityEvent Onrelease;
    GameObject presser;
    //AudioSource Sfx;
    bool ispressed;

    // Start is called before the first frame update
    void Start()
    {
        //Sfx = GetComponent<AudioSource>();
        ispressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!ispressed)
        {
            button.transform.localPosition = new Vector3(0, 0.03f, 0);
            presser = other.gameObject;
            OnPress.Invoke();
            //Sfx.Play();
            ispressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.015f, 0);
            Onrelease.Invoke();
            ispressed = false;
        }
    }

    public void spawnspheretest()
    {
        GameObject spheretest = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        spheretest.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        spheretest.transform.localPosition = new Vector3(0, 1, 2);
        spheretest.AddComponent<Rigidbody>();
    }


}
