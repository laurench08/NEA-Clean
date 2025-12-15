
public class Plant 
{
    protected int GrowthStage;
    public bool isPlanted;
    public bool canHarvest;
    public string Name;

    public string Description;

    public bool hasGrown = false;

    // how it will work: if it is planted then after _ seconds then growth stage++ and sprite change to whichever sstage it is e.g. 1 = 1, 2 = 2 etc.
    //

    public Plant(string name, string description)
    {
        GrowthStage = 0;
        Name = name;
        Description = description; 
    }
   
    public virtual void Harvest()
    {
        if (canHarvest)
        {
            //harvest it and amke it appear in inventory 
            

        }
    }

    public virtual string Grow()
    {

        if (GrowthStage < 3)
        {
            GrowthStage++;
        }
        else if (GrowthStage >= 3)
        {
            canHarvest = true;
        }
        return $"Plant {Name} has grown to size {GrowthStage}";

    }

    public int GetGrowthStage()
    {
        return GrowthStage;
    }
}
