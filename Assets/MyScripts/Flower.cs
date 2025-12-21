using System.Collections;
using UnityEngine;

public class Flower : Plant
{
    
    public Flower(string s, string description) : base (s, description)
    {

    }
    public override string Grow() // make it grow at a slower rate
    {
        timer = 3.0f;

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

    /*public override string Grow()
    {
        GrowthStage += 1;
        return $"veg grown by 2 to {GrowthStage}";
    }*/
}
