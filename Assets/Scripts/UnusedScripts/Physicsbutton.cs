using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Physicsbutton : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadzone = 0.025f;

    private bool ispressed;
    private Vector3 startpos;
    private ConfigurableJoint joint;

    public UnityEvent onPressed, onReleased;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!ispressed && Getvalue() + threshold >= 1)
        {
            pressed();
        }
        if (ispressed && Getvalue() - threshold <= 0)
        {
            Released();
        }
    }

    private float Getvalue()
    {
        var value = Vector3.Distance(startpos, transform.localPosition) / joint.linearLimit.limit;

            if(Math.Abs(value) < deadzone)
            value = 0;

        return Mathf.Clamp(value, -1, 1f);   
    }


    private void pressed()
    {
        ispressed = true;
        onPressed.Invoke();
        Debug.Log("Pressed");
    }

    private void Released()
    {
        ispressed = false;
        onReleased.Invoke();
        Debug.Log("Released");
    }
}
