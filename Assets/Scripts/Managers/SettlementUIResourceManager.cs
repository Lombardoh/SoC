using System.Collections.Generic;
using UnityEngine;

public class SettlementUIResourceManager : MonoBehaviour
{
    public SettlementManager settlementManager;
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
        if (settlementManager.Selected)
        {
            ResourceEvents.OnUpdateBuildingUIManager?.Invoke(settlementManager);
        }

        Dictionary<ResourceType, int> resources = settlementManager.GetResources();
        Color color = ColorUtils.GetColor(ColorType.ResourceText);

        UIUtils.CreatePanelInformation(resourcePanel.transform, resources, color, 2, 2, 15);
    }
}
