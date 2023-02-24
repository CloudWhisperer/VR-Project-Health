using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class vrbutton2 : MonoBehaviour
{
    public float deadtime = 1.0f;
    private bool deadtimeactivated = false;

    public UnityEvent onPressed, onReleased;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button" && !deadtimeactivated)
        {
            onPressed?.Invoke();
            Debug.Log("press button");
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Button" && !deadtimeactivated)
        {
            onReleased?.Invoke();
            Debug.Log("RELEASE button");
            StartCoroutine(waitfordeadtime());
        }
    }

    IEnumerator waitfordeadtime()
    {
        deadtimeactivated = true;
        yield return new WaitForSeconds(deadtime);
        deadtimeactivated = false;
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
