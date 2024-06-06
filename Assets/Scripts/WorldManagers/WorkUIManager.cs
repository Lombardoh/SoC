using TMPro;
using UnityEngine;

public class WorkUIManager : MonoBehaviour
{
    private int idleAmount;
    private int loggingAmount;
    private int miningAmount;

    [SerializeField] private TextMeshProUGUI idleText;
    [SerializeField] private TextMeshProUGUI loggingText;
    [SerializeField] private TextMeshProUGUI miningText;

    private void OnEnable()
    {
        WorkEvents.ChangeWorkingAmount += ChangeWorkingAmount;
    }    
    
    private void OnDisable()
    {
        WorkEvents.ChangeWorkingAmount -= ChangeWorkingAmount;
    }

    private void ChangeWorkingAmount(WorkType work, ActionType action)
    {
        switch (work) 
        { 
            case WorkType.Idle:
                ModifyAmount(action, idleText, ref idleAmount);
                break;
            case WorkType.Logging:
                ModifyAmount(action, loggingText, ref loggingAmount);
                break;
            case WorkType.Mining:
                ModifyAmount(action, miningText, ref miningAmount);
                break;
        }
    }

    private void ModifyAmount(ActionType action, TextMeshProUGUI text, ref int amount) 
    {
        amount = action == ActionType.Add ? amount + 1 : amount - 1;
        text.text = amount.ToString();
    }
}
