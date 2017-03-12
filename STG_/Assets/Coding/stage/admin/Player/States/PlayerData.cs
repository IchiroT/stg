using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public float atk;
    public float hp;
    public GameObject hitEffect;
    public GameObject bullet;
        

    public void LoadData()
    {
        PrefsTag pt = new PrefsTag();
        ResourceTags rt = new ResourceTags();

        int lv = pt.Load_i(pt.plv);
        if (lv == -1) lv = 1;
        float wei = pt.Load_f(pt.pwei);
        if (wei == -1) wei = 0.5f;
        atk = lv * wei+1;
        hp = lv * (1 - wei)+1;
        string phit = pt.Load_s(pt.pChHitEffect);
        hitEffect= rt.getResourceObject(rt.HitEffect, phit);
        phit = pt.Load_s(pt.pUseBullet);
        bullet = rt.getResourceObject(rt.Bullet, phit);

    }

    public void SaveData()
    {
        //okanetoka?
    }
    

}