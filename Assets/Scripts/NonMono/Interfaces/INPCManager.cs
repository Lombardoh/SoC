public interface INPCManager
{
    public UnitTaskType AssignedTask { get; set; }
    public UnitTaskType NextAssignedTask { get; set; }
    public ResourceType AssignedResource { get; set; }
}
