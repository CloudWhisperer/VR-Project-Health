using UnityEngine;

public class exercisecollision : MonoBehaviour
{
    public AnxietyGameScript anxscript;
    public SphereCollider armsoutcoll;

    public SphereCollider touchcol;
    public int timer;

    private void OnTriggerEnter(Collider touchcol)
    {
        if (touchcol.CompareTag("Armout"))
        {
            timer = 0;
        }
    }

    private void OnTriggerStay(Collider touchcol)
    {
        if (touchcol.CompareTag("Armout"))
        {
            timer += 1;
        }
        if (timer >= 50)
        {
            StartCoroutine(anxscript.Relaxationpart2());
            armsoutcoll.enabled = false;

        }
    }

    private void OnTriggerExit(Collider touchcol)
    {
        if (touchcol.CompareTag("Armout"))
        {
            timer = 0;
        }
    }
}
