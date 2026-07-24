using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedButtonMB : MonoBehaviour
{
    public Text TextMeshProUGUI;
    private Action _clickEvent;
    private void Start()
    {
        if(!TextMeshProUGUI)
        {
            TextMeshProUGUI = GetComponentInChildren<Text>();
            Debug.LogError("Add a link to the button text to the prefab");
        }
        TextMeshProUGUI.text = "";
    }
    public void Init(Action clickEvent)
    {
        _clickEvent = clickEvent;
    }
    public void Click()
    {
        _clickEvent?.Invoke();
    }
    public void Activate(bool isActive)
    {
        if (isActive) TextMeshProUGUI.text = "V";
        else TextMeshProUGUI.text = "";
    }
}
