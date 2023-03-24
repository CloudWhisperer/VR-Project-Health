using UnityEngine;

public class returnitem : MonoBehaviour
{
    public Transform ballspawnpoint;
    public Transform markerspawnpoint;
    public Transform pingpongpaddlespawnpoint;
    public Transform pingpongballspawnpoint;
    public Transform cubespawnpoint;
    public Transform paperplanespawnpoint;

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
    private void OnTriggerEnter(Collider col)
    {
        GameObject otherobject = col.gameObject;

        if (otherobject.CompareTag("Balls"))
        {
            otherobject.transform.position = ballspawn;
            otherobject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }

        //switch (col.gameObject.tag)
        //{
        //    case "Balls":
        //        Debug.Log("hit ball");
        //        gameObject.transform.localPosition = ballspawn;
        //        break;

        //    case "Marker":
        //        Debug.Log("hit marker");
        //        gameObject.transform.localPosition = markerspawn;
        //        break;

        //    case "Pingpongpaddle":
        //        Debug.Log("paddle");
        //        gameObject.transform.localPosition = paddlespawn;
        //        break;

        //    case "Pingpongball":
        //        Debug.Log("pong ball");
        //        gameObject.transform.localPosition = pongballspawn;
        //        break;

        //    case ("Cube"):
        //        Debug.Log("hit cube");
        //        gameObject.transform.localPosition = cubespawn;
        //        break;

        //    case ("Paperplane"):
        //        Debug.Log("hit plane");
        //        gameObject.transform.localPosition = paperplanespawn;
        //        break;

        //    default:
        //        break;

        //}
    }
}
