using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CHaraHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != gameObject.tag && collision.name != "b")
        {
            escme = transform.GetComponent<EnemyStatesControll>();
            esc = collision.gameObject.GetComponent<EnemyStatesControll>();
            esc.damage( escme.atk * 5);
            on = Instantiate<GameObject>(escme.hiteffect);
            on.transform.position = collision.transform.position;
            on.AddComponent<AnimeOnce>();
        }
    }
    EnemyStatesControll escme;
    EnemyStatesControll esc;
    GameObject on;
  

}
