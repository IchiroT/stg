using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Go : MonoBehaviour {

    float speed;

	// Use this for initialization
	void Start () {
        EnemyStatesControll esc = GetComponent<EnemyStatesControll>();
        speed = esc.spd;

		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.up * speed);
        //gameObject.AddComponent<Go>();
	}

  
}
