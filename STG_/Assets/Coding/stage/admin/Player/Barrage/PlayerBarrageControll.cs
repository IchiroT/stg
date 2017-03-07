using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarrageControll : MonoBehaviour
{

    public float[] valbul;
    public float[] valwav;
    public float[] valbar;
    public float atk;

    float elapse;

    public GameObject bullet;
    public GameObject hiteffect;

    public void setData(float[] bul, float[] wav, float[] bar, float atkData,
        GameObject bulletData,GameObject hiteffectData)
    {

        valbul = bul;
        valwav = wav;
        valbar = bar;
        bullet = bulletData;
        atk = atkData;
        hiteffect = hiteffectData;

        turn_bullet = true;
    }
    
    // Use this for initialization
    void Start()
    {
        //TODDO sprite=getcompo taio script from playerobject

    }

    // Update is called once per frame
    public int count_barrange = 0;
    public int count_wave = 0;
    public int count_bullet = 0;

    bool turn_bullet = false;
    bool turn_wave = false;
    bool turn_barrange = false;

    void Update()
    {

        elapse += (Time.deltaTime/*+characterSpeed*/);
        if (valbul[1] < elapse && turn_bullet)
        {
            //Debug.Log("bullet");
            elapse = 0;
            if ((int)valbul[0] > count_bullet)
            {
                Bullet();
                count_bullet++;
            }
            else
            {
                count_bullet = 0;
                turn_bullet = false;
                turn_wave = true;
            }
        }
        if (valwav[1] < elapse && turn_wave)
        {
            //Debug.Log("wave");
            elapse = 0;
            if (count_wave <(int)valwav[0])
            {
                turn_wave = false;
                turn_bullet = true;
                count_wave++;
            }
            else
            {
                count_wave = 0;
                turn_wave = false;
                turn_barrange = true;
            }
        }
        if (valbar[1] < elapse && turn_barrange)
        {
            //Debug.Log("barrange");
            elapse = 0;
            turn_barrange = false;
            turn_bullet = true;
            count_barrange++;
           
        }

    }
    GameObject blt;
    bullet_move bm;
    void Bullet()
    {
        blt = Instantiate(bullet);
        blt.name = "b";
        //blt.transform.parent = transform.parent;
        //blt.transform.parent = ParentChara;
        

        bm = blt.AddComponent<bullet_move>();
        bm.speed = valbul[3] +
            valwav[3] + 
            valbar[3];
        blt.tag = transform.tag;

        bm.effectExp = hiteffect;
        bm.atk = atk;
        

        /*if (useScript != null)
        {
            buf = Instantiate(useScript);
        buf.transform.parent = blt.transform;
        }*/


        blt.transform.position = new Vector2(
            transform.position.x
            + valbul[4] * (count_bullet + 1)
            + valwav[4] * (count_wave + 1)
            + valbar[4] * (count_barrange + 1),
            transform.position.y
            + valbul[5]* (count_bullet + 1)
            + valwav[5] * (count_wave + 1)
            + valbar[5]* (count_barrange + 1)
            );
        blt.transform.rotation = transform.rotation;
        blt.transform.Rotate(0, 0,
            transform.rotation.z
            + valbul[2]* (count_bullet + 1)
            + valwav[2]* (count_wave + 1)
            + valbar[2]* (count_barrange + 1)
            );
    }

}
