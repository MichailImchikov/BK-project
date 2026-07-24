using System;
using UnityEngine;

public class ObjectController 
{
    private Renderer _renderer;
    public string Name => _renderer.name;
    public ObjectController(Renderer renderer)
    {
        _renderer = renderer;
    }
    public void TransparencyChange(float transparencyValue)
    {
        Color color = _renderer.material.color;
        color.a = transparencyValue;
        _renderer.material.color = color;
    }
    public void ColorChange(Color color)
    {
        color.a = _renderer.material.color.a;
        _renderer.material.color = color;
    }
    
}
