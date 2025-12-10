using System.Collections;
using UnityEngine;

public class Vegetable : Plant
{
    
    public Vegetable(string s) : base (s)
    {

    }

    public override string Grow()
    {
        GrowthStage += 2;
        return $"veg grown by 2 to {GrowthStage}";
    }
}
