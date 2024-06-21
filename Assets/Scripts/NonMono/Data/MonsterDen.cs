public class MonsterDen: Settlement
{
    public MonsterDen(int population, float growth)
    {
        Resources[ResourceType.Population] = population;
        Growth = growth;
    }
}
