using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControll : MonoBehaviour {
    PrefsTag p = new PrefsTag();

    public Text tScore;
    public Text tExp;
    public Text tLv;
    public Text tNowEp;

    int mlv;
    float score;
    int ep;
    float exp;

    public void goTitle()
    {
        p.Save_f(p.pexp, exp);
        p.Save_i(p.plv,mlv);
        p.Save_i(p.pep,ep);
        Application.LoadLevel("Title");

    }
    float needexp;
    public void ViewVals()
    {
        tScore.text += score;
        needexp = mlv*mlv*mlv;
        exp += score;
        tExp.text += (exp) + "/" +
            (needexp);
        tLv.text += mlv;
        if (exp > needexp)
        {
            exp = 0;
            mlv++;
            ep+=2;
            tLv.text += "→" + mlv;
        }
        tNowEp.text += ep;
    }

    public void getVals()
    {
        mlv = p.Load_i(p.plv);
        score = p.Load_f(p.stageScore);
        exp = p.Load_f(p.pexp);
        ep = p.Load_i(p.pep);

    }

    public void Start()
    {
        getVals();
        ViewVals();

    }

}
