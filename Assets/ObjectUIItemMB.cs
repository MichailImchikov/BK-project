using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ObjectUIItemMB : MonoBehaviour
{
    [SerializeField] private Toggle selectionToggle;
    [SerializeField] private Toggle visibilityToggle;
    [SerializeField] private TextMeshProUGUI objectNameText;

    private ObjectData objectData;
    private CompositeDisposable disposables;

    public void Initialize(ObjectData data)
    {
        objectData = data;
        disposables = new CompositeDisposable();
        objectNameText.text = data.objectName;

        SetupBindings();
    }

    private void SetupBindings()
    {
        objectData.isSelected.Subscribe(isSelected =>
        {
            selectionToggle.isOn = isSelected;
        }).AddTo(disposables);
        selectionToggle.OnValueChangedAsObservable().Subscribe(isSelected =>
            {
                objectData.isSelected.Value = isSelected;
            })
            .AddTo(disposables);

        objectData.isVisible.Subscribe(isVisible =>
        {
            visibilityToggle.isOn = isVisible;
        }).AddTo(disposables);
        visibilityToggle.OnValueChangedAsObservable().Subscribe(isVisible =>
            {
                objectData.isVisible.Value = isVisible;
            })
            .AddTo(disposables);
    }

    private void OnDestroy()
    {
        disposables?.Dispose();
    }
}
