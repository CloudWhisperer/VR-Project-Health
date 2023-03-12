using UnityEngine;
using UnityEngine.InputSystem;

public class WhiteboardUnlock : MonoBehaviour
{
    public GameObject whiteboard;
    public Animator whiteboardAnimator;
    public InputActionProperty showButton;
    private bool isUnlocked = true;

    // Update is called once per frame
    void Update()
    {
        if (isUnlocked == true)
        {
            if (showButton.action.WasPressedThisFrame())
            {
                whiteboard.SetActive(!whiteboard.activeSelf);
            }

        }

    }
}
