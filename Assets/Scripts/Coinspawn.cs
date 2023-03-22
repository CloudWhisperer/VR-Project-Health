using System.Collections;
using UnityEngine;

public class Coinspawn : MonoBehaviour
{
    public GameObject coinprefab;
    public Vector3 oldspawnpoint;
    public Vector3 currentspawnpoint;
    public ParticleSystem collect;
    public Animator coinanim;

    cointouchminigamescorescript gamescript;

    private void Start()
    {
        coinanim = GetComponent<Animator>();
    }
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
                collect.Play();
                coinanim.SetTrigger("dead");

                oldspawnpoint = randomposition;

                cointouchminigamescorescript.scorecounter += 1;
 
                Debug.Log(cointouchminigamescorescript.scorecounter);

                switch (cointouchminigamescorescript.scorecounter)
                {
                    case 5:
                        Debug.Log("streak1");
                        break;

                    case 10:
                        Debug.Log("streak2");
                        break;

                    case 15:
                        Debug.Log("streak3");
                        break;

                    case 20:
                        Debug.Log("streak4");
                        break;

                    default:
                        break;

                }

                GameObject coin = Instantiate(coinprefab, randomposition, transform.localRotation);

                StartCoroutine(killcoin());

            }

            if (other.gameObject.tag == "Break")
            {
                oldspawnpoint = randomposition;

                GameObject coin = Instantiate(coinprefab, randomposition, transform.localRotation);

                Destroy(coinprefab);
            }

            if (other.gameObject.tag == "Push")
            {
                if (transform.position.x < 0)
                {
                    StartCoroutine(moveleftcoin());
                }
                if (transform.position.x >= 0)
                {
                    StartCoroutine(moverightcoin());
                }

            }
        }
        else if (oldspawnpoint == currentspawnpoint)
        {
            GameObject coin = Instantiate(coinprefab, randomposition, transform.localRotation);
            Destroy(coinprefab);
        }
    }

    IEnumerator killcoin()
    {
        yield return new WaitForSeconds(1);
        Destroy(coinprefab);
        coinanim.ResetTrigger("dead");
    }

    IEnumerator moveleftcoin()
    {
        for (int i = 0; i < 50; i++)
        {
            transform.position = new Vector3(transform.position.x - 0.01f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator moverightcoin()
    {
        for (int i = 0; i < 50; i++)
        {
            transform.position = new Vector3(transform.position.x + 0.01f, transform.position.y, transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
