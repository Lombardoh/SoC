using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CityManager : MonoBehaviour, IPointerClickHandler, ITickListener, IDepositable
{
    private City city;
    private CityResourceManager cityResourceManager;
    public GameObject cityPanel;
    public TextMeshProUGUI resources;
    [SerializeField]private float growPopulation = 17;

    private void OnEnable()
    {
        UnitEvents.OnCheckPopulation += (callback) => callback(CheckPopulation());
        ResourceEvents.OnGetLowestResource+= (callback) => callback(GetLowestResource());
    }

    private void OnDisable()
    {
        UnitEvents.OnCheckPopulation -= (callback) => callback(CheckPopulation());
        ResourceEvents.OnGetLowestResource += (callback) => callback(GetLowestResource());
    }

    private void Awake()
    {
        city = new(0, 1, 0, 1);
        cityResourceManager = GetComponent<CityResourceManager>();
    }

    private void Start()
    {
        SubscribeToTicks(TickTime.Large);
        cityResourceManager.UpdateResources();
    }
    private int CheckPopulation()
    {
        return city.Population;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        cityPanel.SetActive(true);
    }

    private ResourceType GetLowestResource()
    {
        return city.GetResourceWithLowestAmount();
    }

    public Dictionary<ResourceType, int> GetResources()
    {
        return city.resources;
    }
    public void SubscribeToTicks(TickTime tickTime)
    {
        TimeEvents.OnRegisterTickListenerRequested.Invoke(this, tickTime);
    }    
    
    public void UnsubscribeToTicks()
    {
        UnsubscribeToTicks(TickTime.Large);
    }    

    private void UnsubscribeToTicks(TickTime tickTime)
    {
        TimeEvents.OnRegisterTickListenerRequested.Invoke(this, tickTime);
    }

    public void OnTicked()
    {
        growPopulation += city.Growth;
        if (growPopulation > Constants.populationGrowThreshold && Constants.populationGrowLimit > city.Population) 
        {
            city.Population += 1;
            growPopulation = 0;
            ResourceEvents.OnUpdatePopulation?.Invoke(1);
        }
    }

    public void Deposite(ResourceType resourceType, int amount)
    {
        city.resources[resourceType] += amount;
        cityResourceManager.UpdateResources();
    }
}
