using UnityEngine;

public class boxspawnscript : MonoBehaviour
{
    public Vector3 oldspawnpoint;
    public Vector3 currentspawnpoint;
    public GameObject line;

    cointouchminigamescorescript gamescript;

    public GameObject obstacle;

    private void Update()
    {
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

                GameObject box = Instantiate(obstacle, randomposition, transform.localRotation);

                cointouchminigamescorescript.losecounter += 1;

                switch (cointouchminigamescorescript.losecounter)
                {
                    case 5:
                        line.SetActive(true);
                        break;

                    default:
                        break;
                }

                Destroy(obstacle);
            }

            if (other.gameObject.tag == "Break")
            {
                oldspawnpoint = randomposition;

                GameObject box = Instantiate(obstacle, randomposition, transform.localRotation);

                Destroy(obstacle);
            }
            if (other.gameObject.tag == "Coin" || other.gameObject.tag == "Box")
            {
                oldspawnpoint = randomposition;

                GameObject box = Instantiate(obstacle, randomposition, transform.localRotation);

                Destroy(obstacle);
            }
        }
        else if (oldspawnpoint == currentspawnpoint)
        {
            GameObject box = Instantiate(obstacle, randomposition, transform.localRotation);

            Destroy(obstacle);
        }


    }
}
