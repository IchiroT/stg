using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="pop")]
public class PopAdmin : ScriptableObject
{
    public int size;
    public Object[] enemyAdmin=new Object[10];
    public Vector2[] EnemyPosition=new Vector2[10];
    public float[] EnemyRotate=new float[10];
    public float[] PopInterval=new float[10];
}
