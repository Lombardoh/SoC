using UnityEngine;

public class NPCManager : CharacterManager, ICharacterManager
{
    public ResourceType AssignedResource { get; set; } = ResourceType.Nothing;

    protected override void Awake()
    {
        base.Awake();
    }

    public void FindWork(ResourceType newAssignedResource)
    {
        this.AssignedResource = newAssignedResource;
        Target = ResourceUtils.FindClosestResource(this.transform, this.AssignedResource);
        CharacterStateManager.OnStateChangeRequested(CharacterState.Following);
    }
}
