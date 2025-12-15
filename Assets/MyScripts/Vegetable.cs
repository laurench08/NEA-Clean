using System.Collections;
using UnityEngine;

public class Vegetable : Plant
{
    
    public Vegetable(string s, string description) : base (s, description)
    {

    }
   

    /*public override string Grow()
    {
        GrowthStage += 1;
        return $"veg grown by 2 to {GrowthStage}";
    }*/
}
