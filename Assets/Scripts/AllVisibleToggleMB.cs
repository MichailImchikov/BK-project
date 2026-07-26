using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AllVisibleToggleMB : MonoBehaviour
{
    private Toggle _toggle;
    private int h = 0;
    public bool isProgramChange { get; private set; }
    public void Init(UnityAction<bool> change)
    {
        _toggle = GetComponent<Toggle>();
        _toggle.onValueChanged.AddListener(change);
        MessageBroker.Default.Receive<NewInteractiveObjectEvent>().Subscribe(newObject =>
        {
            newObject.Data.isVisible.Subscribe(value =>
            {
                if (value)
                {
                    h--;
                    if (h == 0) ProgrammChangeValue(true);
                }
                else
                {
                    h++;
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
