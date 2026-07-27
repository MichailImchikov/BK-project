using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraDollyMB : MonoBehaviour
{
    [SerializeField] private float sensitivity = 5f;
    [SerializeField] private float rotateSensitivity = 5f;
    private float _mouseY;
    private float _mouseX;
    private float scroll;
    [SerializeField] private List<InteractiveObjectControllerMB> newInteractiveObjects;
    [SerializeField] private GameObject PoolObject;
    void Update()
    {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) return;

        _mouseY = Input.GetAxis("Mouse Y");
        _mouseX = Input.GetAxis("Mouse X");
        scroll = Input.GetAxis("Mouse ScrollWheel");
        if(scroll != 0)
        {
            transform.Translate(new Vector3(0, 0, scroll) * sensitivity*2);
        }
        if (Input.GetMouseButton(0))
        {
            var vectorMove = new Vector3(_mouseX, _mouseY, 0);
            transform.Translate(-vectorMove * sensitivity);
        }
        if (Input.GetMouseButtonDown(0))
        {
            TrySelectObject();
        }
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(Vector3.up, _mouseX * rotateSensitivity, Space.World);
            transform.Rotate(Vector3.right, -_mouseY * rotateSensitivity, Space.Self);
            Vector3 currentRotation = transform.eulerAngles;
            float angleX = currentRotation.x;
            if (angleX > 180) angleX -= 360;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            CreateNewObject();
        }
    }
    
    private void TrySelectObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            InteractiveObjectControllerMB interactive = hit.collider.GetComponent<InteractiveObjectControllerMB>();

            if (interactive is null) return;
            interactive.OnMouseClick();
        }
    }
    private void CreateNewObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Instantiate(newInteractiveObjects[Random.Range(0,newInteractiveObjects.Count)], hit.point, Quaternion.identity);
        }
    }
}
