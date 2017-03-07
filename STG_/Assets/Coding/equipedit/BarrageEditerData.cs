using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageEditerData
{
   public string tag="BED";

    public float[,] defaultValue = new float[,]
    {
        {
         1,0.5f,0,0.01f,0,0
        },
        {
        0,1f,0,0,0,0
        },
        {
          0,0,0,0,0,0
        }
    };

    float[,,] bias = new float[,,] {
        {
            {0,0.94f },
            {-0.049999f,0.05f },
            {-18,18 },
            {-0.001f,0.03f },
            {-0.05f,0.05f },
            {-0.05f,0.05f}
        },
        {
            {0,1 },
            {-0.1f,0.1f },
            {-18,18 },
            {0,0.03f },
            {-0.05f,0.05f},
            {-0.05f,0.05f},

        },
        {
            {0,0 },
            {0.01f, 0.1f},
            {-18,18 },
            {0,0.03f },
            {0,0 },
            {0, 0},

        }
    };



    public float onceGet(int g, int v, int which)
    {
        float ret = defaultValue[g, v] + bias[g, v, which] * getLV(g, v);
        return ret;
    }
    public void UPGrade(int g,int v)
    {
        int val = getLV(g,v) + 1;
        PlayerPrefs.SetInt(tag + g +"a"+ v, val);

    }
    public int getLV(int g,int v)
    {
        int val = PlayerPrefs.GetInt(tag + g+"a" + v, 0);
        return val;
    }
}