using UnityEngine;

public class Ballanim : MonoBehaviour
{
    public static Animator ballanim;

    // Start is called before the first frame update
    void Start()
    {
        ballanim = GetComponent<Animator>();
    }

}
