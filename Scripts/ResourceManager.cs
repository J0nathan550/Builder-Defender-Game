using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private Dictionary<ResourceTypeScriptableObject, int> resourceAmountDictionary = new Dictionary<ResourceTypeScriptableObject, int>();
    private void Awake()
    {
        ResourceTypeListScriptableObject resourceTypeList = Resources.Load<ResourceTypeListScriptableObject>(typeof(ResourceTypeListScriptableObject).Name);
        foreach (var resourceType in resourceTypeList.list)
        {
            resourceAmountDictionary[resourceType] = 0; 
        }
        TestLogAmountDictionary();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ResourceTypeListScriptableObject resourceTypeList = Resources.Load<ResourceTypeListScriptableObject>(typeof(ResourceTypeListScriptableObject).Name);
            AddResource(resourceTypeList.list[0], 2);
            TestLogAmountDictionary();
        }
    }

    private void TestLogAmountDictionary()
    {
        foreach (var resource in resourceAmountDictionary.Keys)
        {
            Debug.Log(resource.nameString + ": " + resourceAmountDictionary[resource]);
        }
    }

    public void AddResource(ResourceTypeScriptableObject resourceType, int amount)
    {
        resourceAmountDictionary[resourceType] += amount;
    }
}