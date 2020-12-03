using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class CanvasSetter : MonoBehaviour
{
    Canvas m_Canvas;
    Camera m_Camera;

    // Start is called before the first frame update
    void Start()
    {
        m_Canvas = GetComponent<Canvas>();
        GameObject objCamera = GameObject.FindGameObjectWithTag("MainCamera");
        if (objCamera)
            m_Camera = objCamera.GetComponent<Camera>();

        if (m_Canvas && objCamera)
        {
            if (m_Canvas.renderMode == RenderMode.WorldSpace)
                m_Canvas.worldCamera = m_Camera;   
        }
        
    }

}
