using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaUiValueSetting
{
    /*
     * times min max
     * inter min max
     * rotate min max
     * speed min max
     * x min max
     * y min max
     */
    public float[,,] valOffSet = new float[,,]{
        {
            {1,10 },
            {0,1 },
            {-180,180 },
            {0,0.3f },
            {-0.5f,0.5f },
            {-0.5f,0.5f },
        },
        {
            {0,10 },
            {0.05f,1f },
            {-180,180 },
            {0,0.3f },
            {-0.5f,0.5f },
            {-0.5f,0.5f },
        },
        {
            {0,0 },
            {0.1f,1 },
            {-180,180 },
            {0,0.3f },
            {0,0 },
            {0,0 },
        },
    };
}
