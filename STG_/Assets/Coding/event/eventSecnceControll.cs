using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class eventSecnceControll : MonoBehaviour {
    ResourceTags rt = new ResourceTags();

	// Use this for initialization
	void Start () {
        rt.setEvent("tes");
        string tes = rt.ReadText(rt.eventTexs[0]);
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void next()
    {

        string val = rt.EventGetLine();
        Debug.Log(val);
        transform.Find("tpanel").Find("Text").GetComponent<Text>().text = val;
        string ev = rt.EventGetLine();
        if (ev != null) { 
        //eventAdmin ea = rt.getResourceSprite("tesP");
        //transform.Find("Image").GetComponent<Image>().sprite = ea.back;
        }
    }
}
