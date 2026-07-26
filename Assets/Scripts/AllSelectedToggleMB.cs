using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AllSelectedToggleMB : MonoBehaviour
{
    private Toggle _toggle;
    private int _notSelectedCount = 0;
    public bool isProgramChange { get; private set; }
    public void Init(UnityAction<bool> change)
    {
        _toggle = GetComponent<Toggle>();
        _toggle.onValueChanged.AddListener(change);
        MessageBroker.Default.Receive<NewInteractiveObjectEvent>().Subscribe(newObject =>
        {
            newObject.Data.isSelected.Subscribe(value =>
            {
                if (value)
                {
                    _notSelectedCount--;
                    if (_notSelectedCount == 0) ProgrammChangeValue(true);
                }
                else
                {
                    _notSelectedCount++;
                    if (_toggle.isOn) ProgrammChangeValue(false);
                }

            }).AddTo(this);
        }).AddTo(this);
    }
    private void ProgrammChangeValue(bool value)
    {
        isProgramChange = true;
        _toggle.isOn = value;
        isProgramChange = false;
    }
}
