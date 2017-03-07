using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BarrageAdmin))]
public class scriptableCostom : Editor {

    public override void OnInspectorGUI()
    {
        var b = target as BarrageAdmin;

        b.bulletObject = EditorGUILayout.ObjectField("bulletobj", b.bulletObject, typeof(GameObject), true);
        b.hitEffect = EditorGUILayout.ObjectField("hitsefect", b.hitEffect, typeof(GameObject), true);
        b.useBulletScript = EditorGUILayout.ObjectField("scripts", b.useBulletScript, typeof(ThwSrptAdm_bul), true);
        
        b.bul_times = EditorGUILayout.IntSlider("bul_times",(int) b.bul_times,0 ,60);
        b.bul_inter = EditorGUILayout.Slider("bul_inter", b.bul_inter,0 ,5);
        b.bul_rotate = EditorGUILayout.Slider("bul_rotate", (int)b.bul_rotate,-180 ,180);
        b.bul_speed = EditorGUILayout.Slider("bul_speed", b.bul_speed,0 ,0.5f);
        b.bul_x = EditorGUILayout.Slider("bul_x", b.bul_x,-5 ,5);
        b.bul_y = EditorGUILayout.Slider("bul_y", b.bul_y,-5 ,5);
        b.bul_wait = EditorGUILayout.Slider("bul_wait", b.bul_wait, -10, 10);
        EditorGUILayout.Space();
        b.wav_times = EditorGUILayout.Slider("wav_times", (int)b.wav_times,0 ,30);
        b.wav_inter = EditorGUILayout.Slider("wav_inter", b.wav_inter,0 ,5);
        b.wav_rotate = EditorGUILayout.Slider("wav_rotate", (int)b.wav_rotate,-180 ,180);
        b.wav_speed = EditorGUILayout.Slider("wav_speed", b.wav_speed,0 ,0.5f);
        b.wav_x = EditorGUILayout.Slider("wav_x", b.wav_x,-5 ,5);
        b.wav_y = EditorGUILayout.Slider("wav_y", b.wav_y, -5,5);
        b.wav_wait = EditorGUILayout.Slider("wav_wait", b.wav_wait, -10, 10);
        EditorGUILayout.Space();
        b.bar_times = EditorGUILayout.Slider("bar_times", (int)b.bar_times, 0,15);
        b.bar_inter = EditorGUILayout.Slider("bar_inter", b.bar_inter,0 ,5);
        b.bar_rotate = EditorGUILayout.Slider("bar_rotate", (int)b.bar_rotate,-180 ,180);
        b.bar_speed = EditorGUILayout.Slider("bar_speed", b.bar_speed, 0,0.5f);
        b.bar_x = EditorGUILayout.Slider("bar_x", b.bar_x,-5 ,5);
        b.bar_y = EditorGUILayout.Slider("bar_y", b.bar_y,-5 ,5);
        b.bar_wait = EditorGUILayout.Slider("bar_wait", b.bar_wait, -10, 10);
    }
}
