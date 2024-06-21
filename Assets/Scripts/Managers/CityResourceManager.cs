using UnityEngine;
using TMPro;

public class CityResourceManager : MonoBehaviour
{
    CityManager cityManager;
    public Transform resourcePanel;

    private void Awake()
    {
        cityManager = GetComponent<CityManager>();
    }

    public void UpdateResources()
    {
        foreach (Transform child in resourcePanel)
        {
            Destroy(child.gameObject);
        }

        float yOffset = 2f;
        int index = 0;

        foreach (var resource in cityManager.GetResources())
        {
            Vector3 positionOffset = new(0, -index * yOffset + 3, 0);

            GameObject resourceText = UIUtils.CreateResourceText(resourcePanel, resource.Key.ToString());
            resourceText.transform.localPosition = positionOffset+ Vector3.right * 3;            
            
            resourceText = UIUtils.CreateResourceText(resourcePanel, resource.Value.ToString());
            resourceText.transform.localPosition = positionOffset + Vector3.right * 9;

            index++;
        }
    }
}
