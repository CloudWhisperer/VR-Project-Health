using UnityEngine;

public class boxspawnscript : MonoBehaviour
{
    public Vector3 oldspawnpoint;
    public Vector3 currentspawnpoint;

    public GameObject obstacle;

    private void Update()
    {
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

                cointouchminigamescorescript.scorecounter = 0;
                cointouchminigamescorescript.losecounter = +1;

                switch (cointouchminigamescorescript.losecounter)
                {
                    case 5:
                        obstacle.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                        break;

                    case 10:
                        Debug.Log("line");
                        break;

                    case 15:
                        obstacle.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                        break;
                }

                GameObject box = Instantiate(obstacle, randomposition, transform.localRotation);

                Destroy(obstacle);
            }

            if (other.gameObject.tag == "Break")
            {
                oldspawnpoint = randomposition;

                GameObject coin = Instantiate(obstacle, randomposition, transform.localRotation);

                Destroy(obstacle);
            }
            if (other.gameObject.tag == "Coin")
            {
                oldspawnpoint = randomposition;

                GameObject coin = Instantiate(obstacle, randomposition, transform.localRotation);

                Destroy(obstacle);
            }
        }
        else if (oldspawnpoint == currentspawnpoint)
        {
            GameObject coin = Instantiate(obstacle, randomposition, transform.localRotation);

            Destroy(obstacle);
        }


    }
}
