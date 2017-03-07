using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class ResourceTags
{
    public string _s_admin = "scriptable/stage/";
    private string picture_root_path =  "/    /";
    private string text_root_path = "/";// "/    /";

    public string EnemyObjBuf = "object/enemy/buf";

    public string[] eventTexs = new string[]
    {
        "tes"
    };

    public string Bullet = "object/bullet/";
    public string HitEffect = "object/effect/";

    public GameObject getResourceObject(string path,string objnam)
    {
        GameObject go = Resources.Load<GameObject>(path + objnam);
        return go;
    }

    /*public eventAdmin getResourceSprite(string path)
    {
        //eventAdmin ret = Resources.Load<eventAdmin>(back + path);
        return ret;
    }*/

    StreamReader e_sr;
    bool e_texturn = false;
    public void setEvent(string path)
    {
        FileInfo fi = new FileInfo(Application.dataPath
           + text_root_path + path + ".txt");
        e_sr
                = new StreamReader(fi.OpenRead(), Encoding.UTF8);
        e_texturn = true;
    }
    public string EventGetLine()
    {
        string ret;
        try
        {
            ret = e_sr.ReadLine();
        }
        catch(Exception e)
        {
            ret = "";
            e_sr.Close();
        }
        e_texturn = !e_texturn;
        return ret;
    }

    public string ReadText(string path)
    {
        string testxt = "";

        FileInfo fi = new FileInfo(Application.dataPath
            + text_root_path + path+".txt");
        //tes
        //ok FileInfo fi = new FileInfo(Application.dataPath + "/"+ path+".txt");

        try
        {
            using (StreamReader sr 
                = new StreamReader(fi.OpenRead(), Encoding.UTF8))
                testxt += sr.ReadToEnd();
        }
        catch (Exception e)
        {
            testxt += " ";
        }

        return testxt;
    }

    public Sprite ReadTexture(string path,int width,int height)
    {
        byte[] readBin = ReadPngFile(Application.dataPath+picture_root_path+ path);
        Texture2D ttre = new Texture2D(width, height);
        ttre.LoadImage(readBin);
        Sprite sp = Sprite.Create(ttre, new Rect(0, 0, width, height), Vector2.zero);
        return sp;
    }
    private byte[] ReadPngFile(string path)
    {
        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        BinaryReader bin = new BinaryReader(fs);
        byte[] val = bin.ReadBytes((int)bin.BaseStream.Length);

        bin.Close();
        return val;
    }
}