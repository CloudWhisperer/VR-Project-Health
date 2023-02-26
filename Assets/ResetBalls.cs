using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBalls : MonoBehaviour
{
    public GameObject ball;
    Vector3 resetpos;

    private void Start()
    {
        resetpos = new Vector3 (-0.371f, 0.8863f, -1.0632f);
    }

    public void Reset()
    {
        ball.transform.localPosition = resetpos;
        Debug.Log("reseted balls");
    }
}
