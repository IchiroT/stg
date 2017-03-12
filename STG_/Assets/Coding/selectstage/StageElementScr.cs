using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageElementScr : MonoBehaviour {

    public int number;
   
    public void OnClick()
    {
        PrefsTag p = new PrefsTag();
        p.Save_i(p.sselectName, number);
        Application.LoadLevel("StageSample");
    }
}
