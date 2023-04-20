using UnityEngine;

public class LineAlwaysLookAt : MonoBehaviour
{
    [SerializeField]
    private Transform Target_to_look_at;

    void Update()
    {
        this.gameObject.transform.LookAt(Target_to_look_at);
    }
}
