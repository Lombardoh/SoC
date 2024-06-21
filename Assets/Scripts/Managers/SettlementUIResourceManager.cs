using UnityEngine;
using TMPro;

public class SettlementUIResourceManager : MonoBehaviour
{
    SettlementManager settlementManager;
    public Transform resourcePanel;
    private void Awake()
    {
        settlementManager = GetComponent<SettlementManager>();
    }

    public void UpdateResources()
    {
        foreach (Transform child in resourcePanel)
        {
            Destroy(child.gameObject);
        }

        float yOffset = 2f;
        int index = 0;

        foreach (var resource in settlementManager.GetResources())
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
