using System;
using UniRx;
using UnityEngine;

public class ObjectData 
{
    public string objectName;
    public GameObject gameObject;
    public ReactiveProperty<bool> isVisible;
    public ReactiveProperty<float> transparency;
    public ReactiveProperty<Color> color;
    public ReactiveProperty<bool> isSelected;

    public ObjectData(GameObject go)
    {
        gameObject = go;
        objectName = go.name;
        isVisible = new ReactiveProperty<bool>(true);
        transparency = new ReactiveProperty<float>(1f);
        color = new ReactiveProperty<Color>(go.GetComponent<Renderer>().material.color);
        isSelected = new ReactiveProperty<bool>(false);
    }

}
