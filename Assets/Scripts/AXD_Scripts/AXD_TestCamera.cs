using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AXD_TestCamera : MonoBehaviour
{

    public WebCamTexture camTexture;
    public MeshRenderer mesh;
    public RenderTexture rt;
    // Start is called before the first frame update
    void Start()
    {
        camTexture = new WebCamTexture(WebCamTexture.devices[0].name);
        //camTexture.deviceName = WebCamTexture.devices[0].name;
        mesh.material.mainTexture = camTexture;
        camTexture.Play();

    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            if(Input.touches[0].phase == TouchPhase.Began)
            {
                ScreenShot();
            }
        }
    }
    public void ScreenShot()
    {
        Debug.Log("Screen");
        /*Texture2D texture = new Texture2D(camTexture.width, camTexture.height, TextureFormat.ARGB32, false);
        texture.SetPixels(camTexture.GetPixels());
        texture.Apply();
        mesh.material.mainTexture = texture;*/
        mesh.material.mainTexture = camTexture;
    }
}
