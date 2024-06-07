using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CityManager : MonoBehaviour, IPointerClickHandler, ITickListener
{
    private City city;
    public GameObject panel;
    public TextMeshProUGUI resources;
    private float growPopulation = 0;

    private void OnEnable()
    {
        UnitEvents.OnCheckPopulation += (callback) => callback(CheckPopulation());
    }

    private void OnDisable()
    {
        UnitEvents.OnCheckPopulation -= (callback) => callback(CheckPopulation());
    }

    private int CheckPopulation()
    {
        return city.Population;
    }

    private void Awake()
    {
        city = new(20, 1);
    }

    private void Start()
    {
        SubscribeToTicks(TickTime.Large);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UpdateUI();
        panel.SetActive(true);
    }

    private void UpdateUI()
    {
        resources.text = city.Population.ToString() + " " + city.Growth.ToString();
    }

    public void SubscribeToTicks(TickTime tickTime)
    {
        TimeEvents.OnRegisterTickListenerRequested.Invoke(this, tickTime);
    }    
    
    public void UnsubscribeToTicks(TickTime tickTime)
    {
        TimeEvents.OnRegisterTickListenerRequested.Invoke(this, tickTime);
    }

    public void OnTicked()
    {
        growPopulation += city.Growth;
        if (growPopulation > Constants.populationGrowThreshold) 
        {
            city.Population += 1;
            growPopulation = 0;
            UpdateUI();
            ResourceEvents.UpdatePopulation?.Invoke(1);
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
