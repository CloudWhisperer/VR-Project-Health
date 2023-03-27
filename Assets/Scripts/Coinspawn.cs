using System.Collections;
using UnityEngine;

public class Coinspawn : MonoBehaviour
{
    public GameObject coinprefab;
    public Vector3 oldspawnpoint;
    public Vector3 currentspawnpoint;
    public ParticleSystem collect;
    public Animator coinanim;
    public TrailRenderer spheretrail;
    public bool istutorialcoin;
    public AudioSource coinsound;

    public cointouchminigamescorescript gamescript;

    private void Start()
    {
        coinanim = GetComponent<Animator>();
        gamescript = GameObject.FindObjectOfType(typeof(cointouchminigamescorescript)) as cointouchminigamescorescript;
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
                coinsound.Play();
                collect.Play();
                coinanim.SetTrigger("dead");

                oldspawnpoint = randomposition;

                if (istutorialcoin == false)
                {
                    cointouchminigamescorescript.scorecounter += 1;
                }

                Debug.Log(cointouchminigamescorescript.scorecounter);

                switch (cointouchminigamescorescript.scorecounter)
                {
                    case 5:
                        spheretrail.enabled = true;
                        break;

                    case 10:
                        spheretrail.startColor = Color.black;
                        break;

                    case 15:
                        spheretrail.startColor = Color.white;
                        break;

                    case 20:
                        spheretrail.startColor = Color.yellow;
                        break;

                    case 40:
                        if (gamescript == null)
                        {
                            Debug.Log("its null :(");
                        }
                        gamescript.End_Game();
                        Debug.Log("got 40");
                        break;

                    default:
                        break;

                }

                if (istutorialcoin == false)
                {
                    GameObject coin = Instantiate(coinprefab, randomposition, transform.localRotation);
                }

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
