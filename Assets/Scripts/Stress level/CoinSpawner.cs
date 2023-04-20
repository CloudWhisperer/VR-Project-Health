using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CoinSpawner : MonoBehaviour
{
    [Header("-VR Controllers-")]
    [SerializeField]
    private XRBaseController Right_VR_Controller;
    [SerializeField]
    private XRBaseController Left_VR_Controller;

    [Header("-Coin-")]
    [SerializeField]
    private GameObject Coin_gameobject;
    [SerializeField]
    private Animator Coin_animator;
    [SerializeField]
    private AudioSource Coin_sound_effect;
    [SerializeField]
    private ParticleSystem Coin_collect_particle;
    [SerializeField]
    private TrailRenderer Player_sphere_trail;
    [SerializeField]
    private bool Is_tutorial_coin;

    private Vector3 Old_spawn_point;
    private Vector3 Current_spawn_point;

    [Header("Scripts")]
    [SerializeField]
    private CoinMiniGame Stress_game_script;

    private void Start()
    {
        Initialize_coin_and_values();
    }

    private void Initialize_coin_and_values()
    {
        Coin_animator = GetComponent<Animator>();
        Stress_game_script = GameObject.FindObjectOfType(typeof(CoinMiniGame)) as CoinMiniGame;
    }

    private void Update()
    {
        Rotate_and_move_coin_towards_player();
    }

    private void Rotate_and_move_coin_towards_player()
    {
        gameObject.transform.Rotate(0f, 0f, 1f, Space.Self);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.02f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 randomposition = new(Random.Range(-0.8f, 0.8f), Random.Range(-1, 0.9f), 9);

        Current_spawn_point = randomposition;

        if (Old_spawn_point != Current_spawn_point)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Contact_with_player_sphere(randomposition);

                switch (CoinMiniGame.scorecounter)
                {
                    case 5:
                        Turn_on_sphere_trail();
                        break;

                    case 10:
                        Sphere_trail_black();
                        break;

                    case 15:
                        Sphere_trail_white();
                        break;

                    case 20:
                        Sphere_trail_gold();
                        break;

                    case 40:
                        Collected_40_coins();
                        break;

                    default:
                        break;

                }

                //tutorial coins arent meant to add to the score or spawn another when destroyed
                if (Is_tutorial_coin == false)
                {
                    GameObject coin = Instantiate(Coin_gameobject, randomposition, transform.localRotation);
                }

                StartCoroutine(Coin_dead());

            }

            //collision wall behind player, will touch if player doesnt collect the coin
            if (other.gameObject.tag == "Break")
            {
                Contact_with_wall(randomposition);
            }

            //checks if the coin is right next to the player, if its true it will push the
            //obstacle away from the players view to prevent blocking vision and jumpscares
            if (other.gameObject.tag == "Push")
            {
                if (transform.position.x < 0)
                {
                    StartCoroutine(Move_coin_left());
                }
                if (transform.position.x >= 0)
                {
                    StartCoroutine(Move_coin_right());
                }
            }
        }
        else if (Old_spawn_point == Current_spawn_point)
        {
            GameObject coin = Instantiate(Coin_gameobject, randomposition, transform.localRotation);
            Destroy(Coin_gameobject);
        }
    }

    private void Contact_with_wall(Vector3 randomposition)
    {
        Old_spawn_point = randomposition;

        GameObject coin = Instantiate(Coin_gameobject, randomposition, transform.localRotation);

        Destroy(Coin_gameobject);
    }

    private void Collected_40_coins()
    {
        if (Stress_game_script == null)
        {
            Debug.Log("its null :(");
        }
        Stress_game_script.End_Game();
        Debug.Log("got 40");
    }

    private void Sphere_trail_gold()
    {
        Player_sphere_trail.startColor = Color.yellow;
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
    }

    private void Sphere_trail_white()
    {
        Player_sphere_trail.startColor = Color.white;
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
    }

    private void Sphere_trail_black()
    {
        Player_sphere_trail.startColor = Color.black;
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
    }

    private void Turn_on_sphere_trail()
    {
        Player_sphere_trail.enabled = true;
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
    }

    private void Contact_with_player_sphere(Vector3 randomposition)
    {
        Left_VR_Controller.SendHapticImpulse(0.1f, 0.1f);
        Right_VR_Controller.SendHapticImpulse(0.1f, 0.1f);

        Coin_sound_effect.Play();
        Coin_collect_particle.Play();
        Coin_animator.SetTrigger("dead");

        Old_spawn_point = randomposition;

        if (Is_tutorial_coin == false)
        {
            CoinMiniGame.scorecounter += 1;
        }

        Debug.Log(CoinMiniGame.scorecounter);
    }

    IEnumerator Coin_dead()
    {
        yield return new WaitForSeconds(1);
        Destroy(Coin_gameobject);
        Coin_animator.ResetTrigger("dead");
    }

    IEnumerator Move_coin_left()
    {
        for (int i = 0; i < 50; i++)
        {
            transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator Move_coin_right()
    {
        for (int i = 0; i < 50; i++)
        {
            transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
    }
}