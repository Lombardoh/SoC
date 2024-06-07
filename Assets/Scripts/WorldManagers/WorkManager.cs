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

    private  void ChangeWorkingAmount(WorkType work, ActionType action)
    {
        UnitEvents.OnRequestUnit?.Invoke((unit) => OnUnitReceived(unit, work));
    }

    private void OnUnitReceived(CharacterManager unit, WorkType work)
    {
        if (unit == null) {return; }
        units.Add(unit);
        unit.target = UnitUtils.FindClosestTarget(unit.transform, TagType.Tree);
        unit.characterStateManager.OnStateChangeRequested(CharacterStateEnum.Following);
    }
}
