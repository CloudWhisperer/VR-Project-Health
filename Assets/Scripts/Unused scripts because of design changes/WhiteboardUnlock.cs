using UnityEngine;
using UnityEngine.InputSystem;

public class WhiteboardUnlock : MonoBehaviour
{
    public GameObject whiteboard;
    public Animator whiteboardAnimator;
    public InputActionProperty showButton;
    public static bool isUnlocked = false;

    // Update is called once per frame
    void Update()
    {
        if (isUnlocked == true)
        {
            if (showButton.action.WasPressedThisFrame())
            {
                if (whiteboardAnimator.GetBool("isopen") == false)
                {
                    whiteboardAnimator.SetBool("isopen", true);
                }
                else
                {
                    whiteboardAnimator.SetBool("isopen", false);
                }

            }

        }

    }
}
