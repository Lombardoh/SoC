using Pathfinding;
using UnityEngine;

public class NPCManager : CharacterManager, INPCManager
{
    public ResourceType AssignedResource { get; set; } = ResourceType.Nothing;
    public UnitTaskType AssignedTask { get; set; } = UnitTaskType.Idling;
    public UnitTaskType NextAssignedTask { get; set; } = UnitTaskType.Idling;

    public string unitActionTypeString;
    public string unitAssignedResourceString;
    public DynamicGridObstacle DynamicGridObstacle { get; set; }
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
        DynamicGridObstacle = gameObject.AddComponent<DynamicGridObstacle>();
        unitActionTypeString = AssignedTask.ToString(); //remove once panel
    }
    protected override void Update()
    {
        base.Update();
    }
    public override void OnTicked()
    {
        character.ResourceAmount += 1;
        if (character.ResourceAmount >= character.ResourceCapacity)
        {
            CharacterStateManager.OnSelectNextState(NextAssignedTask);
        }
    }
    public void FindWork(ResourceType newAssignedResource)
    {
        AssignedResource = newAssignedResource;
        unitAssignedResourceString = newAssignedResource.ToString();
        AssignedTask = UnitTaskType.GoingToGather;
        CharacterStateManager.OnSelectNextState(AssignedTask);
    }
}
