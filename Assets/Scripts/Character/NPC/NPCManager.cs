using Pathfinding;
using UnityEditor.SceneManagement;
using UnityEngine;

public class NPCManager : CharacterManager, INPCManager
{
    public ResourceType AssignedResource { get; set; } = ResourceType.Nothing;
    public UnitActionType UnitActionType { get; set; } = UnitActionType.Idling;

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
    }
    protected override void Update()
    {
        base.Update();
        unitActionTypeString = UnitActionType.ToString();
    }

    public void FindWork(ResourceType newAssignedResource)
    {
        this.AssignedResource = newAssignedResource;
        Target = ResourceUtils.FindClosestResource(this.transform, this.AssignedResource);
        this.UnitActionType = UnitActionType.Gathering;
        CharacterStateManager.OnStateChangeRequested(CharacterState.Following);
    }
}
