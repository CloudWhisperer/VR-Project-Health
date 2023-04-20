using UnityEngine;

public class ReturningTableItems : MonoBehaviour
{
    [Header("-Item spawn points-")]
    [SerializeField]
    private Transform Ball_spawn_point;
    [SerializeField]
    private Transform marker_spawn_point,
                      Ping_pong_paddle_spawn_point,
                      Ping_pong_ball_spawn_point,
                      Cube_spawn_point,
                      Paper_plane_spawn_point;

    [Header("-Item rotation spawn-")]
    [SerializeField]
    private Quaternion Marker_spawn_rotation;
    [SerializeField]
    private Quaternion Paddle_spawn_rotation;
    [SerializeField]
    private Quaternion Paper_plane_spawn_rotation;

    //vectors are used here to translate the transforms into something i can use
    private Vector3 Ball_spawn_vector;
    private Vector3 Marker_spawn_vector;
    private Vector3 Ping_pong_paddle_spawn_vector;
    private Vector3 Ping_pong_ball_spawn_vector;
    private Vector3 Cube_spawn_vector;
    private Vector3 paper_plane_spawn_vector;

    [Header("-Sound effects-")]
    [SerializeField]
    private AudioSource Return_item_sound_effect;
    [SerializeField]
    private AudioSource Paper_plane_sound_effect;

    private void Start()
    {
        Set_spawn_points_of_objects();
    }

    private void Set_spawn_points_of_objects()
    {
        Ball_spawn_vector = Ball_spawn_point.transform.position;
        Marker_spawn_vector = marker_spawn_point.transform.position;
        Ping_pong_paddle_spawn_vector = Ping_pong_paddle_spawn_point.transform.position;
        Ping_pong_ball_spawn_vector = Ping_pong_ball_spawn_point.transform.position;
        Cube_spawn_vector = Cube_spawn_point.transform.position;
        paper_plane_spawn_vector = Paper_plane_spawn_point.transform.position;
    }

    //cant use switch cases because it stops the if statement when one object has been touched
    private void OnTriggerEnter(Collider col)
    {
        GameObject otherobject = col.gameObject;
        Return_item_sound_effect.Play();

        if (otherobject.CompareTag("Balls"))
        {
            Reset_ball(otherobject);
        }

        if (otherobject.CompareTag("Marker"))
        {
            Reset_marker(otherobject);
        }

        if (otherobject.CompareTag("Pingpongpaddle"))
        {
            Reset_ping_pong_paddle(otherobject);
        }

        if (otherobject.CompareTag("Pingpongball"))
        {
            Reset_ping_pong_ball(otherobject);
        }

        if (otherobject.CompareTag("Cube"))
        {
            Reset_cube(otherobject);
        }

        if (otherobject.CompareTag("Paperplane"))
        {
            Reset_paper_plane(otherobject);
        }
    }

    //the reset functions are to reset the position of the object when it goes off the world.
    //spawns back on the table so the player can play with it after it falls off
    private void Reset_paper_plane(GameObject otherobject)
    {
        Paper_plane_sound_effect.Stop();
        otherobject.transform.position = paper_plane_spawn_vector;
        otherobject.transform.rotation = Paper_plane_spawn_rotation;
        otherobject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    private void Reset_cube(GameObject otherobject)
    {
        otherobject.transform.position = Cube_spawn_vector;
        otherobject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    private void Reset_ping_pong_ball(GameObject otherobject)
    {
        otherobject.transform.position = Ping_pong_ball_spawn_vector;
        otherobject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    private void Reset_ping_pong_paddle(GameObject otherobject)
    {
        otherobject.transform.position = Ping_pong_paddle_spawn_vector;
        otherobject.transform.rotation = Paddle_spawn_rotation;
        otherobject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    private void Reset_marker(GameObject otherobject)
    {
        otherobject.transform.position = Marker_spawn_vector;
        otherobject.transform.rotation = Marker_spawn_rotation;
        otherobject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    private void Reset_ball(GameObject otherobject)
    {
        otherobject.transform.position = Ball_spawn_vector;
        otherobject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}
