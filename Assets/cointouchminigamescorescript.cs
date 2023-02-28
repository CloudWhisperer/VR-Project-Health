using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cointouchminigamescorescript : MonoBehaviour
{
    public static int score;

    private void Update()
    {
        Debug.Log(score);
        if (score < 0)
        {
            score = 0;
        }
        if (score >= 15)
        {
            Debug.Log("done with game");
            SceneManager.LoadScene("Scene1");
        }
    }

}
