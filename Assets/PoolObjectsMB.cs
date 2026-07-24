using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PoolObjectsMB : MonoBehaviour
{
    public Material CustomMaterial;
    public List<Renderer> CustomizableObjects = new ();
    public void Start()
    {
        CustomizableObjects = new();
        CustomizableObjects = GetComponentsInChildren<Renderer>().ToList();
        CustomizableObjects.ForEach(x => x.material = CustomMaterial);
        CustomizableObjects.ForEach(x => SettingMenuMB.NewObject?.Invoke(new ObjectController(x)));

    }
}
