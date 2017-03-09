using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_move : MonoBehaviour {

    public float speed;
    public float atk;
    public GameObject effectExp=null;

    public void Start()
    {
        elapse *= -1;
    }

    public float elapse = 0;
	void Update () {
        elapse += Time.deltaTime;
        if (elapse > 5) {
            Destroy(gameObject);
        Vector3 a = transform.position.normalized;
        }else if(elapse>0)
        transform.Translate(Vector2.up * speed);
        }

    
    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != gameObject.tag&&collision.name!="b")
        {
            // Debug.Log("damage:"+atk+":"+collision.name);
            EnemyStatesControll esc =
                collision.gameObject.GetComponent<EnemyStatesControll>();
            esc.damage(atk);
            GameObject on= Instantiate<GameObject>(effectExp);
            on.AddComponent<AnimeOnce>();
            on.transform.position = transform.position;

            Destroy(gameObject);
        }
    }
}
