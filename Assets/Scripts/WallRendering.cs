using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class WallRendering : MonoBehaviour
{
    private Renderer _renderer;
    
    public Color startColor; 

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Reset()
    {
        startColor = _renderer.sharedMaterial.color;
    }
}
