using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SettlementManager : MonoBehaviour, IPointerClickHandler, ITickListener, IDepositable, IResource
{
    public SettlementType settlementType;
    protected Settlement settlement;
    protected SettlementUIResourceManager settlementUIResourceManager;
    protected SettlementUnitsManager settlementUnitsManager;
    protected IUnitManager iUnitManager;
    public GameObject settlementPanel;
    public TextMeshProUGUI resources;
    [SerializeField]protected float growPopulation = 19;
    public bool Selected { get; set; } = false;
    public bool GetSelected()
    {
        return Selected;
    }    
    public ResourceType GetLowestResource()
    {
        City city = settlement as City;
        return city.GetResourceWithLowestAmount();
    }
    public Dictionary<ResourceType, int> GetResources()
    {
        return settlement.Resources;
    }
    public int GetResourceAmount(ResourceType resourceType)
    {
        return settlement.Resources[resourceType];
    }
    public SettlementUIResourceManager GetSettlementUIResourceManager()
    { 
        return settlementUIResourceManager;
    }
    public SettlementManager GetSettlementManager()
    {
        return this;
    }

    protected virtual void Awake()
    {
        settlement = SettlementFactory.CreateSettlement(settlementType);
        settlementUIResourceManager = GetComponent<SettlementUIResourceManager>();
        settlementUnitsManager = GetComponent<SettlementUnitsManager>();
    }
    private void Start()
    {
        ((ITickListener)this).SubscribeToTicks(TickTime.Large);
        settlementUIResourceManager.UpdateResources();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        settlementPanel.SetActive(!settlementPanel.activeSelf);
        Selected = !Selected;
        Debug.Log(Selected);
        BuildingEvents.OnUpdateSelectedBuilding?.Invoke(this);
    }  
    public virtual void OnTicked() { }
}
