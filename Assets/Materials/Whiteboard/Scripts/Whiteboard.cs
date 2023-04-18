using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Whiteboard : MonoBehaviour
{
    public Texture2D texture;
    public Vector2 texturesize = new Vector2 (2048,2048);
    public AudioSource clearwhiteboardsound;
    public XRBaseController lefthand;
    public XRBaseController righthand;

    // Start is called before the first frame update
    void Start()
    {
        var r = GetComponent<Renderer>();
        texture = new Texture2D((int)texturesize.x, (int)texturesize.y);
        r.material.mainTexture = texture;
    }

    public void ResetWhiteboard()
    {
        lefthand.SendHapticImpulse(0.2f, 0.2f);
        righthand.SendHapticImpulse(0.2f, 0.2f);
        clearwhiteboardsound.Play();
        var r = GetComponent<Renderer>();
        texture = new Texture2D((int)texturesize.x, (int)texturesize.y);
        r.material.mainTexture = texture;
    }

}
