using System;
using UnityEngine;
using UnityEngine.UI;
public class AllSelectedButtonMB : MonoBehaviour
{
    public static AllSelectedButtonMB Instance { get; private set; }
    public event Action<bool> ChangeAllStatus;
    public Text TextMeshProUGUI;
    private bool _state;
    private void Awake()
    {
        Instance = this;
        if (!TextMeshProUGUI)
        {
            TextMeshProUGUI = GetComponentInChildren<Text>();
            Debug.LogError("Add a link to the button text to the prefab");
        }
        TextMeshProUGUI.text = "";
    }
    public void ChangeStateRow(RowControllerMB row, bool active)
    {
        if(_state && !active)
        {
            _state = false;
            Activate(_state);
        }
    }
    public void Click()
    {
        _state = !_state;
        ChangeAllStatus?.Invoke(_state);
        Activate(_state);
    }
    private void Activate(bool isActive)
    {
        if (isActive) TextMeshProUGUI.text = "V";
        else TextMeshProUGUI.text = "";
    }
}
