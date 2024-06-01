using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    private int totalPopulation;

    public int TotalPopulation {
        get { return totalPopulation; }
        set { totalPopulation = value; }
    }

    private void OnEnable()
    {
        ResourceEvents.UpdatePopulation += UpdatePopulation;
    }    
    
    private void OnDisable()
    {
        ResourceEvents.UpdatePopulation -= UpdatePopulation;
    }

    private void UpdatePopulation(int newPopulation) 
    {
        TotalPopulation += newPopulation;
        ResourceEvents.UpdateUIPopulation?.Invoke(totalPopulation);
    }
}