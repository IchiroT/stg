using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopControll : MonoBehaviour
{

    public PopAdmin pa;

    public ResourceTags rt = new ResourceTags();
    


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    public float elapse = 0;
    public int PopCounter = 0;
    GameObject nowEnemy = null;//syozizyouniyorisakusei iranai?
    void Update()
    {
        elapse += Time.deltaTime;

        if (elapse > getInterval() && PopCounter < pa.enemyAdmin.Length)
        {
            elapse = 0;
            CreateEenmy();
            PopCounter++;
        }
        else if (transform.childCount <= 1&&PopCounter>=pa.enemyAdmin.Length)
        {
            //gameObject.SetActive(false);
            DestroyImmediate(this);
        }
        }

    public void CreateEenmy()
    {

        EnemyAdmin eA = pa.enemyAdmin[PopCounter] as EnemyAdmin;

        GameObject enemy = eA.enemyObject;
        //Debug.Log(enemy);
        nowEnemy = Instantiate(enemy);
        nowEnemy.transform.parent = transform;
        nowEnemy.tag = "enemy";
        nowEnemy.AddComponent<CHaraHit>();

        EnemyStatesControll esc= nowEnemy.AddComponent<EnemyStatesControll>();
        esc.hpmax = eA.enemyStates.HP;
        esc.atk = eA.enemyStates.ATK;
        esc.spd = eA.enemyStates.SPD;
        esc.hiteffect = eA.hiteffect;

        nowEnemy.transform.position = getPosition();
        nowEnemy.transform.Rotate(new Vector3(0, 0,
            getRotate()+179));

        for (int i = 0; i < eA.useBarrages.Length; i++)
        {
            Barrage_control2 bc = nowEnemy.AddComponent<Barrage_control2>();
            bc.ba = eA.useBarrages[i];
            //bc.characterSpeed = eA.enemySpeed;
            bc.difficulty = GetComponent<StageControll>().difficulity;
        }
        if (eA.useScripts != null) {
        throwScript_enm ts = nowEnemy.AddComponent<throwScript_enm>();
        ts.tsa = eA.useScripts;
        ts.RunAdd();
        }
        
        
    }

    public Vector2 getPosition()
    {
        int num = PopCounter;
        Vector2 ret = new Vector2(0, 0);
        if (PopCounter < pa.EnemyPosition.Length)
        {
            ret = pa.EnemyPosition[num];
        }
        else if (pa.EnemyPosition.Length == 0)
        {

        }
        else
        {
            num = pa.EnemyPosition.Length - 1;
            ret = pa.EnemyPosition[num];
        }
        return ret;
    }
    public float getRotate()
    {
        int num = PopCounter;
        float ret = 0;
        if (PopCounter < pa.EnemyRotate.Length)
        {
            ret = pa.EnemyRotate[num];
        }
        else if (pa.EnemyRotate.Length == 0)
        {

        }
        else
        {
            num = pa.EnemyRotate.Length - 1;
            ret = pa.EnemyRotate[num];
        }
        return ret;
    }
    public float getInterval()
    {
        int num = PopCounter;
        float ret = 0;
        if (PopCounter < pa.PopInterval.Length)
        {
            ret = pa.PopInterval[num];
        }
        else if (pa.PopInterval.Length == 0)
        {

        }
        else
        {
            num = pa.PopInterval.Length - 1;
            ret = pa.PopInterval[num];
        }
        return ret;
    }
}
