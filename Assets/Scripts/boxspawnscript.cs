using System.Collections;
using UnityEngine;

public class boxspawnscript : MonoBehaviour
{
    public Vector3 oldspawnpoint;
    public Vector3 currentspawnpoint;
    public GameObject line;
    public Animator boxanim;

    public GameObject obstacle;

    private void Start()
    {
        boxanim = GetComponent<Animator>();
    }

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

                StartCoroutine(dedbox());
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

            if (other.gameObject.tag == "Push")
            {
                if (transform.position.x < 0)
                {
                    StartCoroutine(moveleft());
                }
                if (transform.position.x >= 0)
                {
                    StartCoroutine(moveright());
                }

            }
        }
        else if (oldspawnpoint == currentspawnpoint)
        {
            GameObject box = Instantiate(obstacle, randomposition, transform.localRotation);

            Destroy(obstacle);
        }

        IEnumerator dedbox()
        {
            boxanim.SetTrigger("ded");
            yield return new WaitForSeconds(1);
            Destroy(obstacle);
            boxanim.ResetTrigger("ded");
        }

        IEnumerator moveleft()
        {
            for (int i = 0; i < 50; i++)
            {
                transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
                yield return new WaitForSeconds(0.01f);
            }
        }

        IEnumerator moveright()
        {
            for (int i = 0; i < 50; i++)
            {
                transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
                yield return new WaitForSeconds(0.01f);
            }
        }


    }
}
