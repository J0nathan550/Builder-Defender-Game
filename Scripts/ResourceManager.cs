using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }

    private Dictionary<ResourceTypeScriptableObject, int> resourceAmountDictionary = new Dictionary<ResourceTypeScriptableObject, int>();
    private void Awake()
    {
        ResourceTypeListScriptableObject resourceTypeList = Resources.Load<ResourceTypeListScriptableObject>(typeof(ResourceTypeListScriptableObject).Name);
        foreach (var resourceType in resourceTypeList.list)
        {
            resourceAmountDictionary[resourceType] = 0; 
        }
        TestLogAmountDictionary();
        Instance = this;
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
        TestLogAmountDictionary();
    }
}