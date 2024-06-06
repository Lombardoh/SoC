using System.Collections.Generic;
using UnityEngine;

public class WorkManager : MonoBehaviour
{
    private List<CharacterManager> units = new List<CharacterManager>();
    private void OnEnable()
    {
        WorkEvents.ChangeWorkingAmount += ChangeWorkingAmount;
    }

    private void OnDisable()
    {
        WorkEvents.ChangeWorkingAmount -= ChangeWorkingAmount;
    }

    public void ChangeWorkingAmount(WorkType work, ActionType action)
    {
        UnitEvents.OnRequestUnit?.Invoke();
    }

}
