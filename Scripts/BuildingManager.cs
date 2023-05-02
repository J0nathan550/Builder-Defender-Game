using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private Transform woodHarvesterObject; 
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;   
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(woodHarvesterObject, getMouseWorldPosition(), Quaternion.identity);
        }
    }

    private Vector3 getMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        return mouseWorldPosition;
    }
}