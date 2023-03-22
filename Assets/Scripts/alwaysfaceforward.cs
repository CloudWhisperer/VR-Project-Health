using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class alwaysfaceforward : MonoBehaviour
{
    public Transform target;
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.LookAt(target);
    }
}
