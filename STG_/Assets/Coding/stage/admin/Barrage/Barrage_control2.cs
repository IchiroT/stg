using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrage_control2 : MonoBehaviour
{


    public float difficulty;
    public BarrageAdmin ba;

    float elapse;

    GameObject bullet;


    // Use this for initialization
    void Start()
    {
        bullet = ba.bulletObject as GameObject;
        esc = GetComponent<EnemyStatesControll>();

    }

    // Update is called once per frame
    public int count_barrage = 0;
    public int count_wave = 0;
    public int count_bullet = 0;

    bool turn_bullet = true;
    bool turn_wave = false;
    bool turn_barrage = false;

    void Update()
    {
            
    elapse += (Time.deltaTime/*+characterSpeed*/) * difficulty;
        if (ba.bul_inter < elapse && turn_bullet)
        {
            //Debug.Log("bullet");
            elapse = 0;
            if ((int)ba.bul_times > count_bullet)
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
        if (ba.wav_inter < elapse && turn_wave)
        {
            //Debug.Log("wave");
            elapse = 0;
            if (count_wave < (int)ba.wav_times)
            {
                turn_wave = false;
                turn_bullet = true;
                count_wave++;
            }
            else
            {
                count_wave = 0;
                turn_wave = false;
                turn_barrage = true;
            }
        }
        if (ba.bar_inter < elapse && turn_barrage)
        {
            //Debug.Log("barrange");
            elapse = 0;
            if (count_barrage < (int)ba.bar_times)
            {
                turn_barrage = false;
                turn_bullet = true;
                count_barrage++;
            }
            else
            {
                count_barrage = 0;
                turn_barrage = false;
                turn_bullet = true;
            }
        }
    }

    float lateTime = 0.016395780f;

    EnemyStatesControll esc;
    void Bullet()
    {
        GameObject blt = Instantiate(bullet);
        //blt.transform.parent = transform;

        blt.tag = transform.tag;
        blt.name = "b";

        GameObject buf;


        throwScript_bul ts = blt.AddComponent<throwScript_bul>();
        ts.tsa = ba.useBulletScript as ThwSrptAdm_bul;
        ts.RunAdd();



        bullet_move bm = blt.AddComponent<bullet_move>();
        bm.speed = ba.bul_speed * (count_bullet + 1) +
             ba.wav_speed * (count_wave + 1) +
             ba.bar_speed * (count_barrage + 1);
        bm.speed *= difficulty;

        bm.elapse += (ba.bul_times - count_bullet) * lateTime
            + ba.bul_wait * (count_bullet + 1) +
            ba.wav_wait * (count_wave + 1) +
            ba.bar_wait * (count_barrage + 1);

        bm.atk = esc.atk * difficulty;

        bm.effectExp = ba.hitEffect as GameObject;

        //bm.enabled = false;

        blt.transform.position = new Vector2(
             transform.position.x
             + ba.bul_x * (count_bullet + 1)
             + ba.wav_x * (count_wave + 1)
             + ba.bar_x * (count_barrage + 1),
             transform.position.y
             + ba.bul_y * (count_bullet + 1)
             + ba.wav_y * (count_wave + 1)
             + ba.bar_y * (count_barrage + 1)
             );
        blt.transform.rotation = transform.rotation;
        blt.transform.Rotate(0, 0,
            transform.rotation.z
            + ba.bul_rotate * (count_bullet + 1)
            + ba.wav_rotate * (count_wave + 1)
            + ba.bar_rotate * (count_barrage + 1)
            );
    }

}