using System.Collections;
using UnityEngine;

public class ResetBalls : MonoBehaviour
{
    public GameObject game;
    public GameObject ball1;
    public GameObject ball2;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            StartCoroutine("Firstphase");
        }

        else if (other.tag == "Ball2")
        {
            StartCoroutine("Secondphase");
        }
    }

    IEnumerator Firstphase()
    {
        yield return new WaitForSeconds(0.5f);
        Ballanim.ballanim.enabled = true;
        yield return new WaitForSeconds(0.5f);
        Destroy(ball1);
        yield return new WaitForSeconds(0.5f);
        ball2.gameObject.SetActive(true);
    }

    IEnumerator Secondphase()
    {
        yield return new WaitForSeconds(0.5f);
        Ballanim2.ballanim2.enabled = true;
        yield return new WaitForSeconds(0.5f);
        Destroy(ball2);
    }
}
