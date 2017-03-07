using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPoper : MonoBehaviour {

    // Use this for initialization
    PlayerController pc;
	void Start () {
        pc = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
            pc.movever("up");
        if (transform.position.y > -4)
        {
            Destroy(this);
        }
        
		
	}
}
