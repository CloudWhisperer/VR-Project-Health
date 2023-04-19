using UnityEngine;

public class exercisecollision : MonoBehaviour
{
    [SerializeField]
    private AnxietyGameScript Anxiety_game_manager_script;
    [SerializeField]
    private SphereCollider Arms_out_collision;
    [SerializeField]
    private SphereCollider Oculus_hand_collision;
    private int timer;

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
            //runs the function from the game manager script and starts the second part of the exercise
            StartCoroutine(Anxiety_game_manager_script.Begin_applied_relaxation_part_2());
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
