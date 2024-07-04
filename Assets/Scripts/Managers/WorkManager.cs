using System.Collections.Generic;
using UnityEngine;

public class WorkManager : MonoBehaviour
{
    private List<UnitManager> units = new ();
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

    private void OnUnitReceived(UnitManager unit, WorkType work)
    {

    }
}
