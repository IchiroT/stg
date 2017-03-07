using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    string[] key = new string[]
    {
        "up","left","right","down"
    };
    int[,] mover = new int[,]
    {
        {0,1 },
        {-1,0 },
        {1,0 },
        {0,-1 }
    };
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y < 5 && Input.GetKey(key[0]))
            transform.Translate(new Vector2(mover[0, 0] * 0.06f, mover[0, 1] * 0.06f));

        if (transform.position.x > -5 && Input.GetKey(key[1]))
            transform.Translate(new Vector2(mover[1, 0] * 0.06f, mover[1, 1] * 0.06f));

        if (transform.position.x < 5 && Input.GetKey(key[2]))
            transform.Translate(new Vector2(mover[2, 0] * 0.06f, mover[2, 1] * 0.06f));

        if (transform.position.y > -5 && Input.GetKey(key[3]))
            transform.Translate(new Vector2(mover[3, 0] * 0.06f, mover[3, 1] * 0.06f));



    }
    public void movever(string dire)
    {
        for(int i = 0; i < key.Length; i++)
        {
            if (key[i] == dire)
            {

                transform.Translate(new Vector2(mover[i, 0] * 0.06f, mover[i, 1] * 0.06f));
            }
        }
    }
    public void moveri(int dire)
    {
        transform.Translate(new Vector2(mover[dire, 0] * 0.06f, mover[dire, 1] * 0.06f));

    }
}
