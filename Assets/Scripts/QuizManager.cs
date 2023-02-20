using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public TextMeshProUGUI anxietytext;
    public TextMeshProUGUI depressiontext;
    public TextMeshProUGUI stresstext;

    public int Anxietylevel = 0;
    public int Depressionlevel = 0;
    public int Stresslevel = 0;

    public void anxadd()
    {
        anxietytext.text = "Anxietylevel = " + Anxietylevel.ToString();
        Anxietylevel += 1;
        Debug.Log(Anxietylevel);
    }

    public void depadd()
    {
        depressiontext.text = "Depressionlevel = " + Depressionlevel.ToString();
        Depressionlevel += 1;
        Debug.Log(Depressionlevel);
    }

    public void stradd()
    {
        stresstext.text = "Stresslevel = " + Stresslevel.ToString();
        Stresslevel += 1;
        Debug.Log(Stresslevel);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
