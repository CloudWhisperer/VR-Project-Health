using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opensecretdebugobjects : MonoBehaviour
{
    public GameObject ballpit, shootingtarget, hoopthing,gun;
    private bool isopen = false;

    public void pressbuttonfordebugitems()
    {
        isopen = !isopen;

        if (isopen == true)
        {
            Debug.Log("on");
            ballpit.SetActive(true);
            shootingtarget.SetActive(true);
            hoopthing.SetActive(true);
            gun.SetActive(true);
        }
        if (isopen == false)
        {
            Debug.Log("off");
            ballpit.SetActive(false);
            shootingtarget.SetActive(false);
            hoopthing.SetActive(false);
            gun.SetActive(false);
        }

    }

}
