using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour {
    PrefsTag p = new PrefsTag();
    
    public PlayerData pd;
    
	// Use this for initialization
	void Start () {
        pd = new PlayerData();
        pd.LoadData();

        getBarrageEditData gb = new getBarrageEditData(p.Load_i(p.pedBEditing));

        PlayerBarrageControll pb = gameObject.AddComponent<PlayerBarrageControll>();

        GetComponent<SpriteRenderer>().sprite =
            Resources.Load<Sprite>("picture/enemy/" + p.Load_s(p.pUseTexture));
        string val = p.Load_s(p.pUseBullet);
        Debug.Log(val+"obj");

        pb.setData(gb.getvals(0), gb.getvals(1), gb.getvals(2), pd.atk,
             gb.getBullet(),gb.getHitEffect()//buf
            );

        EnemyStatesControll esc = gameObject.AddComponent<EnemyStatesControll>();
        esc.hpmax = pd.hp;
        esc.atk = pd.atk;
        esc.hiteffect = pd.hitEffect;

        Destroy(this);
	}
    
}
