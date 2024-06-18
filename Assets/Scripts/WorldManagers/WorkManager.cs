using System.Collections.Generic;
using UnityEngine;

public class WorkManager : MonoBehaviour
{
    private List<CharacterManager> units = new ();
    private void OnEnable()
    {
        WorkEvents.ChangeWorkingAmount += ChangeWorkingAmount;
    }

    private void OnDisable()
    {
        WorkEvents.ChangeWorkingAmount -= ChangeWorkingAmount;
    }

    private  void ChangeWorkingAmount(WorkType work, ActionType action)
    {
        UnitEvents.OnRequestUnit?.Invoke((unit) => OnUnitReceived(unit, work));
    }

    private void OnUnitReceived(CharacterManager unit, WorkType work)
    {

    }
}
