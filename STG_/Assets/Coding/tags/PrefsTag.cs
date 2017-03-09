using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsTag
{
    public string difmax = "difficulity_max";
    public string difmine = "difficulity_mine";

    public string plv = "playerLV";
    public string pwei = "playerStatesWeight";
    public string pep="EP";
    public string pdiff = "playerselecteddifficulity";
    public string pexp = "playernowhaveexperience";

    public string stageScore = "stagelatestgetscore";

    public string pedBEditing = "EditingNumber";
    public string pedBtag = "tageditingplaser";

    public string scene_EquipEdit="EquipEdit";
    public string scene_StageSample = "StageSample";
    public string scene_Title="Title";

    //public string pUseScript = "playerusescript";
    //public string pUseScriptAmount = "plyaerscriptamount";
    public string pUseBullet = "playerUseBullet";
    public string pUseTexture = "playerusedTexture";
    //public string pHiteffect = "playerHitEffect";
    public string pChHitEffect = "playerHitCharaeffect";


    public string[] pedBgr =  new string[]
    {
        "bullet","wave","barrage"
    };
    public string[] pedBva = new string[]
    {
        "times","inter","rotate","speed","x","y"
    };

    //public string pbarrage = "usebarrage";

    public string sselectName = "stageselected";



    public void Save_i(string tag, int val)
    {
        PlayerPrefs.SetInt(tag, val);
    }
    public void Save_f(string tag, float val)
    {
        PlayerPrefs.SetFloat(tag, val);
    }
    public void Save_s(string tag, string val)
    {
        PlayerPrefs.SetString(tag, val);
    }

    public int Load_i(string tag )
    {
        return PlayerPrefs.GetInt(tag,0);
    }
    public float Load_f(string tag )
    {
        return PlayerPrefs.GetFloat(tag,0);
    }
    public string Load_s(string tag )
    {
        return PlayerPrefs.GetString(tag,null);
    }

}
