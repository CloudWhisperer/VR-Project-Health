using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class calibrationlevel : MonoBehaviour
{

    Levelchangefade fadescript;
    public XRBaseController lefthand;
    public XRBaseController righthand;
    public AudioSource sfx;


    // Start is called before the first frame update
    void Start()
    {
        fadescript = GameObject.FindGameObjectWithTag("Fade").GetComponent<Levelchangefade>();
    }

    public void nextlevel()
    {
        sfx.Play();
        lefthand.SendHapticImpulse(0.1f, 0.1f);
        righthand.SendHapticImpulse(0.1f, 0.1f);
        //fade to main menu
        Levelchangefade.leveltoload = 1;
        fadescript.fadetolevel();
    }

}
