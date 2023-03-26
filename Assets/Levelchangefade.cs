using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelchangefade : MonoBehaviour
{
    public Animator anim;

    public static int leveltoload;

    public void fadetolevel()
    {
        anim.SetTrigger("fadeout");
    }

    public void onfadecomplete()
    {
        SceneManager.LoadScene(leveltoload);
    }


}
