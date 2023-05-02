using Mono.Cecil;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField] private Transform resourceTemplate;
    private ResourceTypeListScriptableObject resourceTypeList;
    private Dictionary<ResourceTypeScriptableObject, Transform> resourceTypeTransformDictionary; 
    private float xPos;
    
    private void Awake()
    {
        resourceTemplate.gameObject.SetActive(false);
        resourceTypeList = Resources.Load<ResourceTypeListScriptableObject>(typeof(ResourceTypeListScriptableObject).Name);
       
        resourceTypeTransformDictionary = new Dictionary<ResourceTypeScriptableObject, Transform>();

        bool index = false;
        foreach (var resourceType in resourceTypeList.list)
        {
            Transform resource = Instantiate(resourceTemplate, transform);
            resource.gameObject.SetActive(true);
            if (!index)
            {
                xPos = 115f;
            }
            else
            {
                xPos += 200f;
            }
            resource.GetComponent<RectTransform>().anchoredPosition = new Vector2(-xPos, 0);
            resource.Find("image").GetComponent<Image>().sprite = resourceType.sprite;

            resourceTypeTransformDictionary[resourceType] = resource;
            index = true;
        }   
    }

    private void Start()
    {
        ResourceManager.Instance.OnResourceAmountChanged += ResourceManager_OnResourceAmountChanged;
        UpdateResourceAmount();
    }

    private void ResourceManager_OnResourceAmountChanged(object sender, System.EventArgs e)
    {
        UpdateResourceAmount();
    }

    private void UpdateResourceAmount()
    {
        foreach (var resourceType in resourceTypeList.list)
        {
            int resourceAmount = ResourceManager.Instance.GetResourceAmount(resourceType);
            Transform resourceTransform = resourceTypeTransformDictionary[resourceType];
            resourceTransform.Find("counter").GetComponent<TextMeshProUGUI>().SetText(resourceAmount.ToString());
        }
    }
}