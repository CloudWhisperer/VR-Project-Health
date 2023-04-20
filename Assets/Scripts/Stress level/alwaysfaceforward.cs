using UnityEngine;
public class alwaysfaceforward : MonoBehaviour
{
    public Transform target;
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.LookAt(target);
    }
}
