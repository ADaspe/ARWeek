using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Unity.Collections.LowLevel.Unsafe;
using InventorySystem;
using PotionCreationSystem;

public class CameraToTexture : MonoBehaviour
{
    public ARCameraManager m_CameraManager;
    public RawImage m_RawCameraImage;
    public float r, g, b;
    Texture2D m_CameraTexture;
    public Inventory invent;
    public Color[] cols;

    void OnEnable()
    {
        if (m_CameraManager != null)
        {
            m_CameraManager.frameReceived += OnCameraFrameReceived;
        }
    }

    void OnDisable()
    {
        if (m_CameraManager != null)
        {
            m_CameraManager.frameReceived -= OnCameraFrameReceived;
        }
    }
    void OnCameraFrameReceived(ARCameraFrameEventArgs eventArgs)
    {
        UpdateCameraImage();
    }

    

    unsafe void UpdateCameraImage()
    {
        // Attempt to get the latest camera image. If this method succeeds,
        // it acquires a native resource that must be disposed (see below).
        if (!m_CameraManager.TryAcquireLatestCpuImage(out XRCpuImage image))
        {
            return;
        }

        // Choose an RGBA format.
        // See XRCpuImage.FormatSupported for a complete list of supported formats.
        var format = TextureFormat.RGBA32;

        //Create new RenderTexture with correct width and height
        if (m_CameraTexture == null || m_CameraTexture.width != image.width || m_CameraTexture.height != image.height)
        {
            m_CameraTexture = new Texture2D(image.width, image.height, format, false);
        }

        // Convert the image to format, flipping the image across the Y axis.
        // We can also get a sub rectangle, but we'll get the full image here.
        var conversionParams = new XRCpuImage.ConversionParams(image, format, XRCpuImage.Transformation.MirrorY);

        // Texture2D allows us write directly to the raw texture data
        // This allows us to do the conversion in-place without making any copies.
        var rawTextureData = m_CameraTexture.GetRawTextureData<byte>();
        try
        {
            image.Convert(conversionParams, new IntPtr(rawTextureData.GetUnsafePtr()), rawTextureData.Length);
        }
        finally
        {
            // We must dispose of the XRCpuImage after we're finished
            // with it to avoid leaking native resources.
            image.Dispose();
        }

        // Apply the updated texture data to our texture
        m_CameraTexture.Apply();

        // Set the RawImage's texture so we can visualize it.
        
        if(Input.touchCount>0 && Input.touches[0].phase == TouchPhase.Began)
        {
            cols = m_CameraTexture.GetPixels((m_CameraTexture.width / 2)-80, (m_CameraTexture.height / 2)-80, 160, 160);
            Color col = Color.black;
            for(int i = 0; i < cols.Length; i++)
            {
                col += cols[i];
            }
            col /= cols.Length;
            ConvertColor(col);
        }
    }

    public void ConvertColor(Color col)
    {
        
        float h, s, v;
        Color.RGBToHSV(col,out h,out s,out v);
        h = Mathf.RoundToInt(h) * 360;
        s = Mathf.RoundToInt(s) * 100;
        v = Mathf.RoundToInt(v) * 100;
        Debug.Log("H: " + h + " S: " + s + " V: " + v);
        if ((h<=60 || h >= 340) && v >= 60 && s >=40)
        {
            Debug.Log("Red");
        }else if ((h >=155 && h <= 240) && v >= 10 && s >= 60)
        {
            Debug.Log("Blue");
        }else if ((h>60 && h<170) && v >= 10 && s >= 20)
        {
            Debug.Log("Green");
        }else if ((h > 255 || h<50) && v >= 35 && s > 20)
        {
            Debug.Log("Pink");
        }
        else if(v < 60)
        {
            Debug.Log("Black");
        }else if (s < 20 && v >= 60)
        {
            Debug.Log("White");
        }
                
    }
}
