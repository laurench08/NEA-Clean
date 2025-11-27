using System.Collections;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public int GrowthStage;
    public bool isPlanted;
    public bool isHarvested;

    public Sprite FirstStage;
    public Sprite SecondStage;
    public Sprite ThirdStage;

    private Sprite CurrentSprite;
    // how it will work: if it is planted then after _ seconds then growth stage++ and sprite change to whichever sstage it is e.g. 1 = 1, 2 = 2 etc.
    //

    void Start()
    {
        if (!isPlanted)
        {
            GrowthStage = 0;
        }
    }

    void Update()
    {
        
    }

    public void Grow()
    {
        if (GrowthStage == 3)
        {
            Debug.Log("ALREADY AT MAX STAGE ");
        }
        else if (GrowthStage < 3)
        {   
            GrowthStage++;
            if (GrowthStage == 1)
            {
                CurrentSprite = FirstStage;
            }
            else if (GrowthStage == 2)
            {
                CurrentSprite = SecondStage;
            }
            else if (GrowthStage == 3)
            {
                CurrentSprite = ThirdStage;
            }
        }
         

    }
}
