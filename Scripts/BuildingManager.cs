using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField] private Transform mouseVisualTransform;

    private void Start()
    {
        mainCamera = Camera.main;   
    }
    
    private void Update()
    {
        mouseVisualTransform.position = getMouseWorldPosition();
    }

    private Vector3 getMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        return mouseWorldPosition;
    }
}