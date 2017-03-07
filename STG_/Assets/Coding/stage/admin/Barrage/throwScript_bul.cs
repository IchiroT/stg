using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwScript_bul : MonoBehaviour {

    public ThwSrptAdm_bul tsa;

    // Use this for initialization
    public void RunAdd() {
        if (tsa != null)
        {
            for (int i = 0; i < tsa.scriptNames.Length; i++)
            {
                switch (tsa.scriptNames[i])
                {
                    case "move":
                        transform.gameObject.AddComponent<bullet_move>();
                        break;
                        /*
                    case "":
                        transform.parent.gameObject.AddComponent<>();
                        break;*/

                }
            }
        } 

        DestroyImmediate(this);
	}
	
}
