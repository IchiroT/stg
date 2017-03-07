using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleJunpScript : MonoBehaviour
{
    PrefsTag p = new PrefsTag();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void goEdit()
    {
        p.Save_i(p.pedBEditing, 1);
        Application.LoadLevel(p.scene_EquipEdit);
    }
    public void TestStage()
    {
        Application.LoadLevel("StageSelect");
    }
}

