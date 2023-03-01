using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Coinspawn : MonoBehaviour
{
    public GameObject coinprefab;

    private void Update()
    {
        gameObject.transform.Rotate(0f, 0f, 1f, Space.Self);
        transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z -0.05f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            cointouchminigamescorescript.score += 1;

            Vector3 randomposition = new Vector3(Random.Range(-1, 2), Random.Range(0, 3), 15);

            GameObject coin = Instantiate(coinprefab, randomposition, transform.localRotation);

            Destroy(coinprefab);
        }

        if(other.gameObject.tag == "Break")
        {
            Vector3 randomposition = new Vector3(Random.Range(-1, 2), Random.Range(0, 3), 15);

            GameObject coin = Instantiate(coinprefab, randomposition, transform.localRotation);

            Destroy(coinprefab);
        }
    }
}
