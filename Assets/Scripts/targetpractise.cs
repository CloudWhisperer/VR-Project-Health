using UnityEngine;

public class targetpractise : MonoBehaviour
{
    public GameObject target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log("hittarget");
            Vector3 randomposition = new Vector3(Random.Range(-1f, -2f), Random.Range(1f, 2f), Random.Range(-0.5f,0.5f));

            GameObject box = Instantiate(target, randomposition, transform.localRotation);

            Destroy(target);
        }
    }
}
