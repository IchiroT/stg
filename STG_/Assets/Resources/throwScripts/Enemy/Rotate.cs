using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    float elapse = 0;
	void Update () {
        elapse += Time.deltaTime;
        if (elapse > 1)
        {
            elapse = 0;
            transform.Rotate(0, 0, 90);
        }
		
	}
}
