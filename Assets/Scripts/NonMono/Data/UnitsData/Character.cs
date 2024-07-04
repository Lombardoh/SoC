public class Unit 
{
    public int ResourceAmount { get; set; }
    public int ResourceCapacity { get; set; }
    public Unit(int resourceAmount, int resourceCapacity)
    {
        ResourceAmount = resourceAmount + 15;
        ResourceCapacity = resourceCapacity;
    }
}
