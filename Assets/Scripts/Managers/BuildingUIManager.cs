using UnityEngine;

public class BuildingUIManager : MonoBehaviour
{
    public Transform resourcePanel;
    private SettlementManager selectedSettlement;
    private void OnEnable()
    {
        ResourceEvents.OnUpdateBuildingUIManager += UpdateBuildingUIManager;
        BuildingEvents.OnUpdateSelectedBuilding += UpdateSelectedBuilding;
    }

    private void OnDisable()
    {
        ResourceEvents.OnUpdateBuildingUIManager -= UpdateBuildingUIManager;
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
        UpdateBuildingUIManager(selectedSettlement);
    }
    private void UpdateBuildingUIManager(SettlementManager settlementManager)
    {
        CleanChilds(resourcePanel);
        if (selectedSettlement == null) { return; }

        float yOffset = 2;
        int index = 0;

        foreach (var resource in settlementManager.GetResources())
        {
            Vector3 positionOffset = new(0, -index * yOffset + 8.5f, 0);
            GameObject resourceText = UIUtils.CreateResourceText(resourcePanel, resource.Key.ToString());
            resourceText.transform.SetLocalPositionAndRotation(positionOffset + Vector3.right * 3, Quaternion.identity);

            resourceText = UIUtils.CreateResourceText(resourcePanel, resource.Value.ToString());
            resourceText.transform.SetLocalPositionAndRotation(positionOffset + Vector3.right * 15, Quaternion.identity);

            index++;
        }
    }
}
