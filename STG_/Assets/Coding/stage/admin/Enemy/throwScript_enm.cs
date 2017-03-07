using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwScript_enm : MonoBehaviour {

    public ThwSrptAdm_enm tsa;

    // Use this for initialization
    public void RunAdd()
    {
            for (int i = 0; i < tsa.scriptNames.Length; i++)
            {
                switch (tsa.scriptNames[i])
                {

                    case "Go":
                        transform.gameObject.AddComponent<Go>();
                        break;
                    case "Rotate":
                        transform.gameObject.AddComponent<Rotate>();
                        break;

                    case "StopBoss":
                        transform.gameObject.AddComponent<StopBoss>();
                        break;
                case "item":
                    transform.gameObject.AddComponent<Item>();
                    break;

                    /*
                case "":
                    transform.gameObject.AddComponent<>();
                    break;*/

            }
            }
        
        DestroyImmediate(this);
    }

}
