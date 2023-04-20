using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CalibrationLevel : MonoBehaviour
{
    LevelChangeFade Level_fade_script;

    [Header("-VR Controllers-")]
    [SerializeField]
    private XRBaseController Left_VR_Controller;
    [SerializeField]
    private XRBaseController Right_VR_Controller;
    [Header("-Sound Effects-")]
    [SerializeField]
    private AudioSource Button_sound_effect;

    void Start()
    {
        Level_fade_script = GameObject.FindGameObjectWithTag("Fade").GetComponent<LevelChangeFade>();
    }

    public void Go_to_main_menu()
    {
        Button_sound_effect.Play();
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);

        //fade to main menu
        LevelChangeFade.What_level_number_to_load = 1;
        Level_fade_script.Fade_to_level();
    }

}
