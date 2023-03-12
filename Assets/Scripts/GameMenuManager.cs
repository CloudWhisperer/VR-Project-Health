using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    public Transform head;
    public float spawndistance = 2f;
    public GameObject Menu;
    public InputActionProperty showButton;

    // Update is called once per frame
    void Update()
    {
        if(showButton.action.WasPressedThisFrame())
        {
            Menu.SetActive(!Menu.activeSelf);

            Menu.transform.position = head.position + new Vector3(head.forward.x, head.forward.y, head.forward.z).normalized * spawndistance;
        }

        Menu.transform.LookAt(new Vector3(head.position.x, head.position.y, head.position.z));
        Menu.transform.forward *= -1;
    }
}
