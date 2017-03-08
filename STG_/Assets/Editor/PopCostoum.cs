using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PopAdmin))]
public class PopCostoum : Editor
{

    public override void OnInspectorGUI()
    {
        var a = target as PopAdmin;

        EditorGUI.BeginChangeCheck();
        a.size=EditorGUILayout.IntSlider("size", a.size, 0, 10);
        if (EditorGUI.EndChangeCheck())
        {
            OnInspectorGUI();
      
        }

        /*a.enemyAdmin = new Object[a.size];
        a.EnemyPosition = new Vector2[a.size];
        a.EnemyRotate = new float[a.size];
        a.PopInterval = new float[a.size];*/
        for (int i = 0; i < a.size; i++)
        {
          
            EditorGUILayout.LabelField("popenemy:", i.ToString());
            a.enemyAdmin[i] = EditorGUILayout.ObjectField("enemyadmin",a.enemyAdmin[i], typeof(EnemyAdmin), true);
            a.EnemyPosition[i].x = EditorGUILayout.Slider("posi_x",a.EnemyPosition[i].x, -6, 6);
            a.EnemyPosition[i].y = EditorGUILayout.Slider("posi_y",a.EnemyPosition[i].y, -6, 6);
            a.EnemyRotate[i] = EditorGUILayout.Slider("rotate", a.EnemyRotate[i],-180, 180);
            a.PopInterval[i] = EditorGUILayout.Slider("interval", a.PopInterval[i],0, 5);
            EditorGUILayout.Space();
            
        }


    

    }
}


