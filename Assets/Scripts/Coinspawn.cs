using UnityEngine;

public class Coinspawn : MonoBehaviour
{
    public GameObject coinprefab;
    public Vector3 oldspawnpoint;
    public Vector3 currentspawnpoint;

    public GameObject minion1;
    public GameObject minion2;
    public GameObject minion3;
    public GameObject minion4;

    cointouchminigamescorescript gamescript;

    private void Update()
    {
        gameObject.transform.Rotate(0f, 0f, 1f, Space.Self);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.02f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 randomposition = new Vector3(Random.Range(-0.8f, 0.8f), Random.Range(-1, 0.9f), 9);

        currentspawnpoint = randomposition;

        if (oldspawnpoint != currentspawnpoint)
        {
            if (other.gameObject.tag == "Player")
            {
                oldspawnpoint = randomposition;

                cointouchminigamescorescript.scorecounter += 1;

                switch (cointouchminigamescorescript.scorecounter)
                {
                    case 5:
                        minion1.SetActive(true);
                        break;

                    case 10:
                        minion2.SetActive(true);
                        break;

                    case 15:
                        minion3.SetActive(true);
                        break;

                    case 20:
                        minion4.SetActive(true);
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
