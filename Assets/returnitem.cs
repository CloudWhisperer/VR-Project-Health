using UnityEngine;

public class returnitem : MonoBehaviour
{
    public Transform ballspawnpoint;
    public Transform markerspawnpoint;
    public Transform pingpongpaddlespawnpoint;
    public Transform pingpongballspawnpoint;
    public Transform cubespawnpoint;
    public Transform paperplanespawnpoint;

    public Quaternion markerrotation;
    public Quaternion paddlerotation;

    private Vector3 ballspawn;
    private Vector3 markerspawn;
    private Vector3 paddlespawn;
    private Vector3 pongballspawn;
    private Vector3 cubespawn;
    private Vector3 paperplanespawn;

    private void Start()
    {
        ballspawn = ballspawnpoint.transform.position;
        markerspawn = markerspawnpoint.transform.position;

        paddlespawn = pingpongpaddlespawnpoint.transform.position;

        pongballspawn = pingpongballspawnpoint.transform.position;
        cubespawn = cubespawnpoint.transform.position;
        paperplanespawn = paperplanespawnpoint.transform.position;

        Debug.Log(ballspawn);
        Debug.Log(markerspawn);
        Debug.Log(paddlespawn);
        Debug.Log(pongballspawn);
        Debug.Log(cubespawn);
        Debug.Log(paperplanespawn);
    }

    //cant use switch cases because it stops the if statement when one object has been touched
    private void OnTriggerEnter(Collider col)
    {
        GameObject otherobject = col.gameObject;

        if (otherobject.CompareTag("Balls"))
        {
            otherobject.transform.position = ballspawn;
            otherobject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

        if (otherobject.CompareTag("Marker"))
        {
            otherobject.transform.position = markerspawn;
            otherobject.transform.rotation = markerrotation;
            otherobject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

        if (otherobject.CompareTag("Pingpongpaddle"))
        {
            otherobject.transform.position = paddlespawn;
            otherobject.transform.rotation = paddlerotation;
            otherobject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

        if (otherobject.CompareTag("Pingpongball"))
        {
            otherobject.transform.position = pongballspawn;
            otherobject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

        if (otherobject.CompareTag("Cube"))
        {
            otherobject.transform.position = cubespawn;
            otherobject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

        if (otherobject.CompareTag("Paperplane"))
        {
            otherobject.transform.position = paperplanespawn;
            otherobject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }
}
