public class Character 
{
    public int ResourceAmount { get; set; }
    public int ResourceCapacity { get; set; }

    public Character(int resourceAmount, int resourceCapacity)
    {
        ResourceAmount = resourceAmount;
        ResourceCapacity = resourceCapacity;
    }
}
