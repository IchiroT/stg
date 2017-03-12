using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectValueControll : MonoBehaviour {

    public Text tStates;
    public Text tBarrage;
    public Text tDifficulity;
    public Slider weight;
    public GameObject cont;
    public GameObject se;

    public int mLv;
    public float wei;
    public int mdif;
    public int strage;


    PrefsTag p = new PrefsTag();

    float atk, def;
    //int difficulity;

        public void setStage()
    {
        StageAdmin[] sas = Resources.LoadAll<StageAdmin>("scriptable/stage/");
        GameObject buf;
        float width = se.GetComponent<RectTransform>().anchoredPosition.x;
        for(int i = 0; i < sas.Length; i++)
        {
            buf = Instantiate(se);
            buf.GetComponent<StageElementScr>().number = i;
            buf.transform.SetParent(cont.GetComponent<RectTransform>(), false);

            buf.name = sas[i].name;
        }
    }

    public void goStage(string name)
    {

        p.Save_i(p.difmine, mdif);
        p.Save_f(p.pwei, wei);
        p.Save_i(p.pedBEditing, strage);
        Application.LoadLevel("StageSample");
    }

    public void goEdit()
    {
        p.Save_i(p.pedBEditing, strage);
        Application.LoadLevel("EquipEdit");
    }

    public void difficulityChange(int i)
    {
        if (i+mdif > 0 && i+mdif <= mLv)
            mdif += i;
        diffView();
    }

    public void strageChange(int i)
    {
        if (strage+i < 6 && strage+i >= 0)
        {
            strage += i;
        }
        strView();
    }

    public void ViewUpdata()
    {
        strView();
        diffView();
        stView();
    }
    public void strView()
    {
        tBarrage.text = "strage:" + strage;
    }

    public void diffView()
    {
        tDifficulity.text =
            "difficulity\n  " + mdif;
    }
    public void stView()
    {
        tStates.text = "atk:" + atk +
            "\ndef:" + def;
    }

    public void weiUpdata()
    {
        wei = weight.value;
        stSet();
        stView();
    }

    public void stSet()
    {
        atk = mLv * wei + 1;
        def = mLv * (1 - wei) + 1;
    }

    public void setValue()
    {
        stSet();
    }

	// Use this for initialization
	void Start () {
        mLv = p.Load_i(p.plv);
        mdif = p.Load_i(p.pdiff);
        if (mdif == 0) mdif = 1;
        wei = p.Load_f(p.pwei);
        strage = p.Load_i(p.pedBEditing);
        setValue();
        ViewUpdata();

        //se = Resources.Load<GameObject>("stageselect/");
        setStage();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
