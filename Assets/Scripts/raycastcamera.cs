using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class raycastcamera : MonoBehaviour
{
    private GameObject Collidersphere;
    private int score;
    private bool touching;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Ball" || collision.gameObject.name == "Ball2")
        {
            Debug.Log("touched");
            touching = true;
        }
    }

    private void Update()
    {
        if (touching == true)
        {
            score += 1;
        }
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    if(collision.gameObject.name == "Ball" || collision.gameObject.name == "Ball2")
    //    {
    //        Debug.Log("staying on ball");
    //        scorecounter += 0.1f;
    //        Debug.Log(scorecounter);
    //    }
    //}

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Ball" || collision.gameObject.name == "Ball2")
        {
            Debug.Log("exit");
            Debug.Log(score);
            touching = false;
        }
    }

}
