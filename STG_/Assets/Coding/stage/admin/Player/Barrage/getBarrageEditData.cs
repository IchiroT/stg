using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getBarrageEditData
{
    PrefsTag pt = new PrefsTag();
    ResourceTags rt = new ResourceTags();
    private int BarrageNunber;

    public getBarrageEditData(int number)
    {
        BarrageNunber = number;
    }

   
  

 
 

    public float[] getvals(int g)
    {
        float[] ret = new float[6];
        for(int i = 0; i < ret.Length; i++)
        {
            ret[i] = get(g, i);
        }

        return ret;
    }
    public float get(int g,int v)
    {
        float ret = pt.Load_f(
              pt.pedBtag + pt.pedBgr[g] + pt.pedBva[v] + BarrageNunber);
        return ret;
    }
    public void set(int g,int v, float val)
    {
        pt.Save_f(
             pt.pedBtag + pt.pedBgr[g] + pt.pedBva[v] + BarrageNunber, val);
    }
}