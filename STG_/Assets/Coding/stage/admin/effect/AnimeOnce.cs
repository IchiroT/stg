using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimeOnce : MonoBehaviour
{
    float elapse;

	// Use this for initialization
	void Start () {
        elapse = GetComponent<Animator>()
            .GetCurrentAnimatorStateInfo(0)
            .length;
	}
	
	// Update is called once per frame
	void Update () {
        elapse -= Time.deltaTime;
        if (elapse < 0)
        {
            Destroy(gameObject);
        }
	}
}
