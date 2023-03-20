using UnityEngine;

public class Coinspawn : MonoBehaviour
{
    public GameObject coinprefab;
    public Vector3 oldspawnpoint;
    public Vector3 currentspawnpoint;

    private void Update()
    {
        gameObject.transform.Rotate(0f, 0f, 1f, Space.Self);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.02f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 randomposition = new Vector3(Random.Range(-1, 2), Random.Range(0, 3), 7);

        currentspawnpoint = randomposition;

        if (oldspawnpoint != currentspawnpoint)
        {
            if (other.gameObject.tag == "Player")
            {
                oldspawnpoint = randomposition;

                cointouchminigamescorescript.scorecounter += 1;
                cointouchminigamescorescript.losecounter -= 1;

                switch (cointouchminigamescorescript.scorecounter)
                {
                    case 5:
                        Debug.Log("vignette");
                        break;

                    case 10:
                        Debug.Log("do more cool stuff");
                        break;

                    case 15:
                        Debug.Log("one more cool thing for flow");
                        break;

                    case 20:
                        Debug.Log("done with game");
                        break;

                    default:
                        break;

                }

                GameObject coin = Instantiate(coinprefab, randomposition, transform.localRotation);

                Destroy(coinprefab);
            }

            if (other.gameObject.tag == "Break")
            {
                oldspawnpoint = randomposition;

                GameObject coin = Instantiate(coinprefab, randomposition, transform.localRotation);

                Destroy(coinprefab);
            }
        }
        else if (oldspawnpoint == currentspawnpoint)
        {
            GameObject coin = Instantiate(coinprefab, randomposition, transform.localRotation);
            Destroy(coinprefab);
        }
    }
}
