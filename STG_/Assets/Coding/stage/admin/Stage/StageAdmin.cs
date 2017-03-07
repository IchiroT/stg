using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="stage")]

public class StageAdmin : ScriptableObject
{
    public PopAdmin[] popAdimn;
    public AudioClip audio;
    public Texture2D backGround;
}