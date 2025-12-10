using System.Collections;
public class Plant 
{
    protected int GrowthStage;
    public bool isPlanted;
    public bool isHarvested;
    public string Name;

//    public Sprite FirstStage;
//    public Sprite SecondStage;
//    public Sprite ThirdStage;

 //   public Sprite CurrentSprite;
    // how it will work: if it is planted then after _ seconds then growth stage++ and sprite change to whichever sstage it is e.g. 1 = 1, 2 = 2 etc.
    //

    public Plant(string name)
    {
        GrowthStage = 0;
        Name = name;
    }
    


    public virtual string Grow()
    {
        GrowthStage += 1;
        return $"Plant {Name} has grown to size {GrowthStage}";

    }
}
