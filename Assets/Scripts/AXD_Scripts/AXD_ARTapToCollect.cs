using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;


public class AXD_ARTapToCollect : MonoBehaviour
{

    private ARSessionOrigin arOrigin;
    private Pose tapPose;
    public Color pixelColor;
    public Texture2D texture;
    // Start is called before the first frame update
    void Start()
    {
        arOrigin = FindObjectOfType<ARSessionOrigin>();
    }

    private void Update()
    {
        if(Input.touchCount == 1)
        {
            //Get touch
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            //create 2D texture of the image
            //Texture = ???
            pixelColor = texture.GetPixel((int)touch.position.x, (int)touch.position.y);
        }
    }
}
