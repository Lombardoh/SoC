using Pathfinding;

public class NPCManager : CharacterManager, INPCManager
{
    public ResourceType AssignedResource { get; set; } = ResourceType.Nothing;
    public UnitTaskType AssignedTask { get; set; } = UnitTaskType.Idling;

    public string unitActionTypeString;
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

    public void FindWork(ResourceType newAssignedResource)
    {
        this.AssignedResource = newAssignedResource;
        Target = ResourceUtils.FindClosestResource(this.transform, this.AssignedResource);
        TargetPosition = Target.transform.position;
        this.AssignedTask = UnitTaskType.Gathering;
        CharacterStateManager.OnStateChangeRequested(CharacterState.Following);
    }
}
