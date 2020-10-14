using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRendering : MonoBehaviour
{
    private RenderTexture _renderTexture;
    public Camera Camera;
    Renderer m_Renderer;

    private void Start()
    {
        _renderTexture = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
        Camera.targetTexture = _renderTexture;
        
        m_Renderer = GetComponent<Renderer> ();

        //Make sure to enable the Keywords
        m_Renderer.material.EnableKeyword ("_NORMALMAP");
        m_Renderer.material.EnableKeyword ("_METALLICGLOSSMAP");

        //Set the Texture you assign in the Inspector as the main texture (Or Albedo)
        m_Renderer.material.SetTexture("_MainTex", _renderTexture);
    }
    
}
