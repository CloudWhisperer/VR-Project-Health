using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelchangefade : MonoBehaviour
{
    public Animator Fade_animator;

    public static int What_level_number_to_load;

    public void Fade_to_level()
    {
        Fade_animator.SetTrigger("fadeout");
        //actual level loading is within the animation of the fading using events/triggers.
    }

    public void On_fade_completed()
    {
        SceneManager.LoadScene(What_level_number_to_load);
    }


}
