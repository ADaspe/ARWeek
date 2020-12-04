using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

public class TrackImageModifier : MonoBehaviour
{
    public ARTrackedImageManager m_ARTrackedImageManager;
    public ImageAttributeObject[] m_ImageAttributeObjects;
    // Start is called before the first frame update
    void Start()
    {
        m_ARTrackedImageManager.trackedImagesChanged += CheckTrackingState;
    }

    void CheckTrackingState(ARTrackedImagesChangedEventArgs eventArgs)
    {
        ARTrackedImage trackedImage = null;

        for (int i = 0; i < eventArgs.added.Count; i++)
        {
            trackedImage = eventArgs.added[i];
            trackedImage.gameObject.SetActive(true);
            foreach(ImageAttributeObject o in m_ImageAttributeObjects)
            {
                if (trackedImage.referenceImage.name == o.imageName)
                {
                    if (!o.display)
                    {
                        GameObject instObj = Instantiate(o.imagePrefab, trackedImage.gameObject.transform);
                        Debug.Log("Display prefab" + o.imageName);
                        Debug.Log("Cam track" + Camera.main.transform.position);
                        Debug.Log("obj track" + o.imageName +" : "+ instObj.transform.position);
                        o.SetObject(instObj);
                        o.SetDisplay(true);
                    }

                }
                   
            }

            // instantiate AR object, set trackedImage.transform
            // use a Dictionary, the key could be the trackedImage, or the name of the reference image -> trackedImage.referenceImage.name
            // the value of the Dictionary is the AR object you instantiate.
        }

        for (int i = 0; i < eventArgs.updated.Count; i++)
        {
            trackedImage = eventArgs.updated[i];
            if (trackedImage.trackingState == TrackingState.Tracking)
            //if (trackedImage.trackingState != TrackingState.None)
            {
                trackedImage.gameObject.SetActive(true);
                // set AR object to active, use Dictionary to get AR object based on trackedImage
                // you can also include TrackingState.Limited by checking for None
            }
            else
            {
                trackedImage.gameObject.SetActive(false);
                // set active to false
            }
        }

        for (int i = 0; i < eventArgs.removed.Count; i++)
        {
            trackedImage = eventArgs.removed[i];
           
            // destroy AR object, or set active to false. Use Dictionary.
        }
    }


    [Serializable]
    public struct ImageAttributeObject
    {
        public string imageName;
        public GameObject imagePrefab;
        [HideInInspector]
        public GameObject imageObject;
        [HideInInspector]
        public bool display;
        public void SetDisplay(bool state)
        {
            display = state;
        }
        public void SetObject(GameObject iObject)
        {
            imageObject = iObject;
        }
    }
}
