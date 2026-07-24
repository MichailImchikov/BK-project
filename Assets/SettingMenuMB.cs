using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenuMB : MonoBehaviour
{
    public static Action<ObjectController> NewObject;
    public RowControllerMB RowPrefab;

    private Dictionary<RowControllerMB, ObjectController> _viewObject;
    private List<RowControllerMB> _activeObject;
    private List<RowControllerMB> _notActiveObject;
    private void Start() 
    {
        NewObject += NewObjectEvent;
        _activeObject = new();
        _notActiveObject = new();
        _viewObject = new();
    }
    private void NewObjectEvent(ObjectController objectController)
    {
        var rowController = Instantiate<RowControllerMB>(RowPrefab, transform);
        _notActiveObject.Add(rowController);
        _viewObject.Add(rowController, objectController);
        rowController.StatusChange += ChangeRowActive;
        rowController.Init(objectController.Name);
    }
    private void ChangeRowActive(RowControllerMB row, bool active)
    {
        if(active)
        {
            _notActiveObject.Remove(row);
            _activeObject.Add(row);
        }
        else
        {
            _notActiveObject.Add(row);
            _activeObject.Remove(row);
        }
    }
    public void SetTransparency(float transperency)
    {
        _activeObject.ForEach(x => _viewObject[x].TransparencyChange(transperency));
    }
    public void SetColor(Color color)
    {
        _activeObject.ForEach(x => _viewObject[x].ColorChange(color));
    }
}
