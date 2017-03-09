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
        int phit = pt.Load_i(pt.pChHitEffect);
        GameObject[] efs = Resources.LoadAll<GameObject>(rt.HitEffect);
        hitEffect = efs[phit];
        phit = pt.Load_i(pt.pUseBullet);
        efs = Resources.LoadAll<GameObject>(rt.Bullet);
        bullet = efs[phit];

    }

    public void SaveData()
    {
        //okanetoka?
    }
    

}