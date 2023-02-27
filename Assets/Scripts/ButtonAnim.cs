using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnim : MonoBehaviour
{
    public static Animator buttonanim;

    // Start is called before the first frame update
    void Start()
    {
        buttonanim = GetComponent<Animator>();
    }
}
