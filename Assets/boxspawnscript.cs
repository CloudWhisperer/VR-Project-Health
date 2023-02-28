using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxspawnscript : MonoBehaviour
{
    public GameObject obstacle;

    private void Update()
    {
        gameObject.transform.Rotate(0f, 1f, 0f, Space.Self);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.05f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cointouchminigamescorescript.score -= 1;

            Vector3 randomposition = new Vector3(Random.Range(-1, 2), Random.Range(0, 3), 15);

            GameObject box = Instantiate(obstacle, randomposition, transform.localRotation);

            Destroy(obstacle);
        }

        if (other.gameObject.tag == "Break")
        {
            Vector3 randomposition = new Vector3(Random.Range(-1, 2), Random.Range(0, 3), 15);

            GameObject coin = Instantiate(obstacle, randomposition, transform.localRotation);

            Destroy(obstacle);
        }
    }
}
