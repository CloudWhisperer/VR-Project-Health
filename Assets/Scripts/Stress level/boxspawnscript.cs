using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class boxspawnscript : MonoBehaviour
{
    [Header("-VR Controllers-")]
    [SerializeField]
    private XRBaseController Right_VR_Controller;
    [SerializeField]
    private XRBaseController Left_VR_controller;

    private Vector3 Old_spawn_point;
    private Vector3 Current_spawn_point;

    [Header("-Obstacle-")]
    [SerializeField]
    private GameObject Sphere_assist_line;
    [SerializeField]
    private Animator Obstacle_animator;
    [SerializeField]
    private AudioSource Obstacle_sound_effect;
    [SerializeField]
    private GameObject Obstacle_gameobject;

    private void Start()
    {
        Obstacle_animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //keeps moving the box towards the player
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.02f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //random spawn point for the obstacle
        Vector3 Random_spawn_point = new(Random.Range(-0.8f, 0.8f), Random.Range(-1, 0.9f), 9);

        Current_spawn_point = Random_spawn_point;

        if (Old_spawn_point != Current_spawn_point)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Left_VR_controller.SendHapticImpulse(0.1f, 0.1f);
                Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);

                Obstacle_sound_effect.Play();
                Old_spawn_point = Random_spawn_point;

                GameObject box = Instantiate(Obstacle_gameobject, Random_spawn_point, transform.localRotation);

                cointouchminigamescorescript.losecounter += 1;

                switch (cointouchminigamescorescript.losecounter)
                {
                    case 5:
                        Sphere_assist_line.SetActive(true);
                        break;

                    default:
                        break;
                }

                StartCoroutine(Obstacle_dead());
            }

            //collision wall behind player, will touch if player doesnt collect the box
            if (other.gameObject.tag == "Break")
            {
                Spawn_obstacle(Random_spawn_point);
            }

            //prevents box spawning in the same place as a coin
            if (other.gameObject.tag == "Coin" || other.gameObject.tag == "Box")
            {
                Spawn_obstacle(Random_spawn_point);
            }

            //checks if the obstacle is next to the player, if its true it will push the
            //obstacle away from the players view to prevent blocking vision and jumpscares
            if (other.gameObject.tag == "Push")
            {
                if (transform.position.x < 0)
                {
                    StartCoroutine(Move_obstacle_left());
                }
                if (transform.position.x >= 0)
                {
                    StartCoroutine(Move_obstacle_right());
                }
            }
        }

        //prevents duplicate spawn location
        else if (Old_spawn_point == Current_spawn_point)
        {
            GameObject box = Instantiate(Obstacle_gameobject, Random_spawn_point, transform.localRotation);

            Destroy(Obstacle_gameobject);
        }

        IEnumerator Obstacle_dead()
        {
            Obstacle_animator.SetTrigger("ded");
            yield return new WaitForSeconds(1);
            Destroy(Obstacle_gameobject);
            Obstacle_animator.ResetTrigger("ded");
        }

        IEnumerator Move_obstacle_left()
        {
            for (int i = 0; i < 50; i++)
            {
                transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
                yield return new WaitForSeconds(0.01f);
            }
        }

        IEnumerator Move_obstacle_right()
        {
            for (int i = 0; i < 50; i++)
            {
                transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }

    private void Spawn_obstacle(Vector3 Random_spawn_point)
    {
        Old_spawn_point = Random_spawn_point;

        GameObject box = Instantiate(Obstacle_gameobject, Random_spawn_point, transform.localRotation);

        Destroy(Obstacle_gameobject);
    }
}
