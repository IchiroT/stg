﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player"&&collision.name!="b")
        {
            collision.GetComponent<EnemyStatesControll>().damage( transform.
                GetComponent<EnemyStatesControll>().atk);
            Destroy(gameObject);
        }
    }
}
