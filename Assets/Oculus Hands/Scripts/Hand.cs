using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public float speed;
    Animator animator;
    private float gripTarget;
    private float Triggertarget;
    private float gripcurrent;
    private float triggercurrent;
    private string animatorgripname = "Grip";
    private string animatortriggername = "Trigger";


    internal void SetGrip(float v)
    {
        gripTarget = v;
    }

    internal void SetTrigger(float v)
    {
        Triggertarget = v;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animatehand();   
    }

    void animatehand()
    {
        if (gripcurrent != gripTarget)
        {
            gripcurrent = Mathf.MoveTowards(gripcurrent, gripTarget, Time.deltaTime * speed);
            animator.SetFloat(animatorgripname, gripcurrent);
        }
        if (triggercurrent != Triggertarget)
        {
            triggercurrent = Mathf.MoveTowards(triggercurrent, Triggertarget, Time.deltaTime * speed);
            animator.SetFloat(animatortriggername, triggercurrent);
        }
    }
}
