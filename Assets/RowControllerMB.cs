using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class RowControllerMB : MonoBehaviour
{
    public SelectedButtonMB SelectedButton;
    public event Action<RowControllerMB,bool> StatusChange;
    public TextMeshProUGUI Text;
    private bool _stateActive;
    private Action click;
    void Start()
    {
        if (Text is null) Text = GetComponentInChildren<TextMeshProUGUI>();
        if(SelectedButton == null) SelectedButton = GetComponentInChildren<SelectedButtonMB>();
        click += Click;
        SelectedButton.Init(click);
        StatusChange += AllSelectedButtonMB.Instance.ChangeStateRow;
        AllSelectedButtonMB.Instance.ChangeAllStatus += AllActivate;
    }
    public void Init(string name)
    {
        Text.text = name;
    }
    private void Click()
    {
        _stateActive = !_stateActive;
        SelectedButton.Activate(_stateActive);
        StatusChange?.Invoke(this,_stateActive);
    }
    public void AllActivate(bool state)
    {
        _stateActive = state;
        SelectedButton.Activate(_stateActive);
        StatusChange?.Invoke(this, _stateActive);
    }
}
