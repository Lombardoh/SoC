using UnityEngine;

public class InteractionManager : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject interactonPanel;
    private IParentInteractable interactable;

    private void OnEnable()
    {
        interactable = transform.parent.GetComponent<IParentInteractable>();
    }
    private void OnTriggerEnter(Collider other)
    {
        ShowInteraction(true);
    }    
    
    private void OnTriggerExit(Collider other)
    {
        ShowInteraction(false);
    }


    public void ShowInteraction(bool show)
    {
        InteractionEvents.OnUpdateInteractableObject?.Invoke(this);
        interactonPanel.SetActive(show);
    }    
    
    public void PerformInteraction()
    {
        interactable.OnInteract();
    }
}
