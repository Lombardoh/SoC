using System.Collections.Generic;
using UnityEngine;

public class SelectedUI : MonoBehaviour
{
    public Transform resourcePanel;
    private SettlementManager selectedSettlement;
    private void OnEnable()
    {
        ResourceEvents.OnUpdateBuildingUIManager += UpdateSelected;
        BuildingEvents.OnUpdateSelectedBuilding += UpdateSelectedBuilding;
    }

    private void OnDisable()
    {
        ResourceEvents.OnUpdateBuildingUIManager -= UpdateSelected;
        BuildingEvents.OnUpdateSelectedBuilding -= UpdateSelectedBuilding;
        
    }

    private void CleanChilds(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }
    private void UpdateSelectedBuilding(SettlementManager settlementManager)
    {
        if (settlementManager.Selected == false) { CleanChilds(resourcePanel); return; }
        if(selectedSettlement != null && selectedSettlement != settlementManager)
        {
            selectedSettlement.Selected = false;
        }
        selectedSettlement = settlementManager;
        UpdateSelected(selectedSettlement);
    }
    private void UpdateSelected(SettlementManager settlementManager)
    {
        CleanChilds(resourcePanel);
        if (selectedSettlement == null) { return; }

        Color color = ColorUtils.GetColor(ColorType.ResourceText);
        Dictionary<ResourceType, int> resouces = settlementManager.GetResources();
        UIUtils.CreatePanelInformation(resourcePanel.transform, resouces, color, 40, 60, 300);
    }
}
