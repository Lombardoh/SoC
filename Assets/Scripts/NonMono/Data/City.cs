public class City
{
    private int population;
    private float growth;

    public City(int population, float growth)
    {
        this.population = population;
        this.growth = growth;
    }
    public int Population
    {
        get { return population; }
        set { population = value; }
    }    
    
    public float Growth
    {
        get { return growth; }
        set { growth = value; }
    }
}

