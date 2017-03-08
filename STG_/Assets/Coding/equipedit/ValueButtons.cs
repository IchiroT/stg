using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using System.IO;


using System;

using System.Runtime.Serialization.Formatters.Binary;

public class ValueButtons : MonoBehaviour {
    PrefsTag pt = new PrefsTag();
    ResourceTags rt = new ResourceTags();
    
    private int BarrageNumber;

    private float[] vbul;
    private float[] vwav;
    private float[] vbar;

    Sprite sp;

    Text viewer;

    public Slider bulletTexture;
    public Slider playerTexture;
    public Slider effectTexture;

    Transform Cont;

    GameObject play;
    PlayerBarrageControll bc;

    private string datap = "barrageData";

    getBarrageEditData gbe;

    GameObject[] bullets;
    Sprite[] enemies;
    GameObject[] effects;

    public void effectTextureChanged()
    {
        int which = (int)effectTexture.value;
        pt.Save_s(pt.pHiteffect, effects[which].name);
        Debug.Log(effects[which].name);
    }

    public void EnemyTextureChanged()
    {
        int which = (int)playerTexture.value;
        pt.Save_s(pt.pUseTexture, enemies[which].name);
        play.GetComponent<SpriteRenderer>().sprite = enemies[which];
    }
    public void BullettextureChange()
    {
        int which = (int)bulletTexture.value;
        pt.Save_s(pt.pUseBullet, bullets[which].name);
        play.GetComponent<PlayerBarrageControll>().bullet = bullets[which];

    }
    public void SaveData()
    {
        for (int v = 0; v < pt.pedBva.Length; v++)
        {
            gbe.set(0, v, vbul[v]);
            gbe.set(1, v, vwav[v]);
            gbe.set(2, v, vbar[v]);
        }
    }
    public void getBA()
    {
        
        setData();
        
    }
    public GameObject getBullet()
    {
        int bul = pt.Load_i(pt.pUseBullet);
        GameObject gm;

        gm = bullets[bul];

        return gm;
    }
   
    
    public void setData()
    {
        getBarrageEditData gbe = new getBarrageEditData(BarrageNumber);

        for (int v = 0; v < pt.pedBva.Length; v++)
        {
            vbul[v] = gbe.get(0, v);
            if (vbul[v] == -1) vbul[v] = 0;
            vwav[v] = gbe.get(1, v);
            if (vwav[v] == -1) vwav[v] = 0;
            vbar[v] = gbe.get(2, v);
            if (vbar[v] == -1) vbar[v] = 0;
        }

    }

    public void setBarrage()
    {
        play = transform.Find("Epanel").Find("GameObject").gameObject;

        bc= play.AddComponent<PlayerBarrageControll>();
        // = new BarrageAdmin();
        bc.setData(vbul, vwav, vbar,0,
             getBullet(),null);
    }

    public void UPGrade(int tag)
    {
        int g = tag / 10 -1;
        int v = tag % 10 -1;

        BarrageEditerData bed = new BarrageEditerData();
        int EP = pt.Load_i(pt.pep);
        if (EP == -1) EP = 0;
        int lv = bed.getLV(g, v);
        if (lv < 10)
        {
            if (bed.getLV(g, v) <= EP)
            {
                bed.UPGrade(g, v);
                EP -= lv;
                pt.Save_i(pt.pep, EP);
                lv++;
                viewer.text = "updata lv:" + lv;
                ValDefoltSetting();
            }
            else
            {
                viewer.text = "EP tarine~";
            }
        }
        else
        {
            viewer.text = "already Maximum";
        }

    }

    public void valsetTextures()
    {
       
        bulletTexture.minValue = 0;
        bulletTexture.maxValue = bullets.Length-1;
    
        playerTexture.minValue = 0;
        playerTexture.maxValue = enemies.Length-1;

        effectTexture.maxValue = effects.Length - 1;
    }
    
    public void ValDefoltSetting()
    {
        BarrageEditerData bed = new BarrageEditerData();
        for(int g = 0; g < pt.pedBgr.Length-1; g++)
        {
            //ok
            Transform cv = Cont.Find(pt.pedBgr[g]);
            for (int v = 0; v < pt.pedBva.Length; v++)
            {
              //ok
                Transform cv2=cv.Find(pt.pedBva[v]).Find("Slider");
                Slider s = cv2.GetComponent<Slider>();
                //Debug.Log(vbul[0]);//ok
                s.minValue = bed.onceGet(g, v, 0);
                s.maxValue = bed.onceGet(g, v, 1);
                //Debug.Log(vbul[0]);//out

                if (g == 0)
                {
                    s.value = vbul[v];//kokoha out
                }else if (g == 1)
                {
                    s.value = vwav[v];
                }
              
            }
        }
        Transform cv1 = Cont.Find(pt.pedBgr[2]).Find(pt.pedBva[2])
                   .Find("Slider");
        Slider s1 = cv1.GetComponent<Slider>();
        s1.minValue = bed.onceGet(2, 2, 0);
        s1.maxValue = bed.onceGet(2,2,1);
    }

    private bool generated = false;

    public void ValChange(int tag)
    {
        if (generated)
        {

            int g = tag / 10 - 1;
            int v = tag % 10 - 1;
            Transform cv = Cont.Find(pt.pedBgr[g]).Find(pt.pedBva[v])
                .Find("Slider");
            float value = cv.GetComponent<Slider>().value;
            if (v == 0)
            {
                value = (int)value;
            }
            else if (v == 2)
            {
                value = (int)value;//(((int)value) / 5) * 5;
            }
            else if (v == 4 || v == 5)
            {
                value = (int)(value / 0.05f) * 0.05f;
            }
            switch (g)
            {
                case 0:
                    vbul[v] = setChangedValue(value);
                    bc.valbul[v] = vbul[v];
                    break;
                case 1:
                    vwav[v] = setChangedValue(value);
                    bc.valwav[v] = vwav[v];
                    break;
                case 2:
                    vbar[v] = setChangedValue(value);
                    bc.valbar[v] = vbar[v];
                    break;
            }
        }

    }

    public float setChangedValue(float val)
    {
        viewer.text = val.ToString();
        return val;
    }

    public int setChangedValueI(int val)
    {
        viewer.text = val.ToString();
        return val;
    }

    public void TextSet()
    {
        for(int g = 0; g < pt.pedBgr.Length-1; g++)
        {
            for(int v = 0; v < pt.pedBva.Length; v++)
            {
                Transform buf = Cont.Find(pt.pedBgr[g]).Find(pt.pedBva[v]).
                    Find("Text");
                Text tx = buf.GetComponent<Text>();
                tx.text = pt.pedBgr[g] + " : " + pt.pedBva[v];
            }
        }
        Transform buf1 = Cont.Find(pt.pedBgr[2]).Find("rotate").
                   Find("Text");
        Text tx1 = buf1.GetComponent<Text>();
        tx1.text = pt.pedBgr[2] + " : " + "rotate";
    }

	// Use this for initialization
	void Start () {

        BarrageNumber = pt.Load_i(pt.pedBEditing);
        Debug.Log(BarrageNumber);
        gbe = new getBarrageEditData(BarrageNumber);
        //PlayerPrefs.DeleteAll();
        vbul = new float[6];
        vwav = new float[6];
        vbar = new float[6];
        getBA();
        Cont = transform.Find("Panel").Find("ScrollView")
            .Find("Viewport").Find("Content");
        viewer = transform.Find("Epanel").Find("Text").GetComponent<Text>();
        TextSet();


        bullets = Resources.LoadAll<GameObject>("object/bullet/");
        enemies = Resources.LoadAll<Sprite>("picture/enemy/");
        effects = Resources.LoadAll<GameObject>("object/effect/");


        setBarrage();

        ValDefoltSetting();
        valsetTextures();

        PlayerPrefs.SetInt("EP", 1000);

        generated = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void goTitle()
    {
        Application.LoadLevel(pt.scene_Title);
    }
    
}
