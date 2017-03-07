using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDatamake : MonoBehaviour {

    public BarrageAdmin ba;
    public Sprite ee;
    public GameObject[] use;

	// Use this for initialization
	void Start () {

        PlayerPrefs.SetFloat("atk", 3);
        PlayerPrefs.SetFloat("hp", 25);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
