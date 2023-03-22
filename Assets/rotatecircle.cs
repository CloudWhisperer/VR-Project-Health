using UnityEngine;

public class rotatecircle : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        // Spin the object around the target at 20 degrees/second.
        transform.RotateAround(target.transform.position, new Vector3(0,0,1), 100 * Time.deltaTime);
    }
}