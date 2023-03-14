using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPlane : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private float speed = -0.4f;

    // Start is called before the first frame update
    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        body.AddForce(0, speed, 0);
    }
}
