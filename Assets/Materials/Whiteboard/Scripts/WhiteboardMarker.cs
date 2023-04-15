using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WhiteboardMarker : MonoBehaviour
{
    //--variables needed--
    //using serializefield this time so other scripts dont mess this up and prevents
    //a million things showing up in autocorrect visual studio

    [SerializeField] private Transform tip;
    [SerializeField] private int pensize = 5;
    private float tipheight;
    private Renderer Renderer;
    private Color[] Colours;
    private RaycastHit touch;
    private Whiteboard _whiteboard;
    private Vector2 touchpos, lasttouchpos;
    private bool touchedlastframe;
    private Quaternion lasttouchrot;
    [SerializeField] private AudioSource drawingsound;

    public XRBaseController leftcontroller;
    public XRBaseController rightcontroller;

    // Start is called before the first frame update
    void Start()
    {
        //get renderer component
        Renderer = tip.GetComponent<Renderer>();

        //set colour array
        Colours = Enumerable.Repeat(Renderer.material.color, pensize * pensize).ToArray();

        //set tip height of the marker
        tipheight = tip.localScale.y;

    }

    // Update is called once per frame
    void Update()
    {
        //draws every frame
        Draw();
    }

    private void Draw()
    {
        //casting a raycast and checking if it hits the whiteboard or not
        if (Physics.Raycast(tip.position, transform.up, out touch, tipheight))
        {
            if (touch.transform.CompareTag("Whiteboard"))
            {
                //double checks the whiteboard is not null
                if (_whiteboard == null)
                {
                    _whiteboard = touch.transform.GetComponent<Whiteboard>();
                }

                //send haptics
                leftcontroller.SendHapticImpulse(0.1f, 0.1f);
                rightcontroller.SendHapticImpulse(0.1f, 0.1f);

                //play drawing sound when drawing
                if (!drawingsound.isPlaying)
                {
                    drawingsound.Play();
                }

                //gets touch position from world coordinates
                touchpos = new Vector2(touch.textureCoord.x, touch.textureCoord.y);

                //converst touch position to whiteboard size
                var x = (int)(touchpos.x * _whiteboard.texturesize.x - (pensize / 2));
                var y = (int)(touchpos.y * _whiteboard.texturesize.y - (pensize / 2));

                //if the drawing is not on the whiteboard then exit otherwise lag
                if (y < 0 || y > _whiteboard.texturesize.y || x < 0 || x > _whiteboard.texturesize.x)
                {
                    drawingsound.Stop();
                    return;
                }

                //checks if we touched the last frame, if it did then we colour in pixels, small interpolate
                if (touchedlastframe)
                {
                    //setting the point the pen touches
                    _whiteboard.texture.SetPixels(x, y, pensize, pensize, Colours);

                    //interpolating from last point to current point
                    for (float f = 0.01f; f < 1.00f; f += 0.01f)
                    {
                        var lerpx = (int)Mathf.Lerp(lasttouchpos.x, x, f);
                        var lerpy = (int)Mathf.Lerp(lasttouchpos.y, y, f);
                        _whiteboard.texture.SetPixels(lerpx, lerpy, pensize, pensize, Colours);
                    }

                    //stops the pen from doing that annoying rotation physics thing
                    transform.rotation = lasttouchrot;

                    //applying the colour to pixels
                    _whiteboard.texture.Apply();
                }

                //setting cache for next frame
                lasttouchpos = new Vector2(x, y);
                lasttouchrot = transform.rotation;
                touchedlastframe = true;
                return;
            }
        }

        //if it didnt do anything reset the things
        _whiteboard = null;
        touchedlastframe = false;
    }
}
