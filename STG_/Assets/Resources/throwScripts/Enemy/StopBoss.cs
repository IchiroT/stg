using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBoss : MonoBehaviour {

    public float spd;
	// Use this for initialization
	void Start () {
        spd = GetComponent<EnemyStatesControll>().spd;
	}

    // Update is called once per frame
    float elapse = 0;
	void Update () {
        if (transform.position.y > 4)
        {
            transform.Translate(0, spd,0);
        }
	}
}
