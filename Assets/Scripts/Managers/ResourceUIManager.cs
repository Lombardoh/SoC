using TMPro;
using UnityEngine;

public class ResourceUIManager : MonoBehaviour
{
    public TextMeshProUGUI population;

    private void OnEnable()
    {
        ResourceEvents.UpdateUIPopulation += UpdatePopulation;
    }

    private void OnDisable()
    {
        ResourceEvents.UpdateUIPopulation -= UpdatePopulation;
    }

    private void UpdatePopulation(int totalPopulation)
    {
        population.text = totalPopulation.ToString();
    }
}
