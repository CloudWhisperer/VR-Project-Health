using UnityEngine;

public class CanvasAnim : MonoBehaviour
{
    public static Animator canvasanim;

    // Start is called before the first frame update
    void Start()
    {
        canvasanim = GetComponent<Animator>();
    }
}
