
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

class MainMenuObjectController : MonoBehaviour
{
    [SerializeField] private VerticalLayoutGroup content;
    [SerializeField] private ObjectUIItemMB objectUIItem;
    [SerializeField] private Slider transparencySlider;
    [SerializeField] private AllSelectedToggleMB allSelectedToggleMB;
    [SerializeField] private AllVisibleToggleMB allVisibleToggleMB;
    private List<ObjectData> _objectsData = new();
    private void Awake()
    {
        MessageBroker.Default.Receive<NewInteractiveObjectEvent>().Subscribe(msg =>
            {
                NewObjectEvent(msg.Data);
            })
            .AddTo(this);
        transparencySlider.onValueChanged.AddListener(UpdateTransparencyClick);
        allSelectedToggleMB.Init(AllSelectedClick);
        allVisibleToggleMB.Init(AllVisibleClick);
    }
    private void NewObjectEvent(ObjectData data)
    {
        var newObject = Instantiate<ObjectUIItemMB>(objectUIItem, content.transform);
        newObject.Initialize(data);
        _objectsData.Add(data);
    }
    private void UpdateTransparencyClick(float value)
    {
        foreach(var objectData in _objectsData)
        {
            if (!objectData.isSelected.Value) continue;
            objectData.transparency.Value = value;
        }
    }
    private void AllSelectedClick(bool value)
    {
        if(!allSelectedToggleMB.isProgramChange)
            _objectsData.ForEach(x => x.isSelected.Value = value);
    }
    private void AllVisibleClick(bool value)
    {
        if (!allVisibleToggleMB.isProgramChange)
            _objectsData.ForEach(x => x.isVisible.Value = value);
    }
}

