using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageControll : MonoBehaviour
{

    public StageAdmin sa;

    public float difficulity;
    PrefsTag p = new PrefsTag();
    public float score = 0;

    // Use this for initialization
    void Start()
    {


        difficulity = p.Load_f(p.difmine);
        if (difficulity == 0) difficulity = 1;
        AudioSource audio = gameObject.AddComponent<AudioSource>();
        audio.clip = sa.audio;
        audio.Play();
        audio.loop = true;
        Sprite back = Sprite.Create(sa.backGround, new Rect(0, 0, 256, 256), Vector2.zero);
        Instantiate(back);
    }

    // Update is called once per frame
    public float elapse = 0;
    public int progressCounter = 0;
    PopControll pop = null;
    void Update()
    {
        if (pop == null)
        {
            if (progressCounter >= sa.popAdimn.Length)
            {
                Finisher();
            }
            else if (transform.childCount <= 1)
            {
                pop = gameObject.AddComponent<PopControll>();
                //pop = GetComponent<PopControll>();
                pop.pa = sa.popAdimn[progressCounter];
                progressCounter++;
            }
        }
    }

    public void scoreadd(float sco)
    {
        score += difficulity * sco;
    }

    public void Finisher()
    {
        p.Save_f(p.stageScore, score);
        Application.LoadLevel("Score");
    }
}

