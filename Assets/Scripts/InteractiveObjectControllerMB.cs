using UniRx;
using UnityEngine;

public class InteractiveObjectControllerMB : MonoBehaviour
{
    private ObjectData _data;
    private Renderer _objectRenderer;

    public void Start()
    {
        _objectRenderer = GetComponent<Renderer>();
        _data = new(this.gameObject);
        SetupReactiveBindings();
        MessageBroker.Default.Publish(new NewInteractiveObjectEvent(_data));
    }
    private void SetupReactiveBindings()
    {
        _data.isVisible.Subscribe(isVisible =>
        {
            if (gameObject != null)
                gameObject.SetActive(isVisible);
        }).AddTo(this);

        _data.transparency.Subscribe(alpha =>
        {
            UpdateTransparency(alpha);
        }).AddTo(this);

        _data.color.Subscribe(color =>
        {
            UpdateColor(color);
        }).AddTo(this);
    }

    private void UpdateTransparency(float alpha)
    {
        if (_objectRenderer != null)
        {
            Color color = _objectRenderer.material.color;
            color.a = alpha;
            _objectRenderer.material.color = color;
        }
    }
    private void UpdateColor(Color color)
    {
        if (_objectRenderer.material != null)
        {
            Color currentColor = _objectRenderer.material.color;
            color.a = currentColor.a;
            _objectRenderer.material.color = color;
        }
    }
    private void OnDestroy()
    {
        if (_objectRenderer.material != null)
            Destroy(_objectRenderer.material);
    }
}