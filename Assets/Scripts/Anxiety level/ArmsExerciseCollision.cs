using UnityEngine;

public class ArmsExerciseCollision : MonoBehaviour
{
    [SerializeField]
    private AnxietyGameScript Anxiety_game_manager_script;
    [SerializeField]
    private SphereCollider Arms_out_collision;
    [SerializeField]
    private SphereCollider Oculus_hand_collision;
    private int timer;
    private bool Has_loaded_next_section = false;

    private void OnTriggerEnter(Collider touchcol)
    {
        if (touchcol.CompareTag("Armout"))
        {
            timer = 0;
        }
    }

    private void OnTriggerStay(Collider touchcol)
    {
        if (touchcol.CompareTag("Armout"))
        {
            timer += 1;
        }
        if (timer >= 50)
        {
            Has_loaded_next_section = true;
            if(Has_loaded_next_section == true)
            {
                //runs the function from the game manager script and starts the second part of the exercise
                StartCoroutine(Anxiety_game_manager_script.Begin_applied_relaxation_part_2());
                Has_loaded_next_section = false;
            }

            Arms_out_collision.enabled = false;
        }
    }

    private void OnTriggerExit(Collider touchcol)
    {
        if (touchcol.CompareTag("Armout"))
        {
            timer = 0;
        }
    }
}
