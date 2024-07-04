using Pathfinding;

public class NPCManager : UnitManager, INPCManager
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
        unitActionTypeString = AssignedTask.ToString();
    }
    public override void OnTicked()
    {
        unit.ResourceAmount += 1;
        if (unit.ResourceAmount >= unit.ResourceCapacity)
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
