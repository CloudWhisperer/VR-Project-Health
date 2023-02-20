using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class firebutton : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnpoint;
    public float firespeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(firebullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void firebullet(ActivateEventArgs arg)
    {
        GameObject spawnedbullet = Instantiate(bullet);
        spawnedbullet.transform.position = spawnpoint.position;
        spawnedbullet.GetComponent<Rigidbody>().velocity = spawnpoint.forward * firespeed;
        Destroy(spawnedbullet, 5);
    }
}
