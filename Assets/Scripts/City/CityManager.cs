using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CityManager : MonoBehaviour, IPointerClickHandler, ITickListener
{
    private City city;
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
    }

    private void Start()
    {
        SubscribeToTicks(TickTime.Large);
    }
    private int CheckPopulation()
    {
        return city.Population;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        UpdateUI();
        cityPanel.SetActive(true);
    }

    private ResourceType GetLowestResource()
    {
        return city.GetResourceWithLowestAmount();
    }

    private void UpdateUI()
    {
        resources.text = city.Population.ToString();
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
        if (growPopulation > Constants.populationGrowThreshold && Constants.populationGrowLimit >= city.Population) 
        {
            city.Population += 1;
            growPopulation = 0;
            UpdateUI();
            ResourceEvents.OnUpdatePopulation?.Invoke(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == null) return;

        if (other.TryGetComponent<IWorkable>(out var characterManager))
        {
            characterManager.UnloadCargo();
        }
    }
}
