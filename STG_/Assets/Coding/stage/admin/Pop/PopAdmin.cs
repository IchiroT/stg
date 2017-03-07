using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="pop")]
public class PopAdmin : ScriptableObject
{
    public int size;
    public Object[] enemyAdmin;
    public Vector2[] EnemyPosition;
    public float[] EnemyRotate;
    public float[] PopInterval;
}
