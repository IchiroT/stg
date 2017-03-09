using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatesControll : MonoBehaviour {

    public float hpmax=100;
    public float hpnw;
    public float atk;
    public float spd;
    public GameObject hiteffect;

    bool poped = false;
	// Use this for initialization
	void Start () {
        hpnw = hpmax;
	}
	
    public void damage(float dam)
    {
        hpnw -= dam;
        if (hpnw < 0)
        {
            if (gameObject.tag == "player")
            {
                Application.LoadLevel("Score");
            }
            else
            {
                transform.parent.GetComponent<StageControll>().scoreadd(hpmax * atk * spd);
                Destroy(gameObject);
            }

        }
    }
    
    public void OnBecameInvisible()
    {
        if(poped)
        Destroy(gameObject);
    }
    public void OnBecameVisible()
    {
        poped = true;
    }
}
